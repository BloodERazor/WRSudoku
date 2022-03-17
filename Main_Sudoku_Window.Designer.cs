namespace WRSudokuRedo
{
    partial class SudokuWindow
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
            this.Work_Square_Label = new System.Windows.Forms.Label();
            this.ClueAmount = new System.Windows.Forms.Label();
            this.Answer_Button = new System.Windows.Forms.Button();
            this.Answer_Label = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Work_Square_Label
            // 
            this.Work_Square_Label.AutoSize = true;
            this.Work_Square_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Work_Square_Label.ForeColor = System.Drawing.Color.Crimson;
            this.Work_Square_Label.Location = new System.Drawing.Point(10, 10);
            this.Work_Square_Label.Name = "Work_Square_Label";
            this.Work_Square_Label.Size = new System.Drawing.Size(127, 16);
            this.Work_Square_Label.TabIndex = 329;
            this.Work_Square_Label.Text = "Workings Square";
            // 
            // ClueAmount
            // 
            this.ClueAmount.AutoSize = true;
            this.ClueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClueAmount.ForeColor = System.Drawing.Color.Crimson;
            this.ClueAmount.Location = new System.Drawing.Point(150, 10);
            this.ClueAmount.Name = "ClueAmount";
            this.ClueAmount.Size = new System.Drawing.Size(53, 17);
            this.ClueAmount.TabIndex = 416;
            this.ClueAmount.Text = "Clues:";
            // 
            // Answer_Button
            // 
            this.Answer_Button.Location = new System.Drawing.Point(277, 7);
            this.Answer_Button.Name = "Answer_Button";
            this.Answer_Button.Size = new System.Drawing.Size(94, 23);
            this.Answer_Button.TabIndex = 417;
            this.Answer_Button.Text = "Reveal Answers";
            this.Answer_Button.UseVisualStyleBackColor = true;
            this.Answer_Button.Click += new System.EventHandler(this.RevealHideAnswers);
            // 
            // Answer_Label
            // 
            this.Answer_Label.AutoSize = true;
            this.Answer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Answer_Label.ForeColor = System.Drawing.Color.Crimson;
            this.Answer_Label.Location = new System.Drawing.Point(203, 7);
            this.Answer_Label.Name = "Answer_Label";
            this.Answer_Label.Size = new System.Drawing.Size(68, 17);
            this.Answer_Label.TabIndex = 418;
            this.Answer_Label.Text = "Answers";
            // 
            // RestartButton
            // 
            this.RestartButton.AutoSize = true;
            this.RestartButton.Location = new System.Drawing.Point(377, 7);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(51, 23);
            this.RestartButton.TabIndex = 419;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.Restart);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(377, 37);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(51, 23);
            this.ResetButton.TabIndex = 420;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset);
            // 
            // SudokuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(587, 410);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.Answer_Label);
            this.Controls.Add(this.Answer_Button);
            this.Controls.Add(this.ClueAmount);
            this.Controls.Add(this.Work_Square_Label);
            this.Name = "SudokuWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WR Sudoku";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SudokuWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Work_Square_Label;
        private System.Windows.Forms.Label ClueAmount;
        private System.Windows.Forms.Button Answer_Button;
        private System.Windows.Forms.Label Answer_Label;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button ResetButton;
    }
}

