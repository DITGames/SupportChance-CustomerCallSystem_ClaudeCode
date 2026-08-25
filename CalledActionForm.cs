namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    /// <summary>
    /// 呼び出し済みの番号ボタンをタップした際に表示するポップアップ。
    /// コントロールの配置・色・フォントは CalledActionForm.Designer.cs にすべて
    /// 静的に定義されている(実行時にボタンを組み立てたりはしない)ので、
    /// 見た目を変更したい場合はそちらを直接編集する。
    /// </summary>
    public partial class CalledActionForm : Form
    {
        private const float MaxNumberFontSize = 118F;
        private const float MinNumberFontSize = 36F;
        private const float NumberFontStep = 4F;

        /// <summary>「削除」が押されて閉じられた場合 true。</summary>
        public bool DeleteRequested { get; private set; }

        /// <summary>「再コール」が押されて閉じられた場合 true。</summary>
        public bool RecallRequested { get; private set; }

        public CalledActionForm(int number)
        {
            InitializeComponent();

            lblNumber.Text = number.ToString();

            btnClose.Click += (_, _) => Close();

            btnDelete.Click += (_, _) =>
            {
                DeleteRequested = true;
                Close();
            };

            btnRecall.Click += (_, _) =>
            {
                RecallRequested = true;
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
