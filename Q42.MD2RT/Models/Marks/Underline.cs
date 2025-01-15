using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Marks;

public class Underline : Mark
{
  public Underline() : base("underline")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<u></u>");
  }
}
