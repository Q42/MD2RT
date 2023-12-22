using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class Bold : Mark
{
  public Bold() : base("bold")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<strong></strong>");
  }
}
