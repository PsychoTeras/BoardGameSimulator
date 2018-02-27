using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoardGameSimulator.Classes.GameProject.Modules
{
    class BackgroundGPM : IGameProjectModule
    {

#region IGameProjectModule

        public ModuleType Type
        {
            get { return ModuleType.Background; }
        }

        public string Name { get; set; }

        public object Tag { get; set; }

        public JObject Serialize(JsonSerializer serializer)
        {
            return JObject.FromObject(this, serializer);
        }

#endregion

    }
}