using HtmlAgilityPack;
using MD2RT.Models;

namespace MD2RT.Builders;

public interface INodeBuilder
{
  bool AppliesToHtmlNode(HtmlNode htmlNode);
  Node BuildNode(HtmlNode htmlNode);
}
