using HtmlAgilityPack;
using Q42.MD2RT.Builders;
using Q42.MD2RT.Models;

namespace Q42.MD2RT.Factories;

internal static class NodeFactory
{
  private static readonly IEnumerable<INodeBuilder> _defaultNodeBuilders =
  [
    new BlockQuoteNodeBuilder(),
    new BulletListNodeBuilder(),
    new CodeBlockNodeBuilder(),
    new HardBreakNodeBuilder(),
    new HeadingNodeBuilder(),
    new HorizontalRuleNodeBuilder(),
    new ImageNodeBuilder(),
    new ListItemNodeBuilder(),
    new OrderedListNodeBuilder(),
    new ParagraphNodeBuilder(),
    new TableNodeBuilder(),
    new TableCellNodeBuilder(),
    new TableHeaderNodeBuilder(),
    new TableRowNodeBuilder(),
    new TextNodeBuilder()
  ];

  public static Node? Get(HtmlNode htmlNode, IEnumerable<INodeBuilder>? customNodeBuilders = null)
  {
    customNodeBuilders ??= [];
    var nodeBuilders = customNodeBuilders.Concat(_defaultNodeBuilders);
    var noteBuilder = nodeBuilders.FirstOrDefault(builder => builder.AppliesToHtmlNode(htmlNode));

    return noteBuilder?.BuildNode(htmlNode);
  }
}
