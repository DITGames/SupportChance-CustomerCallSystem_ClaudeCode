#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class WaitingActionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Panel pnlCancelSlot;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// 待機中番号ポップアップの見た目・配置はすべてここで定義している。
        /// 位置/サイズ/色/フォントなどを変更したい場合はこのメソッド内の値を直接編集する。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblCaption = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            lblNumber = new System.Windows.Forms.Label();
            btnCall = new System.Windows.Forms.Button();
            pnlCancelSlot = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();

            pnlCancelSlot.SuspendLayout();
            SuspendLayout();

            // lblCaption
            lblCaption.Location = new System.Drawing.Point(20, 16);
            lblCaption.Size = new System.Drawing.Size(680, 40);
            lblCaption.Text = "選択した番号";
            lblCaption.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Bold);
            lblCaption.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCaption.Name = "lblCaption";

            // btnClose: 右上の大きな×閉じるボタン(タッチ操作向け)
            btnClose.Location = new System.Drawing.Point(704, 12);
            btnClose.Size = new System.Drawing.Size(96, 96);
            btnClose.Font = new System.Drawing.Font("Yu Gothic UI", 26F, System.Drawing.FontStyle.Bold);
            btnClose.Text = "×";
            btnClose.BackColor = System.Drawing.Color.FromArgb(224, 64, 64);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Name = "btnClose";

            // lblNumber: 番号表示。"123" はデザイナー上で見やすくするためのサンプル値で、
            // 実行時にコンストラクタから実際の番号で上書きされる。
            lblNumber.Location = new System.Drawing.Point(20, 120);
            lblNumber.Size = new System.Drawing.Size(780, 240);
            lblNumber.Text = "123";
            lblNumber.Font = new System.Drawing.Font("Yu Gothic UI", 118F, System.Drawing.FontStyle.Bold);
            lblNumber.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblNumber.Name = "lblNumber";

            // btnCall: 主要アクション。大きく表示し、押しやすくする。
            btnCall.Location = new System.Drawing.Point(20, 380);
            btnCall.Size = new System.Drawing.Size(620, 160);
            btnCall.Text = "呼び出す";
            btnCall.Font = new System.Drawing.Font("Yu Gothic UI", 24F, System.Drawing.FontStyle.Bold);
            btnCall.BackColor = System.Drawing.Color.FromArgb(56, 142, 220);
            btnCall.ForeColor = System.Drawing.Color.White;
            btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCall.FlatAppearance.BorderSize = 0;
            btnCall.Name = "btnCall";

            // btnCancel: 誤タップ防止のため小さく配置する副次アクション(実行前に確認あり)
            btnCancel.Location = new System.Drawing.Point(12, 92);
            btnCancel.Size = new System.Drawing.Size(116, 56);
            btnCancel.Text = "取消";
            btnCancel.Font = new System.Drawing.Font("Yu Gothic UI", 13F, System.Drawing.FontStyle.Bold);
            btnCancel.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Name = "btnCancel";

            // pnlCancelSlot: 主要ボタン(btnCall)と視覚的に区別するための背景色付きスペース
            pnlCancelSlot.Location = new System.Drawing.Point(660, 380);
            pnlCancelSlot.Size = new System.Drawing.Size(140, 160);
            pnlCancelSlot.BackColor = System.Drawing.Color.FromArgb(246, 246, 248);
            pnlCancelSlot.Controls.Add(btnCancel);
            pnlCancelSlot.Name = "pnlCancelSlot";

            // WaitingActionForm: タイトルバー付きの通常ウィンドウとして表示する。
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(820, 560);
            Controls.Add(lblCaption);
            Controls.Add(btnClose);
            Controls.Add(lblNumber);
            Controls.Add(btnCall);
            Controls.Add(pnlCancelSlot);
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WaitingActionForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "呼び出し操作";

            pnlCancelSlot.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
