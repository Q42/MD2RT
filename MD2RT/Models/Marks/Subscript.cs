using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class Subscript : Mark
{
  public Subscript() : base("subscript")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<sub></sub>");
  }
}
