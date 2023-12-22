using HtmlAgilityPack;

namespace MD2RT.Models.Marks;

public class Strike : Mark
{
  public Strike() : base("strike")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<s></s>");
  }
}
