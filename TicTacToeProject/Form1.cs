using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeProject.Properties;

namespace TicTacToeProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enPlayer
        {
            Player1,
            Player2
        }

        enPlayer DefaultPlayer = enPlayer.Player1;

        enum enWinner
        { 
            Player1,
            Player2,
            Draw,
            InProgress

        }

        struct stGameInfo
        {
            public enWinner Winner;
            public short CountPlay;
            public bool GameEnd;
        }

        stGameInfo GameInfo;

        bool Winner(Button btn1, Button btn2, Button btn3)
        {
            //if (Convert.ToString(btn1.Tag) != "?"
            //    &&
            //    (btn1.Tag == btn2.Tag && btn1.Tag == btn3.Tag && btn1.Tag == btn4.Tag && btn1.Tag == btn5.Tag
            //    && btn1.Tag == btn6.Tag && btn1.Tag == btn7.Tag && btn1.Tag == btn8.Tag && btn1.Tag == btn9.Tag))
            //{
            //    lblWinner.Text = "Draw";
            //    lblPlayerName.Text = "Game Over";
            //
            //    GameInfo.Winner = enWinner.Draw;
            //    MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            //    GameInfo.GameEnd = true;
            //    return true;
            //}


            if (Convert.ToString(btn1.Tag) != "?" && (btn1.Tag == btn2.Tag && btn1.Tag == btn3.Tag))
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;



                if (Convert.ToString(btn1.Tag) == "X")
                {
                    lblWinner.Text = "Player 1";
                    lblPlayerName.Text = "Game Over";

                    GameInfo.Winner = enWinner.Player1;
                    MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GameInfo.GameEnd = true;
                    return true;
                }
                else
                {
                    lblWinner.Text = "Player 2";
                    lblPlayerName.Text = "Game Over";

                    GameInfo.Winner = enWinner.Player2;
                    MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GameInfo.GameEnd = true;
                    return true;
                }

            }

            GameInfo.GameEnd = false;
            return false;
        }
        void GameWinner()
        {
            if (Winner(btn1, btn2, btn3))
                return;

            if (Winner(btn4, btn5, btn6))
                return;

            if (Winner(btn7, btn8, btn9))
                return;

            if (Winner(btn1, btn4, btn7))
                return;

            if (Winner(btn2, btn5, btn8))
                return;

            if (Winner(btn3, btn6, btn9))
                return;

            if (Winner(btn1, btn5, btn9))
                return;

            if (Winner(btn3, btn5, btn7))
                return;

            if (GameInfo.CountPlay == 9)
            {
                lblWinner.Text = "   Draw";
                lblPlayerName.Text = "Game Over";

                GameInfo.Winner = enWinner.Draw;
                MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GameInfo.GameEnd = true;
                return;
            }

        }

        void ChangeImage(Button btn)
        {
            if (GameInfo.GameEnd != true && Convert.ToString(btn.Tag) == "?")
            {
                switch (DefaultPlayer)
                {
                    case enPlayer.Player1:
                        btn.Tag = "X";
                        btn.BackgroundImage = Resources.X;
                        DefaultPlayer = enPlayer.Player2;
                        lblPlayerName.Text = "Player 2";
                        GameInfo.CountPlay++;
                        GameWinner();

                        break;
                    case enPlayer.Player2:
                        btn.Tag = "O";
                        btn.BackgroundImage = Resources.O;
                        DefaultPlayer = enPlayer.Player1;
                        lblPlayerName.Text = "Player 1";
                        GameInfo.CountPlay++;
                        GameWinner();
                        break;
                }
            }
            else
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ResetButton(Button btn)
        {
            btn.BackgroundImage = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        void RestartGame()
        {
            ResetButton(btn1);
            ResetButton(btn2);
            ResetButton(btn3);
            ResetButton(btn4);
            ResetButton(btn5);
            ResetButton(btn6);
            ResetButton(btn7);
            ResetButton(btn8);
            ResetButton(btn9);


            lblPlayerName.Text = "Player 1";
            DefaultPlayer = enPlayer.Player1;
            lblWinner.Text = "In Progress";
            GameInfo.CountPlay = 0;
            GameInfo.Winner = enWinner.InProgress;
            GameInfo.GameEnd = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;

            Pen Pen = new Pen(White);
            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // Lenght
            e.Graphics.DrawLine(Pen, 510, 110, 510, 490);
            e.Graphics.DrawLine(Pen, 700, 110, 700, 490);


            // Width
            e.Graphics.DrawLine(Pen, 330, 233, 875, 233);
            e.Graphics.DrawLine(Pen, 330, 366, 875, 366);




        }
    }
}
