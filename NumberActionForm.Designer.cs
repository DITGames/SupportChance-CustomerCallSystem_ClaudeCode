#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class NumberActionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Panel pnlActions;

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
            pnlHeader = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            lblCaption = new System.Windows.Forms.Label();
            lblNumber = new System.Windows.Forms.Label();
            pnlActions = new System.Windows.Forms.Panel();

            SuspendLayout();

            // btnClose: large touch-friendly close button.
            // Docked (not Anchored) inside pnlHeader so it is always placed correctly
            // without relying on a manually-computed Location.
            btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            btnClose.Width = 96;
            btnClose.Font = new System.Drawing.Font("Yu Gothic UI", 26F, System.Drawing.FontStyle.Bold);
            btnClose.Text = "×";
            btnClose.BackColor = System.Drawing.Color.FromArgb(224, 64, 64);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Name = "btnClose";
            btnClose.TabStop = true;

            // lblCaption: shares the header row with the close button (Dock=Fill takes
            // whatever width remains once btnClose has claimed the right edge).
            lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCaption.Text = "選択した番号";
            lblCaption.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Bold);
            lblCaption.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCaption.Name = "lblCaption";

            // pnlHeader: a single fixed-height row holding the caption and the close button
            // side by side, so the popup doesn't need extra rows/space just for the header.
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 100;
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblCaption);
            pnlHeader.Name = "pnlHeader";

            // pnlActions: touch-sized action buttons are built dynamically in code-behind
            // (primary buttons fill the area; compact/secondary buttons are tucked into a
            // small corner slot so they are not accidentally tapped)
            pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlActions.Height = 190;
            pnlActions.Padding = new System.Windows.Forms.Padding(16);
            pnlActions.Name = "pnlActions";

            // lblNumber
            lblNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            lblNumber.Font = new System.Drawing.Font("Yu Gothic UI", 118F, System.Drawing.FontStyle.Bold);
            lblNumber.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblNumber.Name = "lblNumber";

            // pnlContent (claim Top/Bottom edges in order, Fill last)
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.BackColor = System.Drawing.Color.White;
            pnlContent.Padding = new System.Windows.Forms.Padding(20);
            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Controls.Add(pnlActions);
            pnlContent.Controls.Add(lblNumber);
            pnlContent.Name = "pnlContent";

            // NumberActionForm: 通常のウィンドウ(タイトルバー付きダイアログ)として表示する。
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(820, 560);
            Controls.Add(pnlContent);
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
