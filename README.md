# Markdown to Rich Text

A C# library that can be used to transform Mardown to [Tiptap](https://github.com/ueberdosis/tiptap)
compatible rich-text JSON. Built upon [ProseMirror.Model](https://github.com/Holoon/ProseMirror.Model)

## Usage

Simple case where you can convert a Markdown JSON string into rich-text JSON:

```csharp
const string markdownString = "\"**Bold**\"";
var richText = MD2RT.MD2RT.ToRichText(markdownString); // Or: .ToRichText("**bold**", isJsonString: false);
var json = JsonConvert.DeserializeObject<string>(richText)!;
var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
Console.WriteLine($"markdown:\n{markdownString}\n\nrich text:\n{JsonConvert.SerializeObject(obj, Formatting.Indented)}");
```

Which will print:

```
markdown:
"**Bold**"

rich text:
{
  "type": "doc",
  "content": [
    {
      "type": "paragraph",
      "content": [
        {
          "text": "Bold",
          "type": "text",
          "marks": [
            {
              "type": "bold"
            }
          ]
        }
      ]
    }
  ]
}
```

Or replace all properties (recursively!) that have an attribute `[UIHint("markdown")]` above it, 
and rewrite the rich-text value to another property. For example, running the code:

```csharp
var page = new Page();

Console.WriteLine("Before processing");
Console.WriteLine($"  TextRt       : {page.TextRt}");
Console.WriteLine($"  NestedTextRt : {page.Components.First().NestedTextRt}\n");

MD2RT.MD2RT.Process(page, "markdown", "rich-text", "Rt");

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
```

will print:

```
Before processing
  TextRt       : 
  NestedTextRt : 

Written rich-text to 'TextRt' from markdown 'Text'
Written rich-text to 'NestedTextRt' from markdown 'NestedText'

After processing
  TextRt       : "{\"type\":\"doc\",\"content\":[{\"type\":\"paragraph\",\"content\":[{\"text\":\"Bold\",\"type\":\"text\",\"marks\":[{\"type\":\"bold\"}]}]}]}"
  NestedTextRt : "{\"type\":\"doc\",\"content\":[{\"type\":\"paragraph\",\"content\":[{\"text\":\"Italic\",\"type\":\"text\",\"marks\":[{\"type\":\"italic\"}]}]}]}"
```
