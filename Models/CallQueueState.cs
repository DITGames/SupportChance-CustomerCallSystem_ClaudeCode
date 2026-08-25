namespace SupportChance_CustomerCallSystem_ClaudeCode.Models
{
    public class CallQueueState
    {
        public List<int> Waiting { get; set; } = new();

        public List<int> Called { get; set; } = new();
    }
}
