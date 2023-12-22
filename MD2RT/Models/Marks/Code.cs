using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class Code : Mark
{
  public Code() : base("code")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<pre></pre>");
  }
}
