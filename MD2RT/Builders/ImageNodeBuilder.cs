using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class ImageNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "img";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new Image(htmlNode);
  }
}
