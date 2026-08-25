namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    /// <summary>
    /// 待機中の番号ボタンをタップした際に表示するポップアップ。
    /// コントロールの配置・色・フォントは WaitingActionForm.Designer.cs にすべて
    /// 静的に定義されている(実行時にボタンを組み立てたりはしない)ので、
    /// 見た目を変更したい場合はそちらを直接編集する。
    /// </summary>
    public partial class WaitingActionForm : Form
    {
        private const float MaxNumberFontSize = 118F;
        private const float MinNumberFontSize = 36F;
        private const float NumberFontStep = 4F;

        /// <summary>「呼び出す」が押されて閉じられた場合 true。</summary>
        public bool CallRequested { get; private set; }

        /// <summary>「取消」が押されて閉じられた場合 true。</summary>
        public bool CancelRequested { get; private set; }

        public WaitingActionForm(int number)
        {
            InitializeComponent();

            lblNumber.Text = number.ToString();

            btnClose.Click += (_, _) => Close();

            btnCall.Click += (_, _) =>
            {
                CallRequested = true;
                Close();
            };

            btnCancel.Click += (_, _) =>
            {
                var result = MessageBox.Show(this, $"番号 {number} の待機を取り消しますか？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes) return;

                CancelRequested = true;
                Close();
            };

            KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Escape) Close();
            };

            // 番号の桁数に関わらず表示エリアに収まる最大の文字サイズへ調整する。
            // (コンストラクタ時点ではまだ最終的なコントロールサイズが確定していないため、
            //  レイアウト完了直後の Load で計算する)
            Load += (_, _) => FitNumberFont();
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
    }
}
