using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoardGameSimulator.Classes.GameProject.BaseModules
{
    abstract class GenericGPM : IGameProjectModule
    {

#region IGameProjectModule

        public abstract ModuleType Type { get; }

        public string Name { get; set; }

        public object Tag { get; set; }

        public JObject Serialize(JsonSerializer serializer)
        {
            return JObject.FromObject(this, serializer);
        }

#endregion

    }
}
