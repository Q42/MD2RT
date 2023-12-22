using HtmlAgilityPack;

namespace MD2RT.Models;

public abstract class Node
{
  public string Type { get; }
  public NodeAttributes? Attrs { get; protected set; }
  public IEnumerable<Node>? Content { get; set; }
  public IEnumerable<Mark>? Marks { get; set; }

  protected Node(string type)
  {
    Type = type;
  }

  public abstract HtmlNode RenderHtmlNode();

  public bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
