using HtmlAgilityPack;
using Q42.MD2RT.Models;
using Q42.MD2RT.Models.Nodes;

namespace Q42.MD2RT.Builders;

public class ParagraphNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "p";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new Paragraph(htmlNode);
  }
}
