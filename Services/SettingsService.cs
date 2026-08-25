using System.Text.Json;
using SupportChance_CustomerCallSystem_ClaudeCode.Models;

namespace SupportChance_CustomerCallSystem_ClaudeCode.Services
{
    public class SettingsService
    {
        private static readonly string Dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SupportChanceCallSystem");

        private static readonly string SettingsPath = Path.Combine(Dir, "settings.json");

        public AppSettings Load()
        {
            try
            {
                if (!File.Exists(SettingsPath)) return new AppSettings();
                var json = File.ReadAllText(SettingsPath);
                return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            catch
            {
                return new AppSettings();
            }
        }

        public void Save(AppSettings settings)
        {
            Directory.CreateDirectory(Dir);
            File.WriteAllText(SettingsPath, JsonSerializer.Serialize(settings));
        }
    }
}
