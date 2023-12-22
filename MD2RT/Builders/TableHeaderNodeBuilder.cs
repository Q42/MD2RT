using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class TableHeaderNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "th";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new TableHeader(htmlNode);
  }
}
