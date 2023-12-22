namespace MD2RT.Models.Nodes;

public class ImageAttributes : NodeAttributes
{
  public string? Alt { get; set; }

  public string? Src { get; set; }

  public string? Title { get; set; }

  public int? Width { get; set; }

  public override bool Include()
  {
    return !string.IsNullOrEmpty(this.Alt) || !string.IsNullOrEmpty(this.Src) || !string.IsNullOrEmpty(this.Title) || this.Width.HasValue;
  }
}
