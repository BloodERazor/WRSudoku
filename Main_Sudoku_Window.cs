using System;
using System.Drawing;
using System.Windows.Forms;

namespace WRSudokuRedo
{
    public partial class SudokuWindow : Form
    {
        private bool ShouldTime = false; // not currently used
        // Change so error values are used
        
        private int Wid = -1;
        private int Hei = -1;
        public int HintsStillRequired = 0; // Change to calculation from difficulty value
        //
        TextBox[,,] Work_Grid;
        TextBox[,] Answer_Grid;
        //

        public SudokuWindow(int x, int y, bool should_I_Time, int difficulty_ToWrite)
        {
            // Variables given in User Preferences
            Wid = x;
            Hei = y;
            ShouldTime = should_I_Time;
            HintsStillRequired = (int)(((double)difficulty_ToWrite/100) * Math.Pow(Hei * Wid, 2));
            if(difficulty_ToWrite == 21 && x == 3 && y == 3)
            {
                HintsStillRequired = 18; // may not be exact depending on how many multiple solution problems were avoided
            }
            else
            {
                if( HintsStillRequired % 2 == 1 && ( x % 2 != 1 || y % 2 != 1))
                {
                    HintsStillRequired++;
                }
            }
            //

            InitializeComponent();
            SortOutLayout(); // minimum 2 x 2
            Creation();
            CheckForNecessaryHints(); // Working Finally
            if (HintsStillRequired > 0) // error may occur if necessary hints (+ rotations) are more than or equal to HintsRequested causing infinite loop
            {
                AddRemainingRequestedHints(); // Fine
            }
            else
            {
                ClueAmount.Text = "Clues: " + (int.Parse(ClueAmount.Text.Substring(7)) - HintsStillRequired).ToString();
            }
        }

