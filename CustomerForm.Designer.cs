#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlLatest;
        private System.Windows.Forms.Label lblLatestNumber;
        private System.Windows.Forms.Label lblLatestCaption;
        private System.Windows.Forms.Panel pnlSubHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Panel pnlCalledArea;
        private System.Windows.Forms.FlowLayoutPanel flowCalled;

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

            tableMain = new System.Windows.Forms.TableLayoutPanel();
            pnlHeader = new System.Windows.Forms.Panel();
            lblHeaderTitle = new System.Windows.Forms.Label();
            pnlLatest = new System.Windows.Forms.Panel();
            lblLatestNumber = new System.Windows.Forms.Label();
            lblLatestCaption = new System.Windows.Forms.Label();
            pnlSubHeader = new System.Windows.Forms.Panel();
            lblSubHeader = new System.Windows.Forms.Label();
            pnlCalledArea = new System.Windows.Forms.Panel();
            flowCalled = new System.Windows.Forms.FlowLayoutPanel();

            SuspendLayout();

            // tableMain: header / latest number / sub header band / called grid
            tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableMain.ColumnCount = 1;
            tableMain.RowCount = 4;
            tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableMain.BackColor = System.Drawing.Color.FromArgb(45, 32, 24);
            tableMain.Padding = new System.Windows.Forms.Padding(0);
            tableMain.Controls.Add(pnlHeader, 0, 0);
            tableMain.Controls.Add(pnlLatest, 0, 1);
            tableMain.Controls.Add(pnlSubHeader, 0, 2);
            tableMain.Controls.Add(pnlCalledArea, 0, 3);

            // pnlHeader
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(214, 108, 58);
            pnlHeader.Controls.Add(lblHeaderTitle);

            // lblHeaderTitle
            lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblHeaderTitle.Text = "呼出番号案内";
            lblHeaderTitle.Font = new System.Drawing.Font("Yu Gothic UI", 28F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlLatest: showcase for the most recently called number
            pnlLatest.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLatest.BackColor = System.Drawing.Color.FromArgb(45, 32, 24);
            pnlLatest.Padding = new System.Windows.Forms.Padding(32, 16, 32, 12);
            pnlLatest.Controls.Add(lblLatestNumber);
            pnlLatest.Controls.Add(lblLatestCaption);

            // lblLatestCaption
            lblLatestCaption.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblLatestCaption.Height = 36;
            lblLatestCaption.Text = "最新の呼出番号";
            lblLatestCaption.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold);
            lblLatestCaption.ForeColor = System.Drawing.Color.FromArgb(240, 200, 160);
            lblLatestCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblLatestNumber
            lblLatestNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            lblLatestNumber.Text = "---";
            lblLatestNumber.Font = new System.Drawing.Font("Yu Gothic UI", 110F, System.Drawing.FontStyle.Bold);
            lblLatestNumber.ForeColor = System.Drawing.Color.FromArgb(40, 26, 16);
            lblLatestNumber.BackColor = System.Drawing.Color.FromArgb(250, 240, 224);
            lblLatestNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlSubHeader
            pnlSubHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlSubHeader.BackColor = System.Drawing.Color.FromArgb(224, 122, 66);
            pnlSubHeader.Controls.Add(lblSubHeader);

            // lblSubHeader
            lblSubHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSubHeader.Text = "以下の番号も呼び出し済みです";
            lblSubHeader.Font = new System.Drawing.Font("Yu Gothic UI", 16F, System.Drawing.FontStyle.Bold);
            lblSubHeader.ForeColor = System.Drawing.Color.White;
            lblSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlCalledArea: warm (non-black) background behind the called-number grid
            pnlCalledArea.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCalledArea.BackColor = System.Drawing.Color.FromArgb(58, 41, 30);
            pnlCalledArea.Padding = new System.Windows.Forms.Padding(16);
            pnlCalledArea.Controls.Add(flowCalled);

            // flowCalled: grid of previously called numbers
            flowCalled.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCalled.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            flowCalled.WrapContents = true;
            flowCalled.AutoScroll = true;
            flowCalled.BackColor = System.Drawing.Color.FromArgb(58, 41, 30);
            flowCalled.Name = "flowCalled";

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(45, 32, 24);
            ClientSize = new System.Drawing.Size(1920, 1080);
            Controls.Add(tableMain);
            Name = "CustomerForm";
            Text = "お客様用画面";

            ResumeLayout(false);
        }

        #endregion
    }
}
