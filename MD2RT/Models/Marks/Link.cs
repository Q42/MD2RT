using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class Link : Mark
{
  public Link(HtmlNode node) : base("link")
  {
    Attrs = new LinkAttributes
    {
      Target = node.Attributes.FirstOrDefault(a => a.Name == "target")?.Value,
      Href = node.Attributes.FirstOrDefault(a => a.Name == "href")?.Value
    };
  }

  public new LinkAttributes? Attrs { get; }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode($"<a href='{Attrs?.Href}' target='{Attrs?.Target}'></a>");
  }

  public new bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
