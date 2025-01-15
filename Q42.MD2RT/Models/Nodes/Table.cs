using HtmlAgilityPack;

namespace Q42.MD2RT.Models.Nodes;

public class Table : Node
{
  public Table() : base("table")
  {
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode("<table></table>").AppendChild(HtmlNode.CreateNode("<tbody></tbody>"));
  }
}
