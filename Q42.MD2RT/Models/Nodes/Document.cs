using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

public class Document : Node
{
  public Document() : base("doc")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<html></html>").AppendChild(HtmlNode.CreateNode("<body></body>"));
  }
}
