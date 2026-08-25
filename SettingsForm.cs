namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    public partial class SettingsForm : Form
    {
        public string? SelectedWavPath { get; private set; }

        public SettingsForm(string? currentPath)
        {
            InitializeComponent();

            SelectedWavPath = currentPath;
            txtPath.Text = currentPath ?? string.Empty;

            btnBrowse.Click += BtnBrowse_Click;
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += (_, _) => DialogResult = DialogResult.Cancel;
        }

        private void BtnBrowse_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Wave ファイル (*.wav)|*.wav|すべてのファイル (*.*)|*.*",
                InitialDirectory = GetSoundsInitialDirectory(),
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// 参照ダイアログの初期フォルダ。exe配下の Assets\Sounds があればそこを、
        /// なければexeのあるフォルダをフォールバックとして使う。
        /// </summary>
        private static string GetSoundsInitialDirectory()
        {
            var soundsDir = Path.Combine(AppContext.BaseDirectory, "Assets", "Sounds");
            return Directory.Exists(soundsDir) ? soundsDir : AppContext.BaseDirectory;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            SelectedWavPath = txtPath.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
