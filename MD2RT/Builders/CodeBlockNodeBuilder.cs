using HtmlAgilityPack;
using MD2RT.Models;
using MD2RT.Models.Nodes;

namespace MD2RT.Builders;

public class CodeBlockNodeBuilder : INodeBuilder
{
  public bool AppliesToHtmlNode(HtmlNode htmlNode)
  {
    return htmlNode.Name == "code" && htmlNode.ParentNode.Name == "pre";
  }

  public Node BuildNode(HtmlNode htmlNode)
  {
    return new CodeBlock();
  }
}
