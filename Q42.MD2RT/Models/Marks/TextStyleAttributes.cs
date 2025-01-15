namespace Q42.MD2RT.Models.Marks;

public class TextStyleAttributes : MarkAttributes
{
  public string Color { get; set; }


  public override bool Include()
  {
    return !string.IsNullOrEmpty(this.Color);
  }
}
