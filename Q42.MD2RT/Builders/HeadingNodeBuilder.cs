using HtmlAgilityPack;
using Q42.MD2RT.Models;
using Q42.MD2RT.Models.Nodes;

namespace Q42.MD2RT.Builders;

public class HeadingNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "h1" || htmlNode.Name == "h2" || htmlNode.Name == "h3" || htmlNode.Name == "h4" ||
           htmlNode.Name == "h5" || htmlNode.Name == "h6";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new Heading(htmlNode);
  }
}
