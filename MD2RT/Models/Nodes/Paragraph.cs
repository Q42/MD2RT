using HtmlAgilityPack;

namespace MD2RT.Models.Nodes;

public class Paragraph : Node
{
  public Paragraph(HtmlNode node) : base("paragraph")
  {
    Attrs = GetAttrs(node);
  }

  public new ParagraphAttributes? Attrs { get; }

  private static ParagraphAttributes GetAttrs(HtmlNode node)
  {
    var attributes = new ParagraphAttributes();
    var styleAttribute = node.Attributes.FirstOrDefault(a => a.Name == "style");

    if (styleAttribute != null)
    {
      foreach (var style in styleAttribute.Value.Split(';').Select(style => style.Replace(" ", "")))
      {
        const string textAlign = "text-align:";

        if (style.StartsWith(textAlign))
        {
          attributes.TextAlign = style[textAlign.Length..];
        }
      }
    }

    return attributes;
  }

  public override HtmlNode RenderHtmlNode()
  {
    return !string.IsNullOrEmpty(Attrs?.TextAlign)
      ? HtmlNode.CreateNode($"<p style='text-align: {Attrs.TextAlign}'></p>")
      : HtmlNode.CreateNode("<p></p>");
  }

  public new bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
