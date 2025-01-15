using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

// const string markdownString = "\"**Bold**\"";
// var richText = Q42.MD2RT.MD2RT.ToRichText(markdownString); // Or: Q42.MD2RT.MD2RT.ToRichText("**bold**", isJsonString: false);
// var json = JsonConvert.DeserializeObject<string>(richText)!;
// var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
// Console.WriteLine($"markdown:\n{markdownString}\n\nrich text:\n{JsonConvert.SerializeObject(obj, Formatting.Indented)}");

var page = new Page();

Console.WriteLine("Before processing");
Console.WriteLine($"  TextRt       : {page.TextRt}");
Console.WriteLine($"  NestedTextRt : {page.Components.First().NestedTextRt}\n");

Q42.MD2RT.MD2RT.Process(page, "markdown", "rich-text", "Rt");

Console.WriteLine("\nAfter processing");
Console.WriteLine($"  TextRt       : {page.TextRt}");
Console.WriteLine($"  NestedTextRt : {page.Components.First().NestedTextRt}");

public class Page
{
  [UIHint("markdown")]
  public string Text { get; set; } = "\"**Bold**\"";

  [UIHint("rich-text")]
  public string TextRt { get; set; } = "";

  public List<Component> Components { get; set; } = new() { new Component() };

  public List<Component>? NullComponents { get; set; }

  public string StringProp1 { get; set; } = "to be ignored 1";

  public String StringProp2 { get; set; } = "to be ignored 2";
}

public class Component
{
  [UIHint("markdown")]
  public string NestedText { get; set; } = "\"*Italic*\"";

  [UIHint("rich-text")]
  public string NestedTextRt { get; set; } = "";
}
