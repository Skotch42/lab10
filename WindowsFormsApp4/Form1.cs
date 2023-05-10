using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        string[] team = new string[8] { "Real Madrid", "Manchester United", "Arsenal", "Chelsea", "Bayern Munich", "Liverpool", "Manchester City", "Barcelona" };
        double[] l = new double[8];
        int a, b;
        Random generator2 = new Random();

        private void playGames(int i)
        {
            switch (i)
            {
                case 0:
                    playRound(l[0], l[1], 0, 1);
                    playRound(l[2], l[3], 2, 3);
                    playRound(l[4], l[5], 4, 5);
                    playRound(l[6], l[7], 6, 7);
                    break;
                case 1:
                    playRound(l[0], l[2], 0, 2);
                    playRound(l[4], l[6], 4, 6);
                    break;
                case 2:
                    playRound(l[0], l[4], 0, 4);
                    break;
                default:
                    break;
            }
        }

        void setWinner(int i, int j, int a)
        {
            string labelName = "label" + (i + 1).ToString() + (j + 1).ToString();
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)Controls[labelName];
            label.Text += team[i] + " (" + a.ToString() + " goals)";
            label.Visible = true;

            if ((i == 0) && (j == 4))
            {
                label.ForeColor = Color.Green;
            }
        }

        private void playRound(double l1, double l2, int i, int j)
        {
            a = goals(l1, generator2);
            b = goals(l2, generator2);

            if (a > b)
            {
                l[i] = l[i];
                team[i] = team[i];

                setWinner(i, j, a);
            }

            if (a < b)
            {
                l[i] = l[j];
                team[i] = team[j];

                setWinner(i, j, b);
            }

            if (a == b)
            {
                playRound(l[i], l[j], i, j);
            }
        }

        public int goals(double lambda, Random rnd)
        {
            int count = 0;
            double s = 0;

            while (s > -lambda)
            {
                s += Math.Log(rnd.NextDouble());
                count++;
            }

            return count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            team = new string[8] { "Real Madrid", "Manchester United", "Arsenal", "Chelsea", "Bayern Munich", "Liverpool", "Manchester City", "Barcelona" };
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label12.Text = "";
            label34.Text = "";
            label56.Text = "";
            label78.Text = "";
            label13.Text = "";
            label57.Text = "";
            label15.Text = "Winner is: \n";

            for (int i = 0; i < 8; i++)
            {
                l[i] = generator.Next(1, 10);
            }

            for (int i = 0; i < 8; i++)
            {
                string labelName = "label" + (i + 1).ToString();
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)Controls[labelName];
                label.Text += team[i];
            }

            for (int i = 0; i < 3; i++)
            {
                playGames(i);
            }

            button1.Text = "Replay";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
