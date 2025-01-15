using HtmlAgilityPack;

namespace Q42.MD2RT.Models;

public abstract class Mark
{
  public string Type { get; }

  public MarkAttributes? Attrs { get; set; }

  protected Mark(string type)
  {
    Type = type;
  }

  public abstract HtmlNode RenderHtmlNode();

  public bool ShouldSerializeAttrs()
  {
    return this.Attrs?.Include() == true;
  }
}
