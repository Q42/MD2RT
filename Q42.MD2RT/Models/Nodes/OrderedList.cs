using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

public class OrderedList : Node
{
  public OrderedList() : base("orderedList")
  {
    Attrs = new OrderedListAttributes();
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<ol></ol>");
  }
}
