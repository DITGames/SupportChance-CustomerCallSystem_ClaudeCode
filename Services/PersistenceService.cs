using System.Text.Json;
using SupportChance_CustomerCallSystem_ClaudeCode.Models;

namespace SupportChance_CustomerCallSystem_ClaudeCode.Services
{
    public class PersistenceService
    {
        // 実行ファイルと同じフォルダ配下の "data" にデータを保存する。
        // (アプリのフォルダごと移動・バックアップすればデータも一緒についてくる)
        private static readonly string Dir = Path.Combine(AppContext.BaseDirectory, "data");

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
