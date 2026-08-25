#nullable disable

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

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

            flowCalled = new System.Windows.Forms.FlowLayoutPanel();
            flowCalled.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCalled.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowCalled.WrapContents = false;
            flowCalled.AutoScroll = true;
            flowCalled.BackColor = System.Drawing.Color.Black;
            flowCalled.Name = "flowCalled";

            SuspendLayout();

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1920, 1080);
            Controls.Add(flowCalled);
            Name = "CustomerForm";
            Text = "お客様用画面";

            ResumeLayout(false);
        }

        #endregion
    }
}
