namespace BoardGameSimulator.Classes.GameProject.BaseModules
{
    abstract class FileResourceGPM : GenericGPM
    {

#region Private fields

        private string _absFilePath;

#endregion

#region Properties

        public string RelFileName { get; set; }

#endregion

#region Class methods

        protected abstract void Load(string absFilePath, string relFileName);

        protected abstract void Save();

#endregion

    }
}
