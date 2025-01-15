using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

public class HorizontalRule : Node
{
  public HorizontalRule() : base("horizontalRule")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<hr></hr>");
  }
}
