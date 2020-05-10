namespace BigBrother
{
    partial class MainForm
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
            this.userGreetLabel = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // userGreetLabel
            // 
            this.userGreetLabel.AutoSize = true;
            this.userGreetLabel.Depth = 0;
            this.userGreetLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.userGreetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userGreetLabel.Location = new System.Drawing.Point(214, 128);
            this.userGreetLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.userGreetLabel.Name = "userGreetLabel";
            this.userGreetLabel.Size = new System.Drawing.Size(348, 27);
            this.userGreetLabel.TabIndex = 0;
            this.userGreetLabel.Text = "Добро пожаловать, ЮЗЕРНЭЙМ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 622);
            this.Controls.Add(this.userGreetLabel);
            this.Name = "MainForm";
            this.Text = "Старший Брат";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel userGreetLabel;
    }
}