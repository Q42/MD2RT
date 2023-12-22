using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MD2RT.Tests;

public class MD2RTTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public MD2RTTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void RegularText_Test()
  {
    AssertEqual(
      "\"Regular\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"Regular\\\"}]}]}\""
    );
  }

  [Fact]
  public void BoldText_Test()
  {
    AssertEqual(
      "\"**Bold**\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"marks\\\":[{\\\"type\\\":\\\"bold\\\"}],\\\"text\\\":\\\"Bold\\\"}]}]}\""
    );
  }

  [Fact]
  public void Underlined_Test()
  {
    AssertEqual(
      "\"<u>underlined</u>\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"marks\\\":[{\\\"type\\\":\\\"underline\\\"}],\\\"text\\\":\\\"underlined\\\"}]}]}\""
    );
  }

  [Fact]
  public void Heading_Test()
  {
    AssertEqual(
      "\"# h1\\n\\n## h2\\n\\n### h3\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"heading\\\",\\\"attrs\\\":{\\\"level\\\":1},\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"h1\\\"}]},{\\\"type\\\":\\\"heading\\\",\\\"attrs\\\":{\\\"level\\\":2},\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"h2\\\"}]},{\\\"type\\\":\\\"heading\\\",\\\"attrs\\\":{\\\"level\\\":3},\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"h3\\\"}]}]}\""
    );
  }

  [Fact]
  public void Quote_Test()
  {
    AssertEqual(
      "\"> Quote spanning multiple lines\\n> \\n> -- a person\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"blockquote\\\",\\\"content\\\":[{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"Quote spanning multiple lines\\\"}]},{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"-- a person\\\"}]}]}]}\""
    );
  }

  [Fact]
  public void Link_Test()
  {
    AssertEqual(
      "\"[Link][1]\\n\\n\\n  [1]: http://www.q42.nl\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"marks\\\":[{\\\"type\\\":\\\"link\\\",\\\"attrs\\\":{\\\"href\\\":\\\"http://www.q42.nl\\\",\\\"target\\\":null,\\\"class\\\":null}}],\\\"text\\\":\\\"Link\\\"}]}]}\""
    );
  }

  [Fact]
  public void MixedText_Test()
  {
    AssertEqual(
      "\"# Head\\n\\nRegular\\n\\n**Bold**\\n\\n*Italic*\"",
      "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"heading\\\",\\\"attrs\\\":{\\\"level\\\":1},\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"Head\\\"}]},{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"Regular\\\"}]},{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"marks\\\":[{\\\"type\\\":\\\"bold\\\"}],\\\"text\\\":\\\"Bold\\\"}]},{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"marks\\\":[{\\\"type\\\":\\\"italic\\\"}],\\\"text\\\":\\\"Italic\\\"}]}]}\""
    );
  }

  private void AssertEqual(string markdown, string expectedRichTextJson)
  {
    var markdownJson = MD2RT.ToRichText(markdown);

    var markdownJsonString = JsonConvert.DeserializeObject<string>(markdownJson)!;
    var expectedRichTextJsonString = JsonConvert.DeserializeObject<string>(expectedRichTextJson)!;

    var jObjectMarkdown = JsonConvert.DeserializeObject<JObject>(markdownJsonString);
    var jObjectRichText = JsonConvert.DeserializeObject<JObject>(expectedRichTextJsonString);

    try
    {
      Assert.True(DeepEquals(jObjectMarkdown, jObjectRichText));
    }
    catch
    {
      this.testOutputHelper.WriteLine($"markdown:\n{JsonConvert.SerializeObject(jObjectMarkdown, Formatting.Indented)}");
      this.testOutputHelper.WriteLine($"\nrich text:\n{JsonConvert.SerializeObject(jObjectRichText, Formatting.Indented)}");

      throw;
    }
  }

  private static bool DeepEquals(JToken? markdownToken, JToken? richTextToken)
  {
    if (markdownToken == null && richTextToken == null)
      return true;

    if (markdownToken != null && richTextToken == null)
      throw new NullException(nameof(richTextToken));

    if (markdownToken == null && richTextToken != null)
      throw new NullException(nameof(markdownToken));

    if (markdownToken is JObject markdownObject && richTextToken is JObject richTextObject)
    {
      var markdownChildren = markdownObject.Children().OrderBy(t => $"{t}").ToArray();
      var richTextChildren = richTextObject.Children().OrderBy(t => $"{t}").ToArray();

      var markdownKeys = markdownChildren.Select(t => t as JProperty).Select(p => p!.Name).ToHashSet();
      var richTextKeys = richTextChildren.Select(t => t as JProperty).Select(p => p!.Name).ToHashSet();

      if (!markdownKeys.SetEquals(richTextKeys))
      {
        throw new Exception($"[{string.Join(", ", markdownKeys)}] != [{string.Join(", ", richTextKeys)}]");
      }

      for (var i = 0; i < markdownChildren.Length; i++)
      {
        DeepEquals(markdownChildren[i], richTextChildren[i]);
      }
    }
    else if (markdownToken is JArray markdownValueArray && richTextToken is JArray richTextArray)
    {
      var markdownValueArraySorted = markdownValueArray.OrderBy(t => $"{t}").ToArray();
      var richTextArraySorted = richTextArray.OrderBy(t => $"{t}").ToArray();

      for (var i = 0; i < markdownValueArraySorted.Length; i++)
      {
        DeepEquals(markdownValueArraySorted[i], richTextArraySorted[i]);
      }
    }
    else if (markdownToken is JProperty markdownProperty && richTextToken is JProperty richTextProperty)
    {
      return DeepEquals(markdownProperty.Value, richTextProperty.Value);
    }
    else if (markdownToken is JValue markdownValue && richTextToken is JValue richTextValue)
    {
      var markdownActualValue = markdownValue.Value;
      var richTextActualValue = richTextValue.Value;

      if (markdownActualValue != richTextActualValue && markdownActualValue?.Equals(richTextActualValue) != true)
      {
        throw new Exception($"{markdownToken} != {richTextToken}");
      }
    }
    else
    {
      throw new Exception($"Did not account for comparison of {markdownToken!.GetType()} and {richTextToken!.GetType()}");
    }

    return true;
  }
}
