using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class BulletListNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "ul";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new BulletList();
  }
}
