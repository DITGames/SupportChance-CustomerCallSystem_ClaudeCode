using SupportChance_CustomerCallSystem_ClaudeCode.Services;

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    public partial class CustomerForm : Form
    {
        private const int GridColumns = 6;
        private const int TileHeight = 130;
        private const int TileMargin = 8;

        private static readonly Color TileNormalColor = Color.FromArgb(250, 240, 224);
        private static readonly Color TileHighlightColor = Color.FromArgb(255, 214, 0);
        private static readonly Color TileBackColor = Color.FromArgb(92, 61, 40);
        private static readonly Color LatestNormalColor = Color.FromArgb(40, 26, 16);
        private static readonly Color LatestHighlightColor = Color.FromArgb(214, 40, 20);

        private readonly CallQueueManager _manager;
        private bool _allowClose;
        private System.Windows.Forms.Timer? _latestHighlightTimer;

        public CustomerForm(CallQueueManager manager)
        {
            _manager = manager;

            InitializeComponent();

            flowCalled.Resize += (_, _) => ResizeTilesToFit();
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
            var called = _manager.Called;

            _latestHighlightTimer?.Stop();
            _latestHighlightTimer?.Dispose();
            _latestHighlightTimer = null;

            if (called.Count > 0)
            {
                lblLatestNumber.Tag = called[0];
                lblLatestNumber.Text = called[0].ToString();
            }
            else
            {
                lblLatestNumber.Tag = null;
                lblLatestNumber.Text = "---";
            }
            lblLatestNumber.ForeColor = LatestNormalColor;

            flowCalled.SuspendLayout();
            flowCalled.Controls.Clear();

            foreach (var number in called.Skip(1))
            {
                flowCalled.Controls.Add(CreateTile(number));
            }

            flowCalled.ResumeLayout(true);
            ResizeTilesToFit();
        }

        private Label CreateTile(int number)
        {
            return new Label
            {
                Tag = number,
                Text = number.ToString(),
                AutoSize = false,
                Margin = new Padding(TileMargin),
                Width = TileWidth(),
                Height = TileHeight,
                Font = new Font("Yu Gothic UI", 40F, FontStyle.Bold),
                ForeColor = TileNormalColor,
                BackColor = TileBackColor,
                TextAlign = ContentAlignment.MiddleCenter,
            };
        }

        private int TileWidth()
        {
            var available = flowCalled.ClientSize.Width - (GridColumns * TileMargin * 2);
            return Math.Max(120, available / GridColumns);
        }

        private void ResizeTilesToFit()
        {
            var width = TileWidth();
            foreach (Control control in flowCalled.Controls)
            {
                control.Width = width;
            }
        }

        private void OnNumberRecalled(int number)
        {
            if (lblLatestNumber.Tag is int latestNumber && latestNumber == number)
            {
                HighlightLatest();
                return;
            }

            var label = flowCalled.Controls
                .Cast<Control>()
                .FirstOrDefault(c => c.Tag is int tagNumber && tagNumber == number) as Label;
            if (label == null) return;

            label.ForeColor = TileHighlightColor;
            var timer = new System.Windows.Forms.Timer { Interval = 3000 };
            timer.Tick += (_, _) =>
            {
                label.ForeColor = TileNormalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void HighlightLatest()
        {
            _latestHighlightTimer?.Stop();
            _latestHighlightTimer?.Dispose();

            lblLatestNumber.ForeColor = LatestHighlightColor;
            _latestHighlightTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            _latestHighlightTimer.Tick += (_, _) =>
            {
                lblLatestNumber.ForeColor = LatestNormalColor;
                _latestHighlightTimer.Stop();
                _latestHighlightTimer.Dispose();
                _latestHighlightTimer = null;
            };
            _latestHighlightTimer.Start();
        }

        private void CustomerForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_allowClose) e.Cancel = true;
        }
    }
}
