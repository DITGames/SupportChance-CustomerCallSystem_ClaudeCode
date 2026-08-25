using SupportChance_CustomerCallSystem_ClaudeCode.Services;

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    public partial class CustomerForm : Form
    {
        private static readonly Color NormalColor = Color.White;
        private static readonly Color HighlightColor = Color.Yellow;

        private readonly CallQueueManager _manager;
        private bool _allowClose;

        public CustomerForm(CallQueueManager manager)
        {
            _manager = manager;

            InitializeComponent();

            flowCalled.Resize += (_, _) => ResizeLabelsToFit();
            FormClosing += CustomerForm_FormClosing;

            _manager.CalledListChanged += RefreshCalled;
            _manager.NumberRecalled += OnNumberRecalled;

            RefreshCalled();
        }

        public void AllowCloseAndClose()
        {
            _allowClose = true;
            Close();
        }

        private void RefreshCalled()
        {
            flowCalled.SuspendLayout();
            flowCalled.Controls.Clear();

            foreach (var number in _manager.Called)
            {
                var label = new Label
                {
                    Tag = number,
                    Text = number.ToString(),
                    AutoSize = false,
                    Width = flowCalled.ClientSize.Width,
                    Height = 160,
                    Font = new Font("Yu Gothic UI", 64F, FontStyle.Bold),
                    ForeColor = NormalColor,
                    BackColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                flowCalled.Controls.Add(label);
            }

            flowCalled.ResumeLayout(true);
        }

        private void ResizeLabelsToFit()
        {
            foreach (Control control in flowCalled.Controls)
            {
                control.Width = flowCalled.ClientSize.Width;
            }
        }

        private void OnNumberRecalled(int number)
        {
            var label = flowCalled.Controls
                .Cast<Control>()
                .FirstOrDefault(c => c.Tag is int tagNumber && tagNumber == number) as Label;
            if (label == null) return;

            label.ForeColor = HighlightColor;
            var timer = new System.Windows.Forms.Timer { Interval = 3000 };
            timer.Tick += (_, _) =>
            {
                label.ForeColor = NormalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void CustomerForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_allowClose) e.Cancel = true;
        }
    }
}
