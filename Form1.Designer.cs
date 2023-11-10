namespace Awaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ButtonSwitch = new Button();
            SuspendLayout();
            // 
            // ButtonSwitch
            // 
            ButtonSwitch.Dock = DockStyle.Fill;
            ButtonSwitch.Location = new Point(0, 0);
            ButtonSwitch.Margin = new Padding(2);
            ButtonSwitch.Name = "ButtonSwitch";
            ButtonSwitch.Size = new Size(171, 39);
            ButtonSwitch.TabIndex = 0;
            ButtonSwitch.Text = "Off";
            ButtonSwitch.UseVisualStyleBackColor = true;
            ButtonSwitch.Click += ButtonSwitch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(171, 39);
            Controls.Add(ButtonSwitch);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "Awaker";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonSwitch;
    }
}