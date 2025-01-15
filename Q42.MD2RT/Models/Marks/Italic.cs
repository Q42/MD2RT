using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Marks;

public class Italic : Mark
{
  public Italic() : base("italic")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<em></em>");
  }
}
