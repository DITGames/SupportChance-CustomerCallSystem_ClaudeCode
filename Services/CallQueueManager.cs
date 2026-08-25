using SupportChance_CustomerCallSystem_ClaudeCode.Models;

namespace SupportChance_CustomerCallSystem_ClaudeCode.Services
{
    public class CallQueueManager
    {
        private readonly List<int> _waiting;
        private readonly List<int> _called;

        public event Action? WaitingListChanged;
        public event Action? CalledListChanged;
        public event Action<int>? NumberRecalled;

        public IReadOnlyList<int> Waiting => _waiting;
        public IReadOnlyList<int> Called => _called;

        public CallQueueManager(CallQueueState initial)
        {
            _waiting = new List<int>(initial.Waiting);
            _called = new List<int>(initial.Called);
        }

        public bool TryAdd(int number, out string? error)
        {
            if (_waiting.Contains(number) || _called.Contains(number))
            {
                error = $"番号 {number} は既に登録されています。";
                return false;
            }

            _waiting.Add(number);
            error = null;
            WaitingListChanged?.Invoke();
            return true;
        }

        public void CancelWaiting(int number)
        {
            if (_waiting.Remove(number)) WaitingListChanged?.Invoke();
        }

        public void Call(int number)
        {
            if (!_waiting.Remove(number)) return;
            _called.Insert(0, number);
            WaitingListChanged?.Invoke();
            CalledListChanged?.Invoke();
        }

        public void Recall(int number)
        {
            if (_called.Contains(number)) NumberRecalled?.Invoke(number);
        }

        public void CompleteCall(int number)
        {
            if (_called.Remove(number)) CalledListChanged?.Invoke();
        }

        public CallQueueState ToState() => new() { Waiting = new List<int>(_waiting), Called = new List<int>(_called) };
    }
}
