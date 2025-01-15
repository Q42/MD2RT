namespace Q42.MD2RT.Models.Nodes;

public class TableCellAttributes : NodeAttributes
{
  public int? Colspan { get; set; }
  public int[]? Colwidth { get; set; }
  public int? Rowspan { get; set; }

  public override bool Include()
  {
    return this.Colspan.HasValue || this.Colwidth?.Any() == true || this.Rowspan.HasValue;
  }
}
