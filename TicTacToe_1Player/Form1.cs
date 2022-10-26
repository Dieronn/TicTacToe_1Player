using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_1Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Restart();
        }

        private bool player = false;   //0 - player number 1, 1 - player number 2 
        private int playerwins = 0;
        private int pcwins = 0;
        List<Button> buttons; 
        Random rand = new Random();

        private void RandMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Text = "O";
                buttons.RemoveAt(index); // remove that button from the list by index
                player = false;
                CheckWin();            
                Randmove.Stop();
            }         
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (player == false)
            {
                button.Text = "X";
                buttons.Remove(button);
                player = true;
                CheckWin();
                if (lblWinner.Visible == false) Randmove.Start();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void CheckWin()
        {
            Disable();
            if (buttons.Count == 0)
            {
                lblWinner.Text = "NO ONE WON";
                lblWinner.Visible = true;
                Randmove.Stop();
            }

            if (SearchFor("X")==true)
            {
                lblWinner.Text = "PLAYER WON";
                lblWinner.Visible = true;
                playerwins++;
                lblwinplayer.Text = "Player:" + playerwins.ToString();
                lblwinpc.Text = "Computer:" + pcwins.ToString();
                Randmove.Stop();
            }

            if (SearchFor("O")==true)
            {
                lblWinner.Text = "COMPUTER WON";
                lblWinner.Visible = true;
                pcwins++;
                lblwinplayer.Text = "Player:" + playerwins.ToString();
                lblwinpc.Text = "Computer:" + pcwins.ToString();
                Randmove.Stop();
            }

            if (player == true) lblplayer.Text = "COMPUTER";
            if (player == false) lblplayer.Text = "PLAYER";

            if (lblWinner.Visible == false)
            {
                foreach (Button button in buttons)
                {
                    button.Enabled = true;
                }
            }
        }

        private void Disable()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }
        private void Restart()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "?";
            }
            lblplayer.Text = "PLAYER";
            player = false;
            lblWinner.Visible = false;
        }
        private bool SearchFor(string symbol)
        {
            if (button1.Text == symbol && button2.Text == symbol && button3.Text == symbol ||
                button4.Text == symbol && button5.Text == symbol && button6.Text == symbol ||
                button7.Text == symbol && button9.Text == symbol && button8.Text == symbol ||
                button1.Text == symbol && button4.Text == symbol && button7.Text == symbol ||
                button2.Text == symbol && button5.Text == symbol && button8.Text == symbol ||
                button3.Text == symbol && button6.Text == symbol && button9.Text == symbol ||
                button1.Text == symbol && button5.Text == symbol && button9.Text == symbol ||
                button3.Text == symbol && button5.Text == symbol && button7.Text == symbol)
            {
                return true;
            }
            else return false;
        }
    }
}
