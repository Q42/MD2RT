using HtmlAgilityPack;
using Q42.MD2RT.Models;
using Q42.MD2RT.Models.Nodes;

namespace Q42.MD2RT.Builders;

public class HardBreakNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "br";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new HardBreak();
  }
}
