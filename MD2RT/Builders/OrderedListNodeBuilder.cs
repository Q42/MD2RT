using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class OrderedListNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "ol";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new OrderedList();
  }
}
