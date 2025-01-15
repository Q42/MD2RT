using HtmlAgilityPack;
using Q42.MD2RT.Models;
using Q42.MD2RT.Models.Nodes;

namespace Q42.MD2RT.Builders;

public class TextNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "#text";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new TextNode(htmlNode);
  }
}
