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
        private System.Windows.Forms.FlowLayoutPanel flowWaiting;

        private System.Windows.Forms.Panel panelCalled;
        private System.Windows.Forms.Label lblCalledTitle;
        private System.Windows.Forms.FlowLayoutPanel flowCalled;

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
            flowWaiting = new System.Windows.Forms.FlowLayoutPanel();

            panelCalled = new System.Windows.Forms.Panel();
            lblCalledTitle = new System.Windows.Forms.Label();
            flowCalled = new System.Windows.Forms.FlowLayoutPanel();

            panelTop.SuspendLayout();
            panelTopRight.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelWaiting.SuspendLayout();
            panelCalled.SuspendLayout();
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

            // flowWaiting: 番号ボタンをタッチしやすい大きさで横方向優先(3〜4列)に並べ、
            // 画面に収まらない分は縦スクロールで表示する。
            flowWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            flowWaiting.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            flowWaiting.WrapContents = true;
            flowWaiting.AutoScroll = true;
            flowWaiting.BackColor = System.Drawing.Color.White;
            flowWaiting.Name = "flowWaiting";

            // panelWaiting
            panelWaiting.Controls.Add(flowWaiting);
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

            // flowCalled
            flowCalled.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCalled.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            flowCalled.WrapContents = true;
            flowCalled.AutoScroll = true;
            flowCalled.BackColor = System.Drawing.Color.White;
            flowCalled.Name = "flowCalled";

            // panelCalled
            panelCalled.Controls.Add(flowCalled);
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
            panelWaiting.ResumeLayout(false);
            panelCalled.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
