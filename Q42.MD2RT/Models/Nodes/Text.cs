using HtmlAgilityPack;
using System.Net;

namespace Q42.MD2RT.Models.Nodes;

public class TextNode : Node
{
  public string Text { get; set; }

  public TextNode(HtmlNode node) : base("text")
  {
    Text = WebUtility.HtmlDecode(node.InnerText.TrimStart('\n'));
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode(WebUtility.HtmlEncode(Text));
  }
}
