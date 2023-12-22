using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class Superscript : Mark
{
  public Superscript() : base("superscript")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<sup></sup>");
  }
}
