#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOk;
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblCurrent = new System.Windows.Forms.Label();
            txtPath = new System.Windows.Forms.TextBox();
            btnBrowse = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            SuspendLayout();

            // lblCurrent
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new System.Drawing.Point(20, 20);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Text = "呼び出し音（wavファイル）";

            // txtPath
            txtPath.Location = new System.Drawing.Point(20, 45);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new System.Drawing.Size(430, 27);

            // btnBrowse
            btnBrowse.Location = new System.Drawing.Point(460, 43);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(100, 30);
            btnBrowse.Text = "参照...";
            btnBrowse.UseVisualStyleBackColor = true;

            // btnOk
            btnOk.Location = new System.Drawing.Point(380, 90);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(90, 32);
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;

            // btnCancel
            btnCancel.Location = new System.Drawing.Point(470, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(90, 32);
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;

            // SettingsForm
            AcceptButton = btnOk;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(580, 140);
            Controls.Add(lblCurrent);
            Controls.Add(txtPath);
            Controls.Add(btnBrowse);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "設定";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
