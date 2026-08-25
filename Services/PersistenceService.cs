using System.Text.Json;
using SupportChance_CustomerCallSystem_ClaudeCode.Models;

namespace SupportChance_CustomerCallSystem_ClaudeCode.Services
{
    public class PersistenceService
    {
        private static readonly string Dir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SupportChanceCallSystem");

        private static readonly string StatePath = Path.Combine(Dir, "state.json");

        public CallQueueState Load()
        {
            try
            {
                if (!File.Exists(StatePath)) return new CallQueueState();
                var json = File.ReadAllText(StatePath);
                return JsonSerializer.Deserialize<CallQueueState>(json) ?? new CallQueueState();
            }
            catch
            {
                return new CallQueueState();
            }
        }

        public void Save(CallQueueState state)
        {
            Directory.CreateDirectory(Dir);
            File.WriteAllText(StatePath, JsonSerializer.Serialize(state));
        }
    }
}
