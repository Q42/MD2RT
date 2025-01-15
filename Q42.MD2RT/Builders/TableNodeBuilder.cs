using HtmlAgilityPack;
using Q42.MD2RT.Models;
using Q42.MD2RT.Models.Nodes;

namespace Q42.MD2RT.Builders;

public class TableNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "table" && !htmlNode.Descendants("tbody").Any() ||
           htmlNode.Name == "tbody" && htmlNode.ParentNode.Name == "table";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new Table();
  }
}
