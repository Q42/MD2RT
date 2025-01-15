using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

public class TableHeader : TableCell
{
  public TableHeader(HtmlNode node) : base(node, "tableHeader")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    var tag = base.RenderHtmlNode();

    tag.Name = "th";

    return tag;
  }
}
