using HtmlAgilityPack;

namespace MD2RT.Models.Nodes;

public class HardBreak : Node
{
  public HardBreak() : base("hardBreak")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<br></br>");
  }
}
