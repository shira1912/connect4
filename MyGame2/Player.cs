using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{
    public partial class Player : Form
    {
        private int playerNum = 1;
        private PictureBox[,] circles;
        private Button[] buttonsArray;
        private const int rows = 6;
        private const int cols = 7;
        int x = 50;
        int y = 30;
        Client client;

        public Player(Client client)
        {
            InitializeComponent();
            buttonsArray = new Button[cols];
            circles = new PictureBox[rows, cols];
            DrawButtons(); // draw buttons
            DrawCircles(); // draw circles
            this.client = client;
        }

        public int getPlayerNum()
        {
            return playerNum;
        }

        public void buttonClick(object sender, EventArgs e)
        {
            int selectedCol = int.Parse(((Button)sender).Name);
            client.SendMessage("Insert," + selectedCol);

        }

        public void DrawButtons()
        {
            for (int i = 0; i < buttonsArray.Length; i++)
            {
                this.buttonsArray[i] = new Button();

                this.buttonsArray[i].BackColor = System.Drawing.SystemColors.Control;
                this.buttonsArray[i].Location = new System.Drawing.Point(x, y);
                this.buttonsArray[i].Name = "" + i;
                this.buttonsArray[i].Size = new System.Drawing.Size(39, 23);
                this.buttonsArray[i].Text = "";
                this.buttonsArray[i].UseVisualStyleBackColor = true;
                this.buttonsArray[i].Enabled = false;
                this.buttonsArray[i].Click += new System.EventHandler(buttonClick);
                this.Controls.Add(this.buttonsArray[i]);

                x += 45;
            }
        }

        public void DrawCircles()
        {
            x = 50;
            y = 60;
            for (int i = 0; i < circles.GetLength(0); i++)
            {
                for (int j = 0; j < circles.GetLength(1); j++)
                {
                    this.circles[i, j] = new PictureBox();

                    this.circles[i, j].Image = ((System.Drawing.Image)(Properties.Resources.gray_circle_without_background));
                    this.circles[i, j].Location = new System.Drawing.Point(x, y);
                    this.circles[i, j].Name = "pictureBox" + (i + 1);
                    this.circles[i, j].Size = new System.Drawing.Size(39, 39);
                    this.circles[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    this.circles[i, j].TabIndex = 36;
                    this.circles[i, j].TabStop = false;
                    this.Controls.Add(this.circles[i, j]);

                    x += 45;
                }
                x = 50;
                y += 45;
            }
            x = 50;
            y = 60;

        }

        public void UpdateCircle(int row, int col, int currentPlayer)
        {
            if (row >= 0) // there is an avaliable row
            {
                switch (currentPlayer)
                {
                    case 0:
                        this.circles[row, col].Image = ((System.Drawing.Image)(Properties.Resources.gray_circle_without_background));
                        break;
                    case 1:
                        this.circles[row, col].Image = ((System.Drawing.Image)(Properties.Resources.blue_circle_without_background));
                        break;
                    case 2:
                        this.circles[row, col].Image = ((System.Drawing.Image)(Properties.Resources.red_circle_without_background));
                        break;
                }
            }
            else MessageBox.Show("Column" + (col + 1) + "is already full. Choose a different Column.");
        }

        public void SetPlayerColorPic(int currentPlayer)
        {
            switch (currentPlayer)
            {
                case 1:
                    this.playerColorPic.Image = ((System.Drawing.Image)(Properties.Resources.blue_circle_without_background));
                    break;
                case 2:
                    this.playerColorPic.Image = ((System.Drawing.Image)(Properties.Resources.red_circle_without_background));
                    break;
            }
        }

        public void TurnPic(int currentPlayer)
        {
            switch (currentPlayer)
            {
                case 1:
                    this.turnPicBox.Image = ((System.Drawing.Image)(Properties.Resources.blue_circle_without_background));
                    break;
                case 2:
                    this.turnPicBox.Image = ((System.Drawing.Image)(Properties.Resources.red_circle_without_background));
                    break;
            }
        }

        public void SwitchTurnPic(int currentPlayer)
        {
            switch (currentPlayer)
            {
                case 2:
                    this.turnPicBox.Image = ((System.Drawing.Image)(Properties.Resources.blue_circle_without_background));
                    break;
                case 1:
                    this.turnPicBox.Image = ((System.Drawing.Image)(Properties.Resources.red_circle_without_background));
                    break;
            }
        }

        public void DeleteWaitingLabel()
        {
            this.waitingLabel.Hide();
        }

        public void EnabledButtons(bool enabled)
        {
            for (int i = 0; i < buttonsArray.Length; i++)
            {
                this.buttonsArray[i].Enabled = enabled;
                if (enabled)
                {
                    this.buttonsArray[i].Text = "↓";
                }
                else
                {
                    this.buttonsArray[i].Text = "";
                }
            }
        }

        private void Exit(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }
    }
}
