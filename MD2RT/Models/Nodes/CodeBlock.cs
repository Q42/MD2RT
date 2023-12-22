using HtmlAgilityPack;

namespace MD2RT.Models.Nodes;

public class CodeBlock : Node
{
  public CodeBlock() : base("codeBlock")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<code></code>");
  }
}
