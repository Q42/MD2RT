namespace MD2RT.Models.Nodes;

public class HeadingAttributes : NodeAttributes
{
  public int? Level { get; set; }
  public string? TextAlign { get; set; }

  public override bool Include()
  {
    return !string.IsNullOrEmpty(this.TextAlign) || this.Level.HasValue;
  }
}
