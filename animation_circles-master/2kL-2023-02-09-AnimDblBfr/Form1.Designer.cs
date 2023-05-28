namespace _2kL_2023_02_09_AnimDblBfr
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
            mainPanel = new Panel();
            btnStart = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.BackColor = Color.White;
            mainPanel.Location = new Point(14, 16);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(638, 540);
            mainPanel.TabIndex = 0;
            mainPanel.MouseClick += mainPanel_MouseClick;
            mainPanel.Resize += mainPanel_Resize;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom;
            btnStart.Location = new Point(290, 573);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(86, 31);
            btnStart.TabIndex = 1;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(566, 573);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 620);
            Controls.Add(button1);
            Controls.Add(btnStart);
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(455, 451);
            Name = "Form1";
            Text = "Анимация";
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button btnStart;
        private Button button1;
    }
}