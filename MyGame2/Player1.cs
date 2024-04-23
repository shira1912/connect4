using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame2
{
    public partial class Player1 : Form
    {

        private GameBoard board;
        private int playerNum = 1;
        
        public Player1()
        {
            InitializeComponent();
            board = new GameBoard(this);
        }

        public int getPlayerNum()
        {
            return playerNum;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void buttonClick(object sender, EventArgs e)
        {
            int selectedCol = int.Parse(((Button)sender).Name);
            board.insertDisc(selectedCol,this);
           
            
        }
    }
}
