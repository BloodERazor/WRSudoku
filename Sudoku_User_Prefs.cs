using System;
using System.Windows.Forms;

namespace WRSudokuRedo
{
    public partial class Sudoku_User_Prefs : Form
    {
        public Sudoku_User_Prefs()
        {
            InitializeComponent();
        }

        private void Generate(object sender, EventArgs e)
        {
            int DiffToWrite = 9;

            // add Difficulty
            switch (Difficulty.Text.Substring(0, 3))
            {
                // ~ 80%
                case "Max":
                    DiffToWrite = 80;
                    break;

                // ~ 65%
                case "Eas":
                    DiffToWrite = 65;
                    break;

                // ~ 50%
                case "Med":
                    DiffToWrite = 50;
                    break;

                // ~ 35%
                case "Har":
                    DiffToWrite = 35;
                    break;

                // ~ 21% (minimum if found) (18 or 17 for 3 x 3)
                case "Min":
                    DiffToWrite = 21;
                    break;

                default: // error
                    // replace with error and closure
                    break;
            }

            //Testing

            SudokuWindow SudoWin = new SudokuWindow(int.Parse(XBoxes.Text), int.Parse(YBoxes.Text), ShouldTimeBox.Checked, DiffToWrite); // add params
            try
            {
                Sudoku_User_Prefs.ActiveForm.Hide();
            }
            catch
            { }
            SudoWin.Show();
        }

        // Difficulty Methods
        private void DecreaseDif(object sender, EventArgs e)
        {
            switch (Difficulty.Text.Substring(0, 3))
            {
                case "Max": // already minimum difficulty
                    break;

                case "Eas":
                    Difficulty.Text = "Maximum (80% Hints)";
                    break;

                case "Med":
                    Difficulty.Text = "Easy (65% Hints)";
                    break;

                case "Har":
                    Difficulty.Text = "Medium (50% Hints)";
                    break;

                case "Min":
                    Difficulty.Text = "Hard (35% Hints)";
                    break;

                default: // error
                    break;
            }
        }

        private void IncreaseDif(object sender, EventArgs e)
        {
            switch (Difficulty.Text.Substring(0, 3))
            {
                case "Max":
                    Difficulty.Text = "Easy (65% Hints)";
                    break;

                case "Eas":
                    Difficulty.Text = "Medium (50% Hints)";
                    break;

                case "Med":
                    Difficulty.Text = "Hard (35% Hints)";
                    break;

                case "Har":
                    Difficulty.Text = "Minimum (22% Hints)";
                    break;

                case "Min": // already maximum difficulty
                    break;

                default: // error
                    break;
            }
        }

        // X Methods
        private void DecreaseX(object sender, EventArgs e)
        {
            if (int.Parse(XBoxes.Text) > 2)
            {
                XBoxes.Text = (int.Parse(XBoxes.Text) - 1).ToString();
            }
        }

        private void IncreaseX(object sender, EventArgs e)
        {
            if (int.Parse(XBoxes.Text) < 5)
            {
                XBoxes.Text = (int.Parse(XBoxes.Text) + 1).ToString();
            }
        }

        // Y Methods
        private void DecreaseY(object sender, EventArgs e)
        {
            if (int.Parse(YBoxes.Text) > 2)
            {
                YBoxes.Text = (int.Parse(YBoxes.Text) - 1).ToString();
            }
        }

        private void IncreaseY(object sender, EventArgs e)
        {
            if (int.Parse(YBoxes.Text) < 5)
            {
                YBoxes.Text = (int.Parse(YBoxes.Text) + 1).ToString();
            }
        }
    } // done
}
