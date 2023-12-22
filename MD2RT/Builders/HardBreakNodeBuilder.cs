using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

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
