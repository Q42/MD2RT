using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Marks;

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
