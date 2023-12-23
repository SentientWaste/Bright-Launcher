using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Reflection;
using System.Collections.Generic;
using Bright_Launcher.Classes.Datas;
using CommunityToolkit.Mvvm.Messaging;
using Bright_Launcher.Classes.Datas.Messaging;
using MinecraftLaunch.Utilities;

namespace Bright_Launcher.Services.Setting {
    public class SettingService {
        private IEnumerable<PropertyInfo> _properties;

        public SettingData Data { get; set; }

        public readonly string DataFilePath = Path.Combine(Environment.CurrentDirectory, 
            "setting.json");

        public SettingService() {
            Load();
        }

        private void Load() {
            if (File.Exists(DataFilePath)) {
                string json = File.ReadAllText(DataFilePath);
                Data = JsonSerializer.Deserialize<SettingData>(json, JsonConverterUtil
                    .DefaultJsonConverterOptions)!;
            } else {
                Save();
                Data = new();
            }

            var properties = Data.GetType().GetProperties().ToDictionary(p => p.Name, p => p);
            WeakReferenceMessenger.Default.Register<PropertyChangedMessage>(this, (obj, message) => {
                if (properties.TryGetValue(message.Name, out var propertyInfo)) {
                    propertyInfo.SetValue(Data, message.Value);
                }
            });
        }

        public void Save() {
            var json = JsonSerializer.Serialize(Data ?? new());
            File.WriteAllText(DataFilePath, json);
        }
    }
}
