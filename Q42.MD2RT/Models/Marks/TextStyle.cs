using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Marks;

public class TextStyle : Mark
{
  public TextStyle(HtmlNode node) : base("textStyle")
  {
    Attrs = GetAttrs(node);
  }

  public new TextStyleAttributes? Attrs { get; protected set; }

  public static TextStyleAttributes? GetAttrs(HtmlNode node)
  {
    TextStyleAttributes? attributes = null;
    var styleAttribute = node.Attributes.FirstOrDefault(a => a.Name == "style");

    if (styleAttribute != null)
    {
      foreach (var style in styleAttribute.Value.Split(';').Select(style => style.Replace(" ", "")))
      {
        const string color = "color:";
        if (style.StartsWith(color))
        {
          if (attributes == null)
          {
            attributes = new TextStyleAttributes();
          }

          attributes.Color = style.Substring(color.Length);
        }
      }
    }

    return attributes;
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode($"<span style='color:{Attrs?.Color}'></span>");
  }
}
