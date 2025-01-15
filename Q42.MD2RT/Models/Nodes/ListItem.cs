using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

public class ListItem : Node
{
  public ListItem() : base("listItem")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<li></li>");
  }
}
