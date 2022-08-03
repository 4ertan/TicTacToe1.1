using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe1._1
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turnCount = 0;
        //x'in sırası true , y'nin sırası false

        public Form1()
        {
            InitializeComponent();
            label1.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            turnCount++;
            //butona tekrar
            b.Enabled = false;
         
            bool winner = false;
            //satırlar
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text)&&(!a1.Enabled)) 
                winner = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled)) 
                winner = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled)) 
                winner = true;
            //sütun
            if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                winner = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                winner = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                winner = true;
            //çapraz
            if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                winner = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
                winner = true;
            
            if (winner)
            {
                disableAllButtons();
                string winner_text = "";
                if (turn) 
                winner_text = "O";
                else
                    winner_text = "X";
                label1.Text="Winner is "+winner_text+".\nClick to restart.";
                label1.Enabled = true;
            }
            else if (turnCount==9) {
                disableAllButtons();
                label1.Text = "It is a draw.\nClick to restart.";
                label1.Enabled = true;
            }
            else
            { 
                if (turn)
                {
                    label1.Text = "X's turn.";
                }
                else
                {
                    label1.Text = "O's turn.";
                }
            }
        }

        private void disableAllButtons()
        {
            foreach(Component c in tableLayoutPanel.Controls)
            {
                Button button = (Button)c;
                button.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            foreach (Component c in tableLayoutPanel.Controls)
            {
                Button button = (Button)c;
                button.Enabled = true;
                button.Text = "";
            }
            label1.Text = "X starts.";
            label1.Enabled = false;
            turn = true;
            turnCount = 0;
        }
    }
}
