using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class LinkAttributes : MarkAttributes
{
  public string Target { get; set; }
  public string Href { get; set; }
  public override bool Include()
  {
    return !string.IsNullOrEmpty(this.Target) || !string.IsNullOrEmpty(this.Href);
  }
}

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

  public new LinkAttributes Attrs { get; protected set; }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode($"<a href='{Attrs?.Href}' target='{Attrs?.Target}'></a>");
  }

  public bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
