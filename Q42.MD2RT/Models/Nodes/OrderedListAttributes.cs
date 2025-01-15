namespace Q42.MD2RT.Models.Nodes;

public class OrderedListAttributes : NodeAttributes
{
  public int Start { get; set; } = 1;

  public override bool Include()
  {
    return true;
  }
}
