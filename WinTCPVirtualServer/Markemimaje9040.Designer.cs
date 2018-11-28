namespace WinTCPVirtualServer
{
    partial class Markemimaje9040
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxMsg
            // 
            this.richTextBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMsg.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxMsg.Name = "richTextBoxMsg";
            this.richTextBoxMsg.Size = new System.Drawing.Size(481, 569);
            this.richTextBoxMsg.TabIndex = 0;
            this.richTextBoxMsg.Text = "";
            // 
            // Markemimaje9040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 569);
            this.Controls.Add(this.richTextBoxMsg);
            this.Name = "Markemimaje9040";
            this.Text = "Markemimaje9040";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Markemimaje9040_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMsg;
    }
}