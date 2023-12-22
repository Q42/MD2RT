using HtmlAgilityPack;
using MD2RT.Builders;
using MD2RT.Models;

namespace MD2RT.Factories;

internal static class NodeFactory
{
  private static readonly IEnumerable<INodeBuilder> _defaultNodeBuilders = new INodeBuilder[]
  {
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
    new TextNodeBuilder(),
  };

  public static Node? Get(HtmlNode htmlNode, IEnumerable<INodeBuilder>? customNodeBuilders = null)
  {
    customNodeBuilders ??= Enumerable.Empty<INodeBuilder>();
    var nodeBuilders = customNodeBuilders.Concat(_defaultNodeBuilders);
    var noteBuilder = nodeBuilders.FirstOrDefault(builder => builder.AppliesToHtmlNode(htmlNode));

    return noteBuilder?.BuildNode(htmlNode);
  }
}
