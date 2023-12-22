using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class HorizontalRuleNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "hr";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new HorizontalRule();
  }
}
