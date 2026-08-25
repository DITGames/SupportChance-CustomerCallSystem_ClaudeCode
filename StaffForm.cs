using SupportChance_CustomerCallSystem_ClaudeCode.Models;
using SupportChance_CustomerCallSystem_ClaudeCode.Services;

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    public partial class StaffForm : Form
    {
        private readonly CallQueueManager _manager;
        private readonly SettingsService _settingsService;
        private readonly AppSettings _settings;
        private readonly PersistenceService _persistence;
        private readonly CustomerForm _customerForm;
        private bool _allowClose;

        public StaffForm(
            CallQueueManager manager,
            SettingsService settingsService,
            AppSettings settings,
            PersistenceService persistence,
            CustomerForm customerForm)
        {
            _manager = manager;
            _settingsService = settingsService;
            _settings = settings;
            _persistence = persistence;
            _customerForm = customerForm;

            InitializeComponent();

            KeyPreview = true;
            KeyDown += StaffForm_KeyDown;

            txtNumber.KeyPress += TxtNumber_KeyPress;
            btnAdd.Click += BtnAdd_Click;
            lstWaiting.SelectedIndexChanged += LstWaiting_SelectedIndexChanged;
            lstCalled.SelectedIndexChanged += LstCalled_SelectedIndexChanged;
            btnCall.Click += BtnCall_Click;
            btnCancelWaiting.Click += BtnCancelWaiting_Click;
            btnRecall.Click += BtnRecall_Click;
            btnCompleteCalled.Click += BtnCompleteCalled_Click;
            btnSettings.Click += BtnSettings_Click;
            btnExit.Click += (_, _) => Close();
            FormClosing += StaffForm_FormClosing;

            _manager.WaitingListChanged += RefreshWaiting;
            _manager.CalledListChanged += RefreshCalled;

            RefreshWaiting();
            RefreshCalled();
            UpdateButtonStates();
        }

        private void TxtNumber_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// テンキー・矢印キー・Enterキーのみで操作できるようにするためのフォーム全体のキー処理。
        /// 数字キーはどこにフォーカスがあっても番号入力欄へ、Enterキーは番号の追加へ、
        /// 矢印キーはコントロール間のフォーカス移動へルーティングする。
        /// </summary>
        private void StaffForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (TryRouteDigitToNumberBox(e)) return;
            if (TryAddOnEnter(e)) return;
            TryNavigateWithArrows(e);
        }

        private bool TryRouteDigitToNumberBox(KeyEventArgs e)
        {
            var digit = DigitFromKey(e.KeyCode);
            if (digit < 0) return false;

            if (!ReferenceEquals(ActiveControl, txtNumber))
            {
                txtNumber.Focus();
                txtNumber.SelectionStart = txtNumber.TextLength;
                txtNumber.SelectionLength = 0;
            }

            var start = txtNumber.SelectionStart;
            var text = txtNumber.Text;
            if (txtNumber.SelectionLength > 0)
            {
                text = text.Remove(start, txtNumber.SelectionLength);
            }

            if (text.Length < txtNumber.MaxLength)
            {
                txtNumber.Text = text.Insert(start, digit.ToString());
                txtNumber.SelectionStart = start + 1;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
            return true;
        }

        private static int DigitFromKey(Keys keyCode)
        {
            if (keyCode is >= Keys.D0 and <= Keys.D9) return keyCode - Keys.D0;
            if (keyCode is >= Keys.NumPad0 and <= Keys.NumPad9) return keyCode - Keys.NumPad0;
            return -1;
        }

        private bool TryAddOnEnter(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return false;
            // フォーカスがボタン上にある場合はそのボタンのネイティブなEnterクリックを優先する。
            if (ActiveControl is Button) return false;
            if (txtNumber.Text.Trim().Length == 0) return false;

            BtnAdd_Click(this, EventArgs.Empty);
            e.Handled = true;
            e.SuppressKeyPress = true;
            return true;
        }

        private bool TryNavigateWithArrows(KeyEventArgs e)
        {
            if (e.KeyCode is not (Keys.Up or Keys.Down or Keys.Left or Keys.Right)) return false;

            // リスト内では上下キーによる項目選択(ネイティブ動作)を優先する。
            if (ActiveControl is ListBox && e.KeyCode is Keys.Up or Keys.Down) return false;

            // 番号入力欄では左右キーによるカーソル移動(ネイティブ動作)を優先する。
            if (ReferenceEquals(ActiveControl, txtNumber) && e.KeyCode is Keys.Left or Keys.Right) return false;

            var forward = e.KeyCode is Keys.Down or Keys.Right;
            var next = GetNextControl(ActiveControl, forward);
            while (next != null && (!next.TabStop || !next.CanSelect))
            {
                next = GetNextControl(next, forward);
            }
            next?.Focus();

            e.Handled = true;
            e.SuppressKeyPress = true;
            return true;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var text = txtNumber.Text.Trim();
            if (text.Length == 0)
            {
                lblError.Text = "番号を入力してください。";
                return;
            }

            if (!int.TryParse(text, out var number))
            {
                lblError.Text = "無効な番号です。";
                return;
            }

            if (_manager.TryAdd(number, out var error))
            {
                lblError.Text = string.Empty;
                txtNumber.Text = string.Empty;
                txtNumber.Focus();
            }
            else
            {
                lblError.Text = error;
            }
        }

        private void LstWaiting_SelectedIndexChanged(object? sender, EventArgs e) => UpdateButtonStates();

        private void LstCalled_SelectedIndexChanged(object? sender, EventArgs e) => UpdateButtonStates();

        private void UpdateButtonStates()
        {
            btnCall.Enabled = lstWaiting.SelectedItem != null;
            btnCancelWaiting.Enabled = lstWaiting.SelectedItem != null;
            btnRecall.Enabled = lstCalled.SelectedItem != null;
            btnCompleteCalled.Enabled = lstCalled.SelectedItem != null;
        }

        private void BtnCall_Click(object? sender, EventArgs e)
        {
            if (lstWaiting.SelectedItem is not int number) return;
            _manager.Call(number);
            PlayCallSound();
        }

        private void BtnCancelWaiting_Click(object? sender, EventArgs e)
        {
            if (lstWaiting.SelectedItem is not int number) return;
            _manager.CancelWaiting(number);
        }

        private void BtnRecall_Click(object? sender, EventArgs e)
        {
            if (lstCalled.SelectedItem is not int number) return;
            _manager.Recall(number);
            PlayCallSound();
        }

        private void BtnCompleteCalled_Click(object? sender, EventArgs e)
        {
            if (lstCalled.SelectedItem is not int number) return;
            _manager.CompleteCall(number);
        }

        private void PlayCallSound()
        {
            SoundService.Play(_settings.WavFilePath, message =>
                MessageBox.Show(this, message, "音声再生エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning));
        }

        private void BtnSettings_Click(object? sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm(_settings.WavFilePath);
            if (settingsForm.ShowDialog(this) != DialogResult.OK) return;

            _settings.WavFilePath = settingsForm.SelectedWavPath;
            _settingsService.Save(_settings);
        }

        private void RefreshWaiting()
        {
            var selected = lstWaiting.SelectedItem as int?;
            lstWaiting.Items.Clear();
            foreach (var number in _manager.Waiting)
            {
                lstWaiting.Items.Add(number);
            }
            if (selected.HasValue) lstWaiting.SelectedItem = selected.Value;
            UpdateButtonStates();
        }

        private void RefreshCalled()
        {
            var selected = lstCalled.SelectedItem as int?;
            lstCalled.Items.Clear();
            foreach (var number in _manager.Called)
            {
                lstCalled.Items.Add(number);
            }
            if (selected.HasValue) lstCalled.SelectedItem = selected.Value;
            UpdateButtonStates();
        }

        private void StaffForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_allowClose) return;

            e.Cancel = true;

            var result = MessageBox.Show(this, "アプリを終了しますか？", "終了確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            _persistence.Save(_manager.ToState());
            _allowClose = true;
            _customerForm.AllowCloseAndClose();
            Close();
        }
    }
}
