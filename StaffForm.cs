using SupportChance_CustomerCallSystem_ClaudeCode.Models;
using SupportChance_CustomerCallSystem_ClaudeCode.Services;

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    public partial class StaffForm : Form
    {
        private const int TileWidth = 200;
        private const int TileHeight = 150;
        private const int TileMargin = 12;

        private static readonly Color WaitingTileBack = Color.FromArgb(214, 234, 248);
        private static readonly Color WaitingTileFore = Color.FromArgb(20, 60, 110);
        private static readonly Color WaitingTileBorder = Color.FromArgb(120, 170, 220);

        private static readonly Color CalledTileBack = Color.FromArgb(255, 229, 204);
        private static readonly Color CalledTileFore = Color.FromArgb(140, 70, 20);
        private static readonly Color CalledTileBorder = Color.FromArgb(224, 150, 90);

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
            btnSettings.Click += BtnSettings_Click;
            btnExit.Click += (_, _) => Close();
            FormClosing += StaffForm_FormClosing;

            _manager.WaitingListChanged += RefreshWaiting;
            _manager.CalledListChanged += RefreshCalled;

            RefreshWaiting();
            RefreshCalled();
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
            // フォーカスがボタン上にある場合はそのボタンのネイティブなEnterクリック(=タップ相当)を優先する。
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

        /// <summary>待機中の番号ボタンをタップ(または選択してEnter)した際に呼び出しポップアップを表示する。</summary>
        private void OpenWaitingActionPopup(int number)
        {
            using var popup = new NumberActionForm(
                number,
                new ActionSpec("呼び出す"),
                new ActionSpec("取消", Compact: true, ConfirmMessage: $"番号 {number} の待機を取り消しますか？"));
            popup.ShowDialog(this);

            switch (popup.SelectedActionIndex)
            {
                case 0:
                    _manager.Call(number);
                    PlayCallSound();
                    break;
                case 1:
                    _manager.CancelWaiting(number);
                    break;
            }
        }

        /// <summary>呼び出し済みの番号ボタンをタップした際に再コール/削除ポップアップを表示する。</summary>
        private void OpenCalledActionPopup(int number)
        {
            using var popup = new NumberActionForm(
                number,
                new ActionSpec("再コール", Compact: true, AccentColor: Color.FromArgb(60, 160, 130)),
                new ActionSpec("削除"));
            popup.ShowDialog(this);

            switch (popup.SelectedActionIndex)
            {
                case 0:
                    _manager.Recall(number);
                    PlayCallSound();
                    break;
                case 1:
                    _manager.CompleteCall(number);
                    break;
            }
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
            flowWaiting.SuspendLayout();
            flowWaiting.Controls.Clear();

            if (_manager.Waiting.Count == 0)
            {
                flowWaiting.Controls.Add(CreatePlaceholderLabel("待機中の番号はありません"));
            }
            else
            {
                foreach (var number in _manager.Waiting)
                {
                    var button = CreateNumberButton(number, WaitingTileBack, WaitingTileFore, WaitingTileBorder);
                    button.Click += (_, _) => OpenWaitingActionPopup(number);
                    flowWaiting.Controls.Add(button);
                }
            }

            flowWaiting.ResumeLayout(true);
        }

        private void RefreshCalled()
        {
            flowCalled.SuspendLayout();
            flowCalled.Controls.Clear();

            if (_manager.Called.Count == 0)
            {
                flowCalled.Controls.Add(CreatePlaceholderLabel("呼び出し済みの番号はありません"));
            }
            else
            {
                foreach (var number in _manager.Called)
                {
                    var button = CreateNumberButton(number, CalledTileBack, CalledTileFore, CalledTileBorder);
                    button.Click += (_, _) => OpenCalledActionPopup(number);
                    flowCalled.Controls.Add(button);
                }
            }

            flowCalled.ResumeLayout(true);
        }

        /// <summary>
        /// タッチパネルで押しやすい大きめの番号ボタンを作成する。
        /// 待機中/呼び出し済みエリアに横方向優先(3〜4列)で並び、収まらない分は縦スクロールされる。
        /// </summary>
        private static Button CreateNumberButton(int number, Color backColor, Color foreColor, Color borderColor)
        {
            var button = new Button
            {
                Tag = number,
                Text = number.ToString(),
                AutoSize = false,
                Width = TileWidth,
                Height = TileHeight,
                Margin = new Padding(TileMargin),
                Font = new Font("Yu Gothic UI", 36F, FontStyle.Bold),
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
            };
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.BorderColor = borderColor;
            return button;
        }

        private static Label CreatePlaceholderLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = false,
                Width = 420,
                Height = 60,
                Margin = new Padding(TileMargin),
                Font = new Font("Yu Gothic UI", 14F),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft,
            };
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
