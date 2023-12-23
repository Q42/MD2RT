using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Markdig;
using MD2RT.Models;
using MD2RT.Models.Nodes;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace MD2RT;

public class MD2RT
{
  public static string ToRichText(string markdown, bool isJsonString = true)
  {
    var parsed = isJsonString ? JsonConvert.DeserializeObject<string>(markdown)! : markdown;
    var html = Markdown.ToHtml(parsed);
    var obj = ProseMirrorConvert.DeserializeObjectFromHtml(html);

    Clean(obj);

    var json = ProseMirrorConvert.SerializeToJson(obj);

    return JsonConvert.SerializeObject(json);
  }

  public static void Process(object? root, string uiHintSource, string uiHintTarget, string appendTarget, bool isJsonString = true, ILogger? logger = null)
  {
    if (root == null)
    {
      return;
    }

    logger ??= new StdoutLogger();

    var uiHintSourceProperties = root.GetType().GetProperties().Where(p => HasUIHint(p, uiHintSource)).ToList();
    var uiHintTargetProperties = root.GetType().GetProperties().Where(p => HasUIHint(p, uiHintTarget)).ToList();
    var listOrArrayProperties = root.GetType().GetProperties().Where(IsEnumerable).ToList();

    foreach (var p in uiHintSourceProperties)
    {
      var targetPropertyName = $"{p.Name}{appendTarget}";
      var targetProperty = uiHintTargetProperties.SingleOrDefault(p => p.Name == targetPropertyName);

      if (targetProperty == null)
      {
        logger.LogInformation("Did not find a target property for {source}", p.Name);
      }
      else
      {
        var sourceValue = $"{p.GetValue(root)}";

        targetProperty.SetValue(root, ToRichText(sourceValue, isJsonString));

        logger.LogInformation("Written rich-text to '{target}' from markdown '{source}'", targetProperty.Name, p.Name);
      }
    }

    foreach (var p in listOrArrayProperties)
    {
      if (p.GetValue(root) is IEnumerable enumerable)
      {
        foreach (var child in enumerable)
        {
          Process(child, uiHintSource, uiHintTarget, appendTarget, isJsonString, logger);
        }
      }
    }
  }

  // Remove "empty" text nodes the node tree `ProseMirrorConvert` produces
  private static void Clean(Node? node)
  {
    if (node == null)
    {
      return;
    }

    var copy = node.Content?.ToList() ?? new List<Node>();
    var children = node.Content?.ToList() ?? new List<Node>();

    foreach (var child in children)
    {
      if (child is TextNode { Text: "" })
      {
        // Remove "empty" text nodes
        copy.Remove(child);
        node.Content = copy;
      }

      // Recursively clean all children
      Clean(child);
    }
  }

  private static bool HasUIHint(ICustomAttributeProvider propertyInfo, string uiHintName)
  {
    var attributes = (UIHintAttribute[])propertyInfo.GetCustomAttributes(typeof(UIHintAttribute), false);

    return attributes.Any(a => a.UIHint == uiHintName);
  }

  private static bool IsEnumerable(PropertyInfo propertyInfo)
  {
    return typeof(string) != propertyInfo.PropertyType &&
           typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);
  }
}
