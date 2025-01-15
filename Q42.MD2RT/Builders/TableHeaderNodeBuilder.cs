using HtmlAgilityPack;
using Q42.MD2RT.Models;
using Q42.MD2RT.Models.Nodes;

namespace Q42.MD2RT.Builders;

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
