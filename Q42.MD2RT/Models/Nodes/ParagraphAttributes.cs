namespace Q42.MD2RT.Models.Nodes;

public class ParagraphAttributes : NodeAttributes
{
  public string? TextAlign { get; set; }

  public override bool Include()
  {
    return !string.IsNullOrEmpty(this.TextAlign);
  }
}
