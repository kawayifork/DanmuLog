using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Reflection;

namespace DanmuLog
{
    public class PluginSettings : INotifyPropertyChanged
    {
        public string ConfigPath;

        public PluginSettings(string configPath)
        {
            ConfigPath = configPath;
        }
        public void SaveConfig()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this));
        }
        public void LoadConfig()
        {  
            if (File.Exists(ConfigPath))
            {
                Type Settings = this.GetType();
                object Config = JsonConvert.DeserializeObject(File.ReadAllText(ConfigPath),Settings);
               foreach(PropertyInfo prop in Settings.GetProperties())
               {
                    prop.SetValue(this, prop.GetValue(Config));
               }   
            }
        }
        private bool enabled;
        public bool Enabled { get => enabled; set { if (enabled != value) { enabled = value; OnPropertyChanged(); } } }
        private bool danmuLog = true;
        public bool DanmuLog { get => danmuLog; set { if (danmuLog != value) { danmuLog = value; OnPropertyChanged(); } } }
        private bool danmuData = false;
        public bool DanmuData { get => danmuData; set { if (danmuData != value) { danmuData = value; OnPropertyChanged(); } } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            SaveConfig();
        }       
    }
}
