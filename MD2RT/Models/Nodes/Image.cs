using HtmlAgilityPack;
using System.Text;

namespace MD2RT.Models.Nodes;

public class Image : Node
{
  public Image(HtmlNode node) : base("image")
  {
    Attrs = new ImageAttributes
    {
      Alt = node.Attributes.FirstOrDefault(a => a.Name == "alt")?.Value,
      Src = node.Attributes.FirstOrDefault(a => a.Name == "src")?.Value,
      Title = node.Attributes.FirstOrDefault(a => a.Name == "title")?.Value,
      Width = int.TryParse(node.Attributes.FirstOrDefault(a => a.Name == "width")?.Value, out var intVal) ? intVal : null
    };
  }

  public new ImageAttributes? Attrs { get; }

  public override HtmlNode RenderHtmlNode()
  {
    var sb = new StringBuilder();
    var src = Attrs?.Src;
    var alt = Attrs?.Alt;
    var title = Attrs?.Title;
    var width = Attrs?.Width;

    if (src != null)
    {
      sb.Append($"src='{src}' ");
    }

    if (alt != null)
    {
      sb.Append($"alt='{alt}'");
    }

    if (title != null)
    {
      sb.Append($"title='{title}' ");
    }

    if (width != null)
    {
      sb.Append($"width='{width.Value}' ");
    }

    return HtmlNode.CreateNode($"<img {sb}></img>");
  }

  public new bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
