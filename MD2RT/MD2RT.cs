using Markdig;
using MD2RT.Models;
using MD2RT.Models.Nodes;
using Newtonsoft.Json;

namespace MD2RT;

public class MD2RT
{
  public static string ToRichText(string markdown)
  {
    var html = Markdown.ToHtml(JsonConvert.DeserializeObject<string>(markdown)!);
    var obj = ProseMirrorConvert.DeserializeObjectFromHtml(html);

    Clean(obj);

    var json = ProseMirrorConvert.SerializeToJson(obj);

    return JsonConvert.SerializeObject(json);
  }

  // Clean up the node tree `ProseMirrorConvert` produces:
  // 1. remove "empty" text nodes
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
        // 1. remove "empty" text nodes
        copy.Remove(child);
        node.Content = copy;
      }

      Clean(child);
    }
  }
}