        private void SortOutLayout()
        {
            // ARRAY OF ANSWER SQUARES
            Work_Grid = new TextBox[Wid * Hei, Wid * Hei, 2];

            Answer_Grid = new TextBox[Wid * Hei, Wid * Hei];


            for (int y = 0; y < Wid * Hei; y++)//
            {
                for (int x = 0; x < Wid * Hei; x++)//
                {
                    Work_Grid[x, y, 0] = new TextBox();
                    Work_Grid[x, y, 1] = new TextBox();

                    Answer_Grid[x, y] = new TextBox();
                    //
                    this.SuspendLayout();

                    Work_Grid[x, y, 0].BackColor = Color.WhiteSmoke;
                    Work_Grid[x, y, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Work_Grid[x, y, 0].MaxLength = 2;
                    Work_Grid[x, y, 0].Name = x.ToString() + "," + y.ToString();
                    Work_Grid[x, y, 0].Size = new Size(45, 45);
                    Work_Grid[x, y, 0].TextAlign = HorizontalAlignment.Center;
                    Work_Grid[x, y, 0].TextChanged += new System.EventHandler(this.AnswerAltered);
                    Work_Grid[x, y, 0].Visible = true;

                    Work_Grid[x, y, 0].Location = new Point(20 + x * 60 + (x / Wid) * 11,
                                                              40 + y * 60 + (y / Hei) * 11);

                    //

                    Work_Grid[x, y, 1].BackColor = Color.WhiteSmoke;
                    Work_Grid[x, y, 1].Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Work_Grid[x, y, 1].MaxLength = 9;
                    Work_Grid[x, y, 1].Multiline = true;
                    Work_Grid[x, y, 1].Size = new Size(24, 45);
                    Work_Grid[x, y, 1].TextAlign = HorizontalAlignment.Center;
                    Work_Grid[x, y, 1].Visible = true;

                    Work_Grid[x, y, 1].Location = new Point(Work_Grid[x, y, 0].Location.X + 21,
                                                              Work_Grid[x, y, 0].Location.Y);
                    ////// CHANGE
                    Answer_Grid[x, y].BackColor = Color.WhiteSmoke;
                    Answer_Grid[x, y].Enabled = false;
                    Answer_Grid[x, y].Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Answer_Grid[x, y].MaxLength = 2;
                    Answer_Grid[x, y].Size = new Size(45, 45);
                    Answer_Grid[x, y].TextAlign = HorizontalAlignment.Center;
                    Answer_Grid[x, y].Visible = false;

                    Answer_Grid[x, y].Location = new Point((140 + (((Wid * Hei) - 1 + x) * 60) + ((((Wid * Hei) - 1) / Wid) + (x / Wid)) * 11), //Confusing to sort but exactly like original now
                                                            Work_Grid[0, y, 0].Location.Y);

                    this.Controls.Add(this.Answer_Grid[x, y]);

                    this.Controls.Add(this.Work_Grid[x, y, 1]); // Allows this to be shown on top
                    this.Controls.Add(this.Work_Grid[x, y, 0]);
                    this.ResumeLayout(false);
                }
            }
            //
            Work_Square_Label.Location = new Point(Work_Grid[0, 0, 0].Location.X,
                                                   15);

            ClueAmount.Location = new Point(Work_Grid[Wid + 1, 0, 0].Location.X,
                                            15);
            ClueAmount.Text += " " + HintsStillRequired;

            Answer_Label.Location = new Point(Answer_Grid[0, 0].Location.X,
                                               15);
            Answer_Button.Location = new Point(Answer_Grid[Wid, 0].Location.X,
                                               15);

            ResetButton.Location = new Point(Work_Grid[Wid, 0, 0].Location.X,
                                                   15);

            RestartButton.Location = new Point(Answer_Grid[Wid - 1, 0].Location.X + 15,
                                               15);

            // Window Changes
            /* needs re-checking
             * 2 x 2 :  600 x  330
             * 3 x 3 : 1222 x  641 
             * 4 x 4 : 2128 x 1072
             * 5 x 5 : 3186 x 1623
            */
            Size = new Size(Answer_Grid[(Hei * Wid) - 1, 0].Location.X + 78,
                            Answer_Grid[0, (Hei * Wid) - 1].Location.Y + 99);
            //
        }

        private void AnswerAltered(object sender, EventArgs e)
        {
            TextBox a = (TextBox)sender;
            int x = 0;
            int y = 0;

            for (int i = 0; i < a.Name.Length; i++)
            {
                if (a.Name.Substring(i, 1) == ",")
                {
                    x = int.Parse(a.Name.Substring(0, i));
                    y = int.Parse(a.Name.Substring(i + 1));
                }
            }
            if (Work_Grid[x, y, 0].Text == "")
            {
                Work_Grid[x, y, 1].Visible = true;

                for (int c = 0; c < Hei * Wid; c++)
                {
                    for (int b = 0; b < Hei * Wid; b++)
                    {
                        Work_Grid[b, c, 0].BackColor = Color.WhiteSmoke;
                    }
                }
            }
            else
            {
                Work_Grid[x, y, 1].Visible = false;
            }
            if (Work_Grid[x, y, 0].Text == Answer_Grid[x, y].Text)
            {
                CheckIfFinished();
            }
        }

        private void CheckIfFinished()
        {
            bool Finished = true; // until proven otherwise
            for (int y = 0; y < Wid * Hei; y++)
            {
                for (int x = 0; x < Wid * Hei; x++)
                {
                    if (Work_Grid[x, y, 0].Text != Answer_Grid[x, y].Text)
                    {
                        Finished = false;
                    }
                }
            }
            if (Finished == true)
            {
                for (int y = 0; y < Wid * Hei; y++)
                {
                    for (int x = 0; x < Wid * Hei; x++)
                    {
                        Work_Grid[x, y, 0].BackColor = Color.ForestGreen;
                    }
                }
            }
        }

        private void RevealHideAnswers(object sender, EventArgs e)
        {
            for (int y = 0; y < Wid * Hei; y++)
            {
                for (int x = 0; x < Wid * Hei; x++)
                {
                    if (Answer_Grid[x, y].Visible == false)
                    {
                        Answer_Grid[x, y].Visible = true;
                    }
                    else
                    {
                        Answer_Grid[x, y].Visible = false;
                    }
                }
            }
        }

        private void Creation()
        {
            bool WorkingNumber = true;
            bool Breaking;
            bool RestartFunction = false;

            int ToStopErrors = 0;
            Random number = new Random();

            // TO-DO
            while (true)
            {
                for (int y = 0; y < Wid * Hei; y++)
                {
                    for (int x = 0; x < Wid * Hei; x++)
                    {
                        ToStopErrors = 500;
                        RestartFunction = false;
                        //
                        while (true)
                        {
                            while (true)
                            {
                                Breaking = false;
                                WorkingNumber = true;
                                Answer_Grid[x, y].Text = number.Next(1, (Wid * Hei) + 1).ToString();

                                //WID
                                if (x != 0)
                                {
                                    for (int PrevX = x - 1; PrevX >= 0; PrevX--)
                                    {
                                        if (Answer_Grid[x, y].Text == Answer_Grid[PrevX, y].Text)
                                        {
                                            WorkingNumber = false;
                                            Breaking = true;
                                            break;
                                        }
                                    }
                                }
                                if (Breaking == true)
                                {
                                    break;
                                }

                                //HEI
                                if (y != 0)
                                {
                                    for (int PrevY = y - 1; PrevY >= 0; PrevY--)
                                    {
                                        if (Answer_Grid[x, y].Text == Answer_Grid[x, PrevY].Text)
                                        {
                                            WorkingNumber = false;
                                            Breaking = true;
                                            break;
                                        }
                                    }
                                }
                                if (Breaking == true)
                                {
                                    break;
                                }

                                //BOX
                                if (y % Hei != 0)
                                {
                                    int LX = x / Wid;
                                    for (int PrevY = y - 1; PrevY % Hei != Hei - 1 && PrevY != -1; PrevY--)// being tested (currently errors)
                                    {
                                        for (int LRX = LX * Wid; LRX < (LX + 1) * Wid; LRX++)
                                        {
                                            if (LRX != x)
                                            {
                                                if (Answer_Grid[x, y].Text == Answer_Grid[LRX, PrevY].Text)
                                                {
                                                    WorkingNumber = false;
                                                    Breaking = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (Breaking == true)
                                        {
                                            break;
                                        }
                                    }
                                }

                                break;

                            }
                            if (WorkingNumber == true)
                            {
                                break;
                            }
                            ToStopErrors--;
                            if (ToStopErrors == 0)
                            {
                                RestartFunction = true;
                                break;
                            }
                            //
                        }
                        if (RestartFunction == true)
                        {
                            break;
                        }
                    }
                    if (RestartFunction == true)
                    {
                        break;
                    }
                }
                if (WorkingNumber == true)
                {
                    break;
                }
            }
        }

        private void CheckForNecessaryHints() // currently errors
        {
            bool middleCasePossible = true;

            Random rand = new Random();

            int[,] Checking = new int[Wid * Hei - 1, Wid * Hei]; // number being investigated - 1, x coord = y coord (then coords reversed)

            //For ordering by x values
            for (int y = 0; y < Wid * Hei; y++)
            {
                for (int x = 0; x < Wid * Hei; x++)
                {
                    if (int.Parse(Answer_Grid[x, y].Text) != Wid * Hei) // ignore top value to save time
                    {
                        Checking[int.Parse(Answer_Grid[x, y].Text) - 1, x] = y;
                    }
                }
            }
            //Checking
            for (int number = 0; number < (Wid * Hei) - 1; number++)// number being checked
            {
                for (int BoxColumn = 0; BoxColumn < Hei; BoxColumn++) // BoxColumn being checked 
                {
                    for (int LeftCheck = (Wid * BoxColumn); LeftCheck < Wid - 1 + (Wid * BoxColumn); LeftCheck++)
                    {
                        for (int RightCheck = LeftCheck + 1; RightCheck < Wid + (Wid * BoxColumn); RightCheck++)
                        {
                            if (Answer_Grid[LeftCheck, Checking[number, RightCheck]].Text ==
                               Answer_Grid[RightCheck, Checking[number, LeftCheck]].Text)
                            {
                                if (Work_Grid[LeftCheck, Checking[number, LeftCheck], 0].Text == "" &&
                                   Work_Grid[LeftCheck, Checking[number, RightCheck], 0].Text == "" &&
                                   Work_Grid[RightCheck, Checking[number, LeftCheck], 0].Text == "" &&
                                   Work_Grid[RightCheck, Checking[number, RightCheck], 0].Text == "")
                                {
                                    if (Hei % 2 == 0 || Wid % 2 == 0)
                                    {
                                        middleCasePossible = false; // impossible
                                    }
                                    switch (rand.Next(0, 4))
                                    {
                                        case 0:
                                            Work_Grid[LeftCheck, Checking[number, LeftCheck], 0].Text =
                                            Answer_Grid[LeftCheck, Checking[number, LeftCheck]].Text;

                                            Work_Grid[LeftCheck, Checking[number, LeftCheck], 0].Enabled = false;
                                            Work_Grid[LeftCheck, Checking[number, LeftCheck], 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || LeftCheck != (Wid * Hei) / 2 || LeftCheck != Checking[number, LeftCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck], 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck]].Text;

                                                Work_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck], 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck], 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;

                                        case 1:

                                            Work_Grid[LeftCheck, Checking[number, RightCheck], 0].Text =
                                            Answer_Grid[LeftCheck, Checking[number, RightCheck]].Text;

                                            Work_Grid[LeftCheck, Checking[number, RightCheck], 0].Enabled = false;
                                            Work_Grid[LeftCheck, Checking[number, RightCheck], 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || LeftCheck != (Wid * Hei) / 2 || LeftCheck != Checking[number, RightCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, RightCheck], 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, RightCheck]].Text;

                                                Work_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, RightCheck], 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - LeftCheck, (Wid * Hei) - 1 - Checking[number, RightCheck], 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;

                                        case 2:

                                            Work_Grid[RightCheck, Checking[number, LeftCheck], 0].Text =
                                            Answer_Grid[RightCheck, Checking[number, LeftCheck]].Text;

                                            Work_Grid[RightCheck, Checking[number, LeftCheck], 0].Enabled = false;
                                            Work_Grid[RightCheck, Checking[number, LeftCheck], 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || RightCheck != (Wid * Hei) / 2 || RightCheck != Checking[number, LeftCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck], 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck]].Text;

                                                Work_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck], 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, LeftCheck], 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;

                                        case 3:

                                            Work_Grid[RightCheck, Checking[number, RightCheck], 0].Text =
                                            Answer_Grid[RightCheck, Checking[number, RightCheck]].Text;

                                            Work_Grid[RightCheck, Checking[number, RightCheck], 0].Enabled = false;
                                            Work_Grid[RightCheck, Checking[number, RightCheck], 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || RightCheck != (Wid * Hei) / 2 || RightCheck != Checking[number, RightCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, RightCheck], 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, RightCheck]].Text;

                                                Work_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, RightCheck], 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - RightCheck, (Wid * Hei) - 1 - Checking[number, RightCheck], 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //For ordering by y values
            for (int y = 0; y < Wid * Hei; y++)
            {
                for (int x = 0; x < Wid * Hei; x++)
                {
                    if (Answer_Grid[x, y].Text != (Wid * Hei).ToString()) // ignore top value to save time
                    {
                        Checking[int.Parse(Answer_Grid[x, y].Text) - 1, y] = x;
                    }
                }
            }

            //Checking
            for (int number = 0; number < (Wid * Hei) - 1; number++) // Number being checked
            {
                for (int BoxRow = 0; BoxRow < Wid; BoxRow++) // BoxRow being checked 
                {
                    for (int LeftCheck = (Hei * BoxRow); LeftCheck < Hei - 1 + (Hei * BoxRow); LeftCheck++)
                    {
                        for (int RightCheck = LeftCheck + 1; RightCheck < Hei + (Hei * BoxRow); RightCheck++)
                        {
                            if (Answer_Grid[Checking[number, RightCheck], LeftCheck].Text ==
                                Answer_Grid[Checking[number, LeftCheck], RightCheck].Text)
                            {
                                if (Work_Grid[Checking[number, LeftCheck], LeftCheck, 0].Text == "" &&
                                   Work_Grid[Checking[number, LeftCheck], RightCheck, 0].Text == "" &&
                                   Work_Grid[Checking[number, RightCheck], LeftCheck, 0].Text == "" &&
                                   Work_Grid[Checking[number, RightCheck], RightCheck, 0].Text == "")
                                {
                                    switch (rand.Next(0, 4))
                                    {
                                        case 0:

                                            Work_Grid[Checking[number, LeftCheck], LeftCheck, 0].Text =
                                            Answer_Grid[Checking[number, LeftCheck], LeftCheck].Text;

                                            Work_Grid[Checking[number, LeftCheck], LeftCheck, 0].Enabled = false;
                                            Work_Grid[Checking[number, LeftCheck], LeftCheck, 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || LeftCheck != (Wid * Hei) / 2 || LeftCheck != Checking[number, LeftCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - LeftCheck, 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - LeftCheck].Text;

                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - LeftCheck, 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - LeftCheck, 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;

                                        case 1:

                                            Work_Grid[Checking[number, LeftCheck], RightCheck, 0].Text =
                                            Answer_Grid[Checking[number, LeftCheck], RightCheck].Text;

                                            Work_Grid[Checking[number, LeftCheck], RightCheck, 0].Enabled = false;
                                            Work_Grid[Checking[number, LeftCheck], RightCheck, 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || RightCheck != (Wid * Hei) / 2 || RightCheck != Checking[number, LeftCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - RightCheck, 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - RightCheck].Text;

                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - RightCheck, 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, LeftCheck], (Wid * Hei) - 1 - RightCheck, 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;

                                        case 2:

                                            Work_Grid[Checking[number, RightCheck], LeftCheck, 0].Text =
                                            Answer_Grid[Checking[number, RightCheck], LeftCheck].Text;

                                            Work_Grid[Checking[number, RightCheck], LeftCheck, 0].Enabled = false;
                                            Work_Grid[Checking[number, RightCheck], LeftCheck, 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || LeftCheck != (Wid * Hei) / 2 || LeftCheck != Checking[number, RightCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - LeftCheck, 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - LeftCheck].Text;

                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - LeftCheck, 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - LeftCheck, 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;

                                        case 3:

                                            Work_Grid[Checking[number, RightCheck], RightCheck, 0].Text =
                                            Answer_Grid[Checking[number, RightCheck], RightCheck].Text;

                                            Work_Grid[Checking[number, RightCheck], RightCheck, 0].Enabled = false;
                                            Work_Grid[Checking[number, RightCheck], RightCheck, 1].Visible = false;
                                            HintsStillRequired--;

                                            if (!middleCasePossible || RightCheck != (Wid * Hei) / 2 || RightCheck != Checking[number, RightCheck])
                                            {
                                                //rotation
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - RightCheck, 0].Text =
                                                Answer_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - RightCheck].Text;

                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - RightCheck, 0].Enabled = false;
                                                Work_Grid[(Wid * Hei) - 1 - Checking[number, RightCheck], (Wid * Hei) - 1 - RightCheck, 1].Visible = false;
                                                //
                                                HintsStillRequired--;
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //END
        }

        private void AddRemainingRequestedHints()
        {
            Random Rand = new Random();
            int x = -1;
            int y = -1;
            if(HintsStillRequired % 2 == 1 && Wid % 2 == 1 && Hei % 2 == 1)
            {
                Work_Grid[(Wid * Hei)/2, (Wid * Hei) / 2, 0].Text =
                Answer_Grid[(Wid * Hei) / 2, (Wid * Hei) / 2].Text;

                Work_Grid[(Wid * Hei) / 2, (Wid * Hei) / 2, 0].Enabled = false;
                Work_Grid[(Wid * Hei) / 2, (Wid * Hei) / 2, 1].Visible = false;
                HintsStillRequired--;
            }

            while (HintsStillRequired != 0 && HintsStillRequired != -1)// needs editing
            {
                x = Rand.Next(0, Wid * Hei);
                y = Rand.Next(0, Wid * Hei);
                if (x != (Wid * Hei) / 2 || y != (Wid * Hei) / 2) // rounds values down
                {
                    if (Work_Grid[x, y, 0].Enabled == true)
                    {
                        Work_Grid[x, y, 0].Text = Answer_Grid[x, y].Text;

                        Work_Grid[(Wid * Hei) - x - 1, (Wid * Hei) - y - 1, 0].Text =
                        Answer_Grid[(Wid * Hei) - x - 1, (Wid * Hei) - y - 1].Text;

                        Work_Grid[x, y, 0].Enabled = false;
                        Work_Grid[x, y, 1].Visible = false;
                        Work_Grid[(Wid * Hei) - x - 1, (Wid * Hei) - y - 1, 0].Enabled = false;
                        Work_Grid[(Wid * Hei) - x - 1, (Wid * Hei) - y - 1, 1].Visible = false;

                        HintsStillRequired -= 2;
                    }
                }
            }
            if (HintsStillRequired == 1)
            {
                // throw error
            }
        }

        private void Restart(object sender, EventArgs e) // Restart program
        {
            Application.Restart();
        }

        private void Reset(object sender, EventArgs e) // Reset current Sudoku
        {
            for(int y = 0; y < Wid * Hei; y++)
            {
                for(int x = 0; x < Wid * Hei; x++)
                {
                    if(Work_Grid[x, y, 0].Enabled == true)
                    {
                        Work_Grid[x, y, 0].Text = "";
                        Work_Grid[x, y, 1].Text = "";
                    }
                }
            }
        }

        private void SudokuWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
