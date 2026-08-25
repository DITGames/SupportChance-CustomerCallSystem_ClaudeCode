namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    /// <summary>
    /// アクションボタン1つ分の定義。
    /// </summary>
    /// <param name="Label">ボタンに表示するテキスト。</param>
    /// <param name="Compact">
    /// true の場合、他の主要ボタンから離れた場所に小さく配置し、誤タップを防ぐ
    /// (「取消」「削除」など、慎重に押してほしい操作向け)。
    /// </param>
    /// <param name="ConfirmMessage">
    /// null でなければ、実行前にこのメッセージで確認ダイアログ(はい/いいえ、既定フォーカスは「いいえ」)を表示する。
    /// </param>
    /// <param name="AccentColor">
    /// ボタンの背景色。null の場合は既定色(主要ボタンは青、Compactボタンはグレー)を使う。
    /// </param>
    public readonly record struct ActionSpec(string Label, bool Compact = false, string? ConfirmMessage = null, Color? AccentColor = null);

    /// <summary>
    /// 番号ボタンをタップした際に表示する、大きな操作ポップアップ。
    /// タッチパネルでの操作を想定し、アクションボタンと右上の×閉じるボタンのみで完結する。
    /// </summary>
    public partial class NumberActionForm : Form
    {
        private const int CompactSlotWidth = 150;
        private const int CompactButtonHeight = 56;

        private const float MaxNumberFontSize = 118F;
        private const float MinNumberFontSize = 36F;
        private const float NumberFontStep = 4F;

        private static readonly Color PrimaryColor = Color.FromArgb(56, 142, 220);
        private static readonly Color CompactColor = Color.FromArgb(150, 150, 150);
        private static readonly Color CompactSlotBackColor = Color.FromArgb(246, 246, 248);

        /// <summary>選択されたアクションのインデックス(コンストラクタに渡した順)。×で閉じた場合は -1。</summary>
        public int SelectedActionIndex { get; private set; } = -1;

        public NumberActionForm(int number, params ActionSpec[] actions)
        {
            if (actions.Length == 0)
            {
                throw new ArgumentException("少なくとも1つのアクションが必要です。", nameof(actions));
            }

            InitializeComponent();

            lblNumber.Text = number.ToString();
            btnClose.Click += (_, _) => Close();
            KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Escape) Close();
            };
            // 番号の桁数に関わらず表示エリアに収まる最大の文字サイズへ調整する。
            // (コンストラクタ時点ではまだ最終的なコントロールサイズが確定していないため、
            //  レイアウト完了直後の Load で計算する)
            Load += (_, _) => FitNumberFont();

            BuildActionButtons(actions);
        }

        /// <summary>lblNumber の表示領域に収まる最大のフォントサイズへ調整する。</summary>
        private void FitNumberFont()
        {
            var bounds = lblNumber.ClientSize;
            if (bounds.Width <= 0 || bounds.Height <= 0) return;

            var availableWidth = bounds.Width - 20;
            var availableHeight = bounds.Height - 10;
            var text = lblNumber.Text;

            var chosenSize = MinNumberFontSize;
            for (var size = MaxNumberFontSize; size >= MinNumberFontSize; size -= NumberFontStep)
            {
                using var candidate = new Font("Yu Gothic UI", size, FontStyle.Bold);
                var measured = TextRenderer.MeasureText(text, candidate);
                if (measured.Width <= availableWidth && measured.Height <= availableHeight)
                {
                    chosenSize = size;
                    break;
                }
            }

            lblNumber.Font.Dispose();
            lblNumber.Font = new Font("Yu Gothic UI", chosenSize, FontStyle.Bold);
        }

        private void BuildActionButtons(ActionSpec[] actions)
        {
            var indexed = actions.Select((spec, index) => (spec, index)).ToArray();
            var compactActions = indexed.Where(x => x.spec.Compact).ToArray();
            var mainActions = indexed.Where(x => !x.spec.Compact).ToArray();

            if (compactActions.Length > 0)
            {
                // 主要ボタンの右側に、うっすら色分けした専用スペースを確保し、その中でも
                // 一番下にだけ小さく配置する(上側は空白のまま)ことで誤タップを防ぐ。
                var pnlCompact = new Panel
                {
                    Dock = DockStyle.Right,
                    Width = CompactSlotWidth,
                    BackColor = CompactSlotBackColor,
                    Padding = new Padding(12),
                };
                pnlActions.Controls.Add(pnlCompact);

                // 主要ボタンとの間にはっきりとした隙間を作る(Panel/DockではMarginが
                // 効かないため、専用のスペーサーで隙間を確保する)。
                var pnlGap = new Panel { Dock = DockStyle.Right, Width = 16 };
                pnlActions.Controls.Add(pnlGap);

                foreach (var (spec, index) in compactActions.Reverse())
                {
                    var button = CreateActionButton(spec, index);
                    button.Dock = DockStyle.Bottom;
                    button.Height = CompactButtonHeight;
                    button.Margin = new Padding(0, 8, 0, 0);
                    pnlCompact.Controls.Add(button);
                }
            }

            if (mainActions.Length == 0) return;

            var pnlMain = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = mainActions.Length, RowCount = 1 };
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            for (var column = 0; column < mainActions.Length; column++)
            {
                var (spec, index) = mainActions[column];
                pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / mainActions.Length));
                var button = CreateActionButton(spec, index);
                button.Dock = DockStyle.Fill;
                button.Margin = new Padding(mainActions.Length > 1 ? 8 : 0, 4, mainActions.Length > 1 ? 8 : 0, 4);
                pnlMain.Controls.Add(button, column, 0);
            }
            pnlActions.Controls.Add(pnlMain);
        }

        private Button CreateActionButton(ActionSpec spec, int index)
        {
            var button = new Button
            {
                Text = spec.Label,
                FlatStyle = FlatStyle.Flat,
                BackColor = spec.AccentColor ?? (spec.Compact ? CompactColor : PrimaryColor),
                ForeColor = Color.White,
                Font = new Font("Yu Gothic UI", spec.Compact ? 13F : 22F, FontStyle.Bold),
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += (_, _) =>
            {
                if (spec.ConfirmMessage != null)
                {
                    var result = MessageBox.Show(this, spec.ConfirmMessage, "確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result != DialogResult.Yes) return;
                }

                SelectedActionIndex = index;
                Close();
            };
            return button;
        }
    }
}
