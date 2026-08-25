#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class StaffForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;

        private System.Windows.Forms.Panel panelWaiting;
        private System.Windows.Forms.Label lblWaitingTitle;
        private System.Windows.Forms.ListBox lstWaiting;
        private System.Windows.Forms.Panel panelWaitingButtons;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnCancelWaiting;

        private System.Windows.Forms.Panel panelCalled;
        private System.Windows.Forms.Label lblCalledTitle;
        private System.Windows.Forms.ListBox lstCalled;
        private System.Windows.Forms.Panel panelCalledButtons;
        private System.Windows.Forms.Button btnRecall;
        private System.Windows.Forms.Button btnCompleteCalled;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelTop = new System.Windows.Forms.Panel();
            panelTopRight = new System.Windows.Forms.Panel();
            btnExit = new System.Windows.Forms.Button();
            btnSettings = new System.Windows.Forms.Button();
            lblError = new System.Windows.Forms.Label();
            btnAdd = new System.Windows.Forms.Button();
            txtNumber = new System.Windows.Forms.TextBox();

            tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();

            panelWaiting = new System.Windows.Forms.Panel();
            lblWaitingTitle = new System.Windows.Forms.Label();
            lstWaiting = new System.Windows.Forms.ListBox();
            panelWaitingButtons = new System.Windows.Forms.Panel();
            btnCall = new System.Windows.Forms.Button();
            btnCancelWaiting = new System.Windows.Forms.Button();

            panelCalled = new System.Windows.Forms.Panel();
            lblCalledTitle = new System.Windows.Forms.Label();
            lstCalled = new System.Windows.Forms.ListBox();
            panelCalledButtons = new System.Windows.Forms.Panel();
            btnRecall = new System.Windows.Forms.Button();
            btnCompleteCalled = new System.Windows.Forms.Button();

            panelTop.SuspendLayout();
            panelTopRight.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelWaiting.SuspendLayout();
            panelWaitingButtons.SuspendLayout();
            panelCalled.SuspendLayout();
            panelCalledButtons.SuspendLayout();
            SuspendLayout();

            // txtNumber
            txtNumber.Font = new System.Drawing.Font("Yu Gothic UI", 18F);
            txtNumber.Location = new System.Drawing.Point(20, 20);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new System.Drawing.Size(200, 40);
            txtNumber.MaxLength = 9;

            // btnAdd
            btnAdd.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            btnAdd.Location = new System.Drawing.Point(230, 18);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(120, 44);
            btnAdd.Text = "追加";
            btnAdd.UseVisualStyleBackColor = true;

            // lblError
            lblError.AutoSize = false;
            lblError.Font = new System.Drawing.Font("Yu Gothic UI", 11F);
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Location = new System.Drawing.Point(370, 20);
            lblError.Name = "lblError";
            lblError.Size = new System.Drawing.Size(500, 40);
            lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnSettings
            btnSettings.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            btnSettings.Location = new System.Drawing.Point(10, 18);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(150, 44);
            btnSettings.Text = "設定";
            btnSettings.UseVisualStyleBackColor = true;

            // btnExit
            btnExit.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
            btnExit.Location = new System.Drawing.Point(170, 18);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(150, 44);
            btnExit.Text = "終了";
            btnExit.UseVisualStyleBackColor = true;

            // panelTopRight
            panelTopRight.Controls.Add(btnSettings);
            panelTopRight.Controls.Add(btnExit);
            panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelTopRight.Width = 340;
            panelTopRight.Name = "panelTopRight";

            // panelTop
            panelTop.Controls.Add(txtNumber);
            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(lblError);
            panelTop.Controls.Add(panelTopRight);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Height = 90;
            panelTop.Name = "panelTop";

            // lblWaitingTitle
            lblWaitingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblWaitingTitle.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Bold);
            lblWaitingTitle.Height = 50;
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Text = "待機中";
            lblWaitingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblWaitingTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // lstWaiting
            lstWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            lstWaiting.Font = new System.Drawing.Font("Yu Gothic UI", 20F);
            lstWaiting.ItemHeight = 36;
            lstWaiting.Name = "lstWaiting";

            // btnCall
            btnCall.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            btnCall.Location = new System.Drawing.Point(10, 10);
            btnCall.Name = "btnCall";
            btnCall.Size = new System.Drawing.Size(180, 60);
            btnCall.Text = "呼び出し";
            btnCall.UseVisualStyleBackColor = true;

            // btnCancelWaiting
            btnCancelWaiting.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            btnCancelWaiting.Location = new System.Drawing.Point(200, 10);
            btnCancelWaiting.Name = "btnCancelWaiting";
            btnCancelWaiting.Size = new System.Drawing.Size(180, 60);
            btnCancelWaiting.Text = "削除";
            btnCancelWaiting.UseVisualStyleBackColor = true;

            // panelWaitingButtons
            panelWaitingButtons.Controls.Add(btnCall);
            panelWaitingButtons.Controls.Add(btnCancelWaiting);
            panelWaitingButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelWaitingButtons.Height = 80;
            panelWaitingButtons.Name = "panelWaitingButtons";

            // panelWaiting
            panelWaiting.Controls.Add(lstWaiting);
            panelWaiting.Controls.Add(panelWaitingButtons);
            panelWaiting.Controls.Add(lblWaitingTitle);
            panelWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            panelWaiting.Name = "panelWaiting";
            panelWaiting.Padding = new System.Windows.Forms.Padding(10);

            // lblCalledTitle
            lblCalledTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblCalledTitle.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Bold);
            lblCalledTitle.Height = 50;
            lblCalledTitle.Name = "lblCalledTitle";
            lblCalledTitle.Text = "呼び出し済み（未到着）";
            lblCalledTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCalledTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // lstCalled
            lstCalled.Dock = System.Windows.Forms.DockStyle.Fill;
            lstCalled.Font = new System.Drawing.Font("Yu Gothic UI", 20F);
            lstCalled.ItemHeight = 36;
            lstCalled.Name = "lstCalled";

            // btnRecall
            btnRecall.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            btnRecall.Location = new System.Drawing.Point(10, 10);
            btnRecall.Name = "btnRecall";
            btnRecall.Size = new System.Drawing.Size(180, 60);
            btnRecall.Text = "再コール";
            btnRecall.UseVisualStyleBackColor = true;

            // btnCompleteCalled
            btnCompleteCalled.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            btnCompleteCalled.Location = new System.Drawing.Point(200, 10);
            btnCompleteCalled.Name = "btnCompleteCalled";
            btnCompleteCalled.Size = new System.Drawing.Size(180, 60);
            btnCompleteCalled.Text = "削除";
            btnCompleteCalled.UseVisualStyleBackColor = true;

            // panelCalledButtons
            panelCalledButtons.Controls.Add(btnRecall);
            panelCalledButtons.Controls.Add(btnCompleteCalled);
            panelCalledButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelCalledButtons.Height = 80;
            panelCalledButtons.Name = "panelCalledButtons";

            // panelCalled
            panelCalled.Controls.Add(lstCalled);
            panelCalled.Controls.Add(panelCalledButtons);
            panelCalled.Controls.Add(lblCalledTitle);
            panelCalled.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCalled.Name = "panelCalled";
            panelCalled.Padding = new System.Windows.Forms.Padding(10);

            // tableLayoutMain
            tableLayoutMain.ColumnCount = 2;
            tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutMain.RowCount = 1;
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panelWaiting, 0, 0);
            tableLayoutMain.Controls.Add(panelCalled, 1, 0);
            tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutMain.Name = "tableLayoutMain";

            // StaffForm
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1840, 1000);
            Controls.Add(tableLayoutMain);
            Controls.Add(panelTop);
            Name = "StaffForm";
            Text = "店員用管理画面";

            panelTopRight.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelWaitingButtons.ResumeLayout(false);
            panelWaiting.ResumeLayout(false);
            panelCalledButtons.ResumeLayout(false);
            panelCalled.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
