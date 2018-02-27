using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoardGameSimulator.Classes.GameProject
{
    interface IGameProjectModule
    {
        ModuleType Type { get; }
        string Name { get; set; }
        object Tag { get; set; }
        JObject Serialize(JsonSerializer serializer);
    }
}