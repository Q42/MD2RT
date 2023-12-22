using HtmlAgilityPack;

namespace MD2RT.Models.Nodes;

public class Blockquote : Node
{
  public Blockquote() : base("blockquote")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<blockquote></blockquote>");
  }
}
