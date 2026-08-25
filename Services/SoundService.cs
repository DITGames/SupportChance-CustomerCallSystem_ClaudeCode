namespace SupportChance_CustomerCallSystem_ClaudeCode.Services
{
    public static class SoundService
    {
        public static void Play(string? wavPath, Action<string> onError)
        {
            if (string.IsNullOrWhiteSpace(wavPath) || !File.Exists(wavPath))
            {
                onError("音声ファイルが設定されていないか見つかりません。");
                return;
            }

            try
            {
                var player = new System.Media.SoundPlayer(wavPath);
                player.Play();
            }
            catch (Exception ex)
            {
                onError($"音声の再生に失敗しました: {ex.Message}");
            }
        }
    }
}
