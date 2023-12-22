using HtmlAgilityPack;

namespace MD2RT.Models.Nodes;

public class BulletList : Node
{
  public BulletList() : base("bulletList")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<ul></ul>");
  }
}
