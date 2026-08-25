#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class CalledActionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlRecallSlot;
        private System.Windows.Forms.Button btnRecall;

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
        /// 呼び出し済み番号ポップアップの見た目・配置はすべてここで定義している。
        /// 位置/サイズ/色/フォントなどを変更したい場合はこのメソッド内の値を直接編集する。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblCaption = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            lblNumber = new System.Windows.Forms.Label();
            btnDelete = new System.Windows.Forms.Button();
            pnlRecallSlot = new System.Windows.Forms.Panel();
            btnRecall = new System.Windows.Forms.Button();

            pnlRecallSlot.SuspendLayout();
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

            // btnDelete: 主要アクション。大きく表示し、押しやすくする。
            btnDelete.Location = new System.Drawing.Point(20, 380);
            btnDelete.Size = new System.Drawing.Size(620, 160);
            btnDelete.Text = "削除";
            btnDelete.Font = new System.Drawing.Font("Yu Gothic UI", 24F, System.Drawing.FontStyle.Bold);
            btnDelete.BackColor = System.Drawing.Color.FromArgb(56, 142, 220);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Name = "btnDelete";

            // btnRecall: 誤タップ防止のため小さく配置する副次アクション
            btnRecall.Location = new System.Drawing.Point(12, 92);
            btnRecall.Size = new System.Drawing.Size(116, 56);
            btnRecall.Text = "再コール";
            btnRecall.Font = new System.Drawing.Font("Yu Gothic UI", 13F, System.Drawing.FontStyle.Bold);
            btnRecall.BackColor = System.Drawing.Color.FromArgb(60, 160, 130);
            btnRecall.ForeColor = System.Drawing.Color.White;
            btnRecall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRecall.FlatAppearance.BorderSize = 0;
            btnRecall.Name = "btnRecall";

            // pnlRecallSlot: 主要ボタン(btnDelete)と視覚的に区別するための背景色付きスペース
            pnlRecallSlot.Location = new System.Drawing.Point(660, 380);
            pnlRecallSlot.Size = new System.Drawing.Size(140, 160);
            pnlRecallSlot.BackColor = System.Drawing.Color.FromArgb(246, 246, 248);
            pnlRecallSlot.Controls.Add(btnRecall);
            pnlRecallSlot.Name = "pnlRecallSlot";

            // CalledActionForm: タイトルバー付きの通常ウィンドウとして表示する。
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(820, 560);
            Controls.Add(lblCaption);
            Controls.Add(btnClose);
            Controls.Add(lblNumber);
            Controls.Add(btnDelete);
            Controls.Add(pnlRecallSlot);
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalledActionForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "呼び出し済み操作";

            pnlRecallSlot.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
