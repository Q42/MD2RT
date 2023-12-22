using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class TableCellNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "td";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new TableCell(htmlNode);
  }
}
