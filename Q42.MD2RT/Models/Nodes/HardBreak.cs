using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

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
