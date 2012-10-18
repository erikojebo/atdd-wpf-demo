using System;
using System.IO;
using System.Reflection;
using System.Text;
using AtddDemo.Settings;

namespace AtddDemo.Services
{
    public class SettingsService
    {
        public const string SettingsFileName = "settings.ini";

        public void Save(ServerSettings serverSettings)
        {
            var settingsFilePath = GetSettingsFilePath();

            File.WriteAllText(settingsFilePath, WriteToString(serverSettings));
        }

        private static string GetSettingsFilePath()
        {
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(assemblyDirectory, SettingsFileName);
        }

        public string WriteToString(ServerSettings serverSettings)
        {
            var sb = new StringBuilder();

            sb.AppendFormatLine(@"server={0}", serverSettings.ServerIp);
            sb.AppendFormatLine(@"port={0}", serverSettings.Port);
            sb.AppendLine(";Timeout in seconds");
            sb.AppendFormatLine(@"timeout={0}", serverSettings.TimeoutInSeconds);

            return sb.ToString();
        }

        public ServerSettings Load()
        {
            var settingsFilePath = GetSettingsFilePath();

            var fileContents = File.ReadAllText(settingsFilePath);

            return Parse(fileContents);
        }

        public ServerSettings Parse(string fileContents)
        {
            var settings = new ServerSettings();

            var lines = fileContents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                ParseLine(line, settings);    
            }

            return settings;
        }

        private void ParseLine(string line, ServerSettings settings)
        {
            if (line.StartsWith("server"))
                settings.ServerIp = StripLabel(line);
            else if (line.StartsWith("port"))
                settings.Port = int.Parse(StripLabel(line));
            else if (line.StartsWith("timeout"))
                settings.TimeoutInSeconds = int.Parse(StripLabel(line));
        }

        private string StripLabel(string input)
        {
            var parts = input.Split('=');
            return parts[1];
        }
    }
}