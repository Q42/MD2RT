using HtmlAgilityPack;
using Q42.MD2RT.Models.Marks;
using Q42.MD2RT.Models;

namespace Q42.MD2RT.Factories;

internal static class MarkFactory
{
  public static Mark? Get(HtmlNode node)
  {
    if (node.Name is "strong" or "b")
    {
      return new Bold();
    }

    if (node.ParentNode.Name != "pre" && node.Name == "code")
    {
      return new Code();
    }

    switch (node.Name)
    {
      case "em":
      case "i":
        return new Italic();
      case "a":
        return new Link(node);
      case "strike":
      case "s":
      case "del":
        return new Strike();
      case "sub":
        return new Subscript();
      case "sup":
        return new Superscript();
      default:
      {
        if (node.Attributes.Any(a => a.Name == "style") && TextStyle.GetAttrs(node) != null)
        {
          return new TextStyle(node);
        }

        if (node.Name == "u")
        {
          return new Underline();
        }

        break;
      }
    }

    return null;
  }
}
