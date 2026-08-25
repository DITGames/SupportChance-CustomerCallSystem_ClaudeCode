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
