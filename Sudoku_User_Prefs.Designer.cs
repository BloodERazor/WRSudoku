namespace WRSudokuRedo
{
    partial class Sudoku_User_Prefs
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
            this.Title = new System.Windows.Forms.Label();
            this.IncX = new System.Windows.Forms.Button();
            this.XBoxes = new System.Windows.Forms.TextBox();
            this.DecX = new System.Windows.Forms.Button();
            this.DecY = new System.Windows.Forms.Button();
            this.YBoxes = new System.Windows.Forms.TextBox();
            this.IncY = new System.Windows.Forms.Button();
            this.DimTag1 = new System.Windows.Forms.Label();
            this.DimTag2 = new System.Windows.Forms.Label();
            this.DimTag3 = new System.Windows.Forms.Label();
            this.TimeTag = new System.Windows.Forms.Label();
            this.ShouldTimeBox = new System.Windows.Forms.CheckBox();
            this.DifTag = new System.Windows.Forms.Label();
            this.DecDiff = new System.Windows.Forms.Button();
            this.Difficulty = new System.Windows.Forms.TextBox();
            this.IncDiff = new System.Windows.Forms.Button();
            this.GenerateSudoku = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Crimson;
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Margin = new System.Windows.Forms.Padding(0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(148, 16);
            this.Title.TabIndex = 329;
            this.Title.Text = "Sudoku Preferences";
            // 
            // IncX
            // 
            this.IncX.Location = new System.Drawing.Point(134, 33);
            this.IncX.Name = "IncX";
            this.IncX.Size = new System.Drawing.Size(15, 22);
            this.IncX.TabIndex = 331;
            this.IncX.Text = ">";
            this.IncX.UseVisualStyleBackColor = true;
            this.IncX.Click += new System.EventHandler(this.IncreaseX);
            // 
            // XBoxes
            // 
            this.XBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XBoxes.Location = new System.Drawing.Point(113, 34);
            this.XBoxes.Multiline = true;
            this.XBoxes.Name = "XBoxes";
            this.XBoxes.Size = new System.Drawing.Size(22, 20);
            this.XBoxes.TabIndex = 334;
            this.XBoxes.Text = "3";
            this.XBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DecX
            // 
            this.DecX.Location = new System.Drawing.Point(99, 33);
            this.DecX.Name = "DecX";
            this.DecX.Size = new System.Drawing.Size(15, 22);
            this.DecX.TabIndex = 335;
            this.DecX.Text = "<";
            this.DecX.UseVisualStyleBackColor = true;
            this.DecX.Click += new System.EventHandler(this.DecreaseX);
            // 
            // DecY
            // 
            this.DecY.Location = new System.Drawing.Point(182, 33);
            this.DecY.Name = "DecY";
            this.DecY.Size = new System.Drawing.Size(15, 22);
            this.DecY.TabIndex = 338;
            this.DecY.Text = "<";
            this.DecY.UseVisualStyleBackColor = true;
            this.DecY.Click += new System.EventHandler(this.DecreaseY);
            // 
            // YBoxes
            // 
            this.YBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YBoxes.Location = new System.Drawing.Point(196, 34);
            this.YBoxes.Multiline = true;
            this.YBoxes.Name = "YBoxes";
            this.YBoxes.Size = new System.Drawing.Size(22, 20);
            this.YBoxes.TabIndex = 337;
            this.YBoxes.Text = "3";
            this.YBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IncY
            // 
            this.IncY.Location = new System.Drawing.Point(217, 33);
            this.IncY.Name = "IncY";
            this.IncY.Size = new System.Drawing.Size(15, 22);
            this.IncY.TabIndex = 336;
            this.IncY.Text = ">";
            this.IncY.UseVisualStyleBackColor = true;
            this.IncY.Click += new System.EventHandler(this.IncreaseY);
            // 
            // DimTag1
            // 
            this.DimTag1.AutoSize = true;
            this.DimTag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimTag1.ForeColor = System.Drawing.Color.Firebrick;
            this.DimTag1.Location = new System.Drawing.Point(12, 35);
            this.DimTag1.Name = "DimTag1";
            this.DimTag1.Size = new System.Drawing.Size(83, 15);
            this.DimTag1.TabIndex = 339;
            this.DimTag1.Text = "Dimensions";
            // 
            // DimTag2
            // 
            this.DimTag2.AutoSize = true;
            this.DimTag2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimTag2.ForeColor = System.Drawing.Color.Firebrick;
            this.DimTag2.Location = new System.Drawing.Point(155, 35);
            this.DimTag2.Name = "DimTag2";
            this.DimTag2.Size = new System.Drawing.Size(21, 15);
            this.DimTag2.TabIndex = 340;
            this.DimTag2.Text = "by";
            // 
            // DimTag3
            // 
            this.DimTag3.AutoSize = true;
            this.DimTag3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimTag3.ForeColor = System.Drawing.Color.Firebrick;
            this.DimTag3.Location = new System.Drawing.Point(238, 35);
            this.DimTag3.Name = "DimTag3";
            this.DimTag3.Size = new System.Drawing.Size(38, 15);
            this.DimTag3.TabIndex = 341;
            this.DimTag3.Text = "(2-5)";
            // 
            // TimeTag
            // 
            this.TimeTag.AutoSize = true;
            this.TimeTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTag.ForeColor = System.Drawing.Color.Firebrick;
            this.TimeTag.Location = new System.Drawing.Point(12, 87);
            this.TimeTag.Name = "TimeTag";
            this.TimeTag.Size = new System.Drawing.Size(95, 15);
            this.TimeTag.TabIndex = 342;
            this.TimeTag.Text = "Time Yourself";
            // 
            // ShouldTimeBox
            // 
            this.ShouldTimeBox.AutoSize = true;
            this.ShouldTimeBox.Enabled = false;
            this.ShouldTimeBox.Location = new System.Drawing.Point(112, 89);
            this.ShouldTimeBox.Name = "ShouldTimeBox";
            this.ShouldTimeBox.Size = new System.Drawing.Size(15, 14);
            this.ShouldTimeBox.TabIndex = 343;
            this.ShouldTimeBox.UseVisualStyleBackColor = true;
            // 
            // DifTag
            // 
            this.DifTag.AutoSize = true;
            this.DifTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifTag.ForeColor = System.Drawing.Color.Firebrick;
            this.DifTag.Location = new System.Drawing.Point(12, 61);
            this.DifTag.Name = "DifTag";
            this.DifTag.Size = new System.Drawing.Size(62, 15);
            this.DifTag.TabIndex = 344;
            this.DifTag.Text = "Difficulty";
            // 
            // DecDiff
            // 
            this.DecDiff.Location = new System.Drawing.Point(99, 58);
            this.DecDiff.Name = "DecDiff";
            this.DecDiff.Size = new System.Drawing.Size(15, 22);
            this.DecDiff.TabIndex = 347;
            this.DecDiff.Text = "<";
            this.DecDiff.UseVisualStyleBackColor = true;
            this.DecDiff.Click += new System.EventHandler(this.IncreaseDif);
            // 
            // Difficulty
            // 
            this.Difficulty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Difficulty.Location = new System.Drawing.Point(113, 59);
            this.Difficulty.Multiline = true;
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(139, 20);
            this.Difficulty.TabIndex = 346;
            this.Difficulty.Text = "Minimum (21 % Hints)";
            this.Difficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IncDiff
            // 
            this.IncDiff.Location = new System.Drawing.Point(251, 58);
            this.IncDiff.Name = "IncDiff";
            this.IncDiff.Size = new System.Drawing.Size(15, 22);
            this.IncDiff.TabIndex = 345;
            this.IncDiff.Text = ">";
            this.IncDiff.UseVisualStyleBackColor = true;
            this.IncDiff.Click += new System.EventHandler(this.DecreaseDif);
            // 
            // GenerateSudoku
            // 
            this.GenerateSudoku.Location = new System.Drawing.Point(133, 84);
            this.GenerateSudoku.Name = "GenerateSudoku";
            this.GenerateSudoku.Size = new System.Drawing.Size(133, 23);
            this.GenerateSudoku.TabIndex = 348;
            this.GenerateSudoku.Text = "Generate Sudoku";
            this.GenerateSudoku.UseVisualStyleBackColor = true;
            this.GenerateSudoku.Click += new System.EventHandler(this.Generate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 349;
            this.label1.Text = "(Disabled)";
            // 
            // Sudoku_User_Prefs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenerateSudoku);
            this.Controls.Add(this.DecDiff);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.IncDiff);
            this.Controls.Add(this.DifTag);
            this.Controls.Add(this.ShouldTimeBox);
            this.Controls.Add(this.TimeTag);
            this.Controls.Add(this.DimTag3);
            this.Controls.Add(this.DimTag2);
            this.Controls.Add(this.DimTag1);
            this.Controls.Add(this.DecY);
            this.Controls.Add(this.YBoxes);
            this.Controls.Add(this.IncY);
            this.Controls.Add(this.DecX);
            this.Controls.Add(this.XBoxes);
            this.Controls.Add(this.IncX);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(300, 160);
            this.MinimumSize = new System.Drawing.Size(300, 160);
            this.Name = "Sudoku_User_Prefs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku Preferences";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button IncX;
        private System.Windows.Forms.TextBox XBoxes;
        private System.Windows.Forms.Button DecX;
        private System.Windows.Forms.Button DecY;
        private System.Windows.Forms.TextBox YBoxes;
        private System.Windows.Forms.Button IncY;
        private System.Windows.Forms.Label DimTag1;
        private System.Windows.Forms.Label DimTag2;
        private System.Windows.Forms.Label DimTag3;
        private System.Windows.Forms.Label TimeTag;
        private System.Windows.Forms.CheckBox ShouldTimeBox;
        private System.Windows.Forms.Label DifTag;
        private System.Windows.Forms.Button DecDiff;
        private System.Windows.Forms.TextBox Difficulty;
        private System.Windows.Forms.Button IncDiff;
        private System.Windows.Forms.Button GenerateSudoku;
        private System.Windows.Forms.Label label1;
    }
}