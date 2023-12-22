var expected = "\"{\\\"type\\\":\\\"doc\\\",\\\"content\\\":[{\\\"type\\\":\\\"paragraph\\\",\\\"content\\\":[{\\\"type\\\":\\\"text\\\",\\\"text\\\":\\\"Regular\\\"}]}]}\"";

var markdown = "\"Regular\"";

var json = MD2RT.MD2RT.ToRichText(markdown);

Console.WriteLine(json);
Console.WriteLine(expected);
