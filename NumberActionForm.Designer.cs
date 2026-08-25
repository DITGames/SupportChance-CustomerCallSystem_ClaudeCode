#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class NumberActionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlContent = new System.Windows.Forms.Panel();
            lblCaption = new System.Windows.Forms.Label();
            lblNumber = new System.Windows.Forms.Label();
            pnlActions = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();

            SuspendLayout();

            // lblCaption
            lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            lblCaption.Height = 56;
            lblCaption.Text = "選択した番号";
            lblCaption.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Bold);
            lblCaption.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCaption.Name = "lblCaption";

            // pnlActions: touch-sized action buttons are built dynamically in code-behind
            // (primary buttons fill the area; compact/secondary buttons are tucked into a
            // small corner slot so they are not accidentally tapped)
            pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlActions.Height = 190;
            pnlActions.Padding = new System.Windows.Forms.Padding(16);
            pnlActions.Name = "pnlActions";

            // lblNumber
            lblNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            lblNumber.Font = new System.Drawing.Font("Yu Gothic UI", 140F, System.Drawing.FontStyle.Bold);
            lblNumber.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblNumber.Name = "lblNumber";

            // btnClose: large touch-friendly close button, pinned to the top-right corner
            btnClose.Size = new System.Drawing.Size(96, 96);
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.Font = new System.Drawing.Font("Yu Gothic UI", 30F, System.Drawing.FontStyle.Bold);
            btnClose.Text = "×";
            btnClose.BackColor = System.Drawing.Color.FromArgb(224, 64, 64);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Name = "btnClose";
            btnClose.TabStop = true;

            // pnlContent (claim Top/Bottom edges first, then Fill, then float the close button on top)
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.BackColor = System.Drawing.Color.White;
            pnlContent.Padding = new System.Windows.Forms.Padding(20);
            pnlContent.Controls.Add(lblCaption);
            pnlContent.Controls.Add(pnlActions);
            pnlContent.Controls.Add(lblNumber);
            pnlContent.Controls.Add(btnClose);
            pnlContent.Name = "pnlContent";

            // NumberActionForm
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(60, 60, 72);
            Padding = new System.Windows.Forms.Padding(6);
            ClientSize = new System.Drawing.Size(820, 560);
            Controls.Add(pnlContent);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NumberActionForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "番号操作";

            ResumeLayout(false);
        }

        #endregion
    }
}
