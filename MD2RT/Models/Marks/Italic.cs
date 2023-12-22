using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

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
