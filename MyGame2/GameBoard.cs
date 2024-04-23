using MyGame2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame2
{
    public class GameBoard
    {

        //Player1 player1;
        public PictureBox[,] circles;
        public Button[] buttonsArray;
        public int[,] statusMatrix;
        private const int rows = 6;
        private const int cols = 7;
        int x = 50;
        int y = 30;

        public GameBoard()
        {
            circles = new PictureBox[rows, cols];
            buttonsArray = new Button[cols];
            statusMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    statusMatrix[i, j] = 0;
                }
            }
        }
        public GameBoard(Player1 p1)
        {
            circles = new PictureBox[rows, cols];
            buttonsArray = new Button[cols];
            statusMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    statusMatrix[i, j] = 0;
                }
            }

            DrawButtons1(p1);
            DrawCircles1(p1);
        }

        public void DrawButtons1(Player1 p)
        {
            for (int i = 0; i < buttonsArray.Length; i++)
            {
                this.buttonsArray[i] = new Button();

                this.buttonsArray[i].BackColor = System.Drawing.SystemColors.Control;
                this.buttonsArray[i].Location = new System.Drawing.Point(x, y);
                this.buttonsArray[i].Name = "" + i;
                this.buttonsArray[i].Size = new System.Drawing.Size(39, 23);
                //this.buttonsArray[i].Text = "" + (i + 1);
                //this.buttonsArray[i].TabIndex = 43;
                this.buttonsArray[i].UseVisualStyleBackColor = true;
                this.buttonsArray[i].Click += new System.EventHandler(p.buttonClick);
                p.Controls.Add(this.buttonsArray[i]);

                x += 45;
            }
        }

        public void DrawCircles1(Player1 p)
        {
            PictureBox pb;
            x = 50;
            y = 60;
            for (int i = 0; i < statusMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < statusMatrix.GetLength(1); j++)
                {
                    pb = new PictureBox();
                    switch (statusMatrix[i, j])
                    {
                        case 0:
                            pb.Image = ((System.Drawing.Image)(Properties.Resources.gray_circle_without_background));
                            break;
                        case 1:
                            pb.Image = ((System.Drawing.Image)(Properties.Resources.blue_circle_without_background));
                            break;
                        case 2:
                            pb.Image = ((System.Drawing.Image)(Properties.Resources.red_circle_without_background));
                            break;
                    }
                    
                    pb.Location = new System.Drawing.Point(x, y);
                    pb.Name = "pictureBox" + (i + 1);
                    pb.Size = new System.Drawing.Size(39, 39);
                    pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pb.TabIndex = 36;
                    pb.TabStop = false;
                    circles[i, j] = pb;
                    p.Controls.Add(circles[i, j]);
                 
                    x += 45;
                }
                x = 50;
                y += 45;
            }
            x = 50;
            y = 60;

            
        }

        //public void DrawCircles1(Player1 p)
        //{
        //    x = 50;
        //    y = 60;
        //    for (int i = 0; i < circles.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < circles.GetLength(1); j++)
        //        {
        //            this.circles[i, j] = new PictureBox();

        //            this.circles[i, j].Image = ((System.Drawing.Image)(Properties.Resources.gray_circle_without_background));
        //            this.circles[i, j].Location = new System.Drawing.Point(x, y);
        //            this.circles[i, j].Name = "pictureBox" + (i + 1);
        //            this.circles[i, j].Size = new System.Drawing.Size(39, 39);
        //            this.circles[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        //            this.circles[i, j].TabIndex = 36;
        //            this.circles[i, j].TabStop = false;
        //            p.Controls.Add(this.circles[i, j]);

        //            x += 45;
        //        }
        //        x = 50;
        //        y += 45;
        //    }
        //    x = 50;
        //    y = 60;


        //}

        public void insertDisc(int column, Player1 p)
        {
            if (statusMatrix[0, column] != 0)
                MessageBox.Show("Column" + (column + 1) + "is already full. Choose a different Column.");
            else
            {
                for (int i = statusMatrix.GetLength(0) - 1; i >= 0; i--)
                {
                    if (statusMatrix[i, column] == 0)
                    {
                        statusMatrix[i, column] = p.getPlayerNum();
                        switch (statusMatrix[i, column])
                        {
                            case 0:
                                circles[i, column].Image = ((System.Drawing.Image)(Properties.Resources.gray_circle_without_background));
                                break;
                            case 1:
                                circles[i, column].Image = ((System.Drawing.Image)(Properties.Resources.blue_circle_without_background));
                                break;
                            case 2:
                                circles[i, column].Image = ((System.Drawing.Image)(Properties.Resources.red_circle_without_background));
                                break;
                        }
                        break;
                    }
                }

                if (checkWin(p.getPlayerNum()))
                {
                    MessageBox.Show("Player " + p.getPlayerNum() + " win!");
                }
            }
        }

        private bool checkWin(int currentPlayer)
        {
            return CheckHorizontal(currentPlayer) || CheckVertical(currentPlayer) || CheckDiagonal(currentPlayer);
        }

        private bool CheckHorizontal(int currentPlayer)
        {
            for (int row = 0; row < rows; row++)
                {
                  for (int col = 0; col <= cols - 4; col++)
                    {
                      if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row, col + 1] == currentPlayer &&
                            statusMatrix[row, col + 2] == currentPlayer &&
                            statusMatrix[row, col + 3] == currentPlayer)
                        {
                            return true;
                        }
                    }
                }
                return false;
        }

        private bool CheckVertical(int currentPlayer)
        {
            for (int row = 0; row <= rows - 4; row++)
            {
                   for (int col = 0; col < cols; col++)
                   {
                        if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row + 1, col] == currentPlayer &&
                            statusMatrix[row + 2, col] == currentPlayer &&
                           statusMatrix[row + 3, col] == currentPlayer)
                        {
                            return true;
                        }
                   }
            }
                return false;
        }

        private bool CheckDiagonal(int currentPlayer)
        {
                // Check for diagonal wins from top-left to bottom-right
            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = 0; col <= cols - 4; col++)
                {
                    if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row + 1, col + 1] == currentPlayer &&
                            statusMatrix[row + 2, col + 2] == currentPlayer &&
                            statusMatrix[row + 3, col + 3] == currentPlayer)
                    {
                            return true;
                    }
                }
            }


            // Check for diagonal wins from top-right to bottom-left
            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = cols - 1; col >= 3; col--)
                {
                    if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row + 1, col - 1] == currentPlayer &&
                            statusMatrix[row + 2, col - 2] == currentPlayer &&
                            statusMatrix[row + 3, col - 3] == currentPlayer)
                    {
                            return true;
                    }
                }
            }

            return false;
        }
    }
}

   
