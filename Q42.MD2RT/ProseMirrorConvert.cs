using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Q42.MD2RT.Builders;
using Q42.MD2RT.Models;

namespace Q42.MD2RT;

public static class ProseMirrorConvert
{
  public static string SerializeToHtml(Node rootNode)
  {
    return new HtmlConverter().Convert(rootNode);
  }

  public static string SerializeToJson(Node rootNode)
  {
    return JsonConvert.SerializeObject(rootNode, new JsonSerializerSettings
    {
      ContractResolver = new CamelCasePropertyNamesContractResolver(),
      NullValueHandling = NullValueHandling.Ignore,
      TypeNameHandling = TypeNameHandling.None
    });
  }

  public static Node DeserializeObjectFromHtml(
    string html,
    IEnumerable<INodeBuilder>? customNodeBuilders = null)
  {
    return new HtmlConverter(customNodeBuilders).Convert(html);
  }

  public static Node DeserializeObjectFromJson(string json)
  {
    return JsonConvert.DeserializeObject<Node>(json) ?? throw new ArgumentException($"Cannot deserialize JSON to Node: '{json}'");
  }
}
