using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoardGameSimulator.Classes.GameProject
{
    class GameProject
    {

#region Static fields

        private static readonly JsonSerializer _serializer;

#endregion

#region Private fields

        private readonly Dictionary<ModuleType, List<IGameProjectModule>> _submodulesSet;

        private string _absProjectPath;

#endregion

#region Static ctor

        static GameProject()
        {
            _serializer = new JsonSerializer();
        }

#endregion

#region Ctor

        public GameProject()
        {
            _submodulesSet = new Dictionary<ModuleType, List<IGameProjectModule>>();
        }

#endregion

#region Class methods

        private List<IGameProjectModule> GetModuleList(ModuleType type)
        {
            List<IGameProjectModule> modulesList;
            return _submodulesSet.TryGetValue(type, out modulesList) ? modulesList : null;
        }

        private void AssertModuleParam(IGameProjectModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException("module");
            }
        }

        public bool RegisterModule(IGameProjectModule module)
        {
            AssertModuleParam(module);

            List<IGameProjectModule> moduleList;
            if (!_submodulesSet.TryGetValue(module.Type, out moduleList))
            {
                moduleList = new List<IGameProjectModule>();
                _submodulesSet.Add(module.Type, moduleList);
            }

            if (!moduleList.Contains(module))
            {
                moduleList.Add(module);
                return true;
            }

            return false;
        }

        public bool RemoveModule(IGameProjectModule module)
        {
            AssertModuleParam(module);

            List<IGameProjectModule> moduleList = GetModuleList(module.Type);
            return moduleList != null && moduleList.Remove(module);
        }

        public ReadOnlyCollection<IGameProjectModule> GetModules(ModuleType type)
        {
            return GetModuleList(type).AsReadOnly();
        }

#endregion

#region IGameProjectModule

        public JObject Serialize(JsonSerializer serializer)
        {
            JObject joResult = new JObject();

            foreach (ModuleType type in _submodulesSet.Keys)
            {
                string typeName = type.ToString();
                List<IGameProjectModule> moduleList = GetModuleList(type);
                foreach (IGameProjectModule module in moduleList)
                {
                    JObject joModule =  module.Serialize(_serializer);
                    joResult.Add(typeName, joModule);
                }
            }
            
            throw new System.NotImplementedException();
        }

#endregion

    }
}