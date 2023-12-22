using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class BlockQuoteNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "blockquote";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new Blockquote();
  }
}
