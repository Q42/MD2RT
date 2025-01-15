using HtmlAgilityPack;
using Q42.MD2RT.Models;

namespace Q42.MD2RT.Builders;

public interface INodeBuilder
{
  bool AppliesToHtmlNode(HtmlNode htmlNode);
  Node BuildNode(HtmlNode htmlNode);
}
