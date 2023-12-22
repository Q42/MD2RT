using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace MD2RT.Models.Nodes;

public class Heading : Node
{
  public Heading(HtmlNode node) : base("heading")
  {
    Attrs = new HeadingAttributes
    {
      Level = GetLevel(node.Name)
    };
  }

  public new HeadingAttributes? Attrs { get; }

  private static int? GetLevel(string tagName)
  {
    var match = Regex.Match(tagName, "^h([1-6])$");
    return match.Success ? Convert.ToInt32(match.Groups[1].Value) : null;
  }

  public override HtmlNode RenderHtmlNode()
  {
    return HtmlNode.CreateNode($"<h{Attrs?.Level}></h{Attrs?.Level}>");
  }

  public new bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
