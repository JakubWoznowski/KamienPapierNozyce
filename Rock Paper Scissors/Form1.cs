using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors
{
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameover = false;
        string[] CPUchoiceList = { "kamień", "papier", "nożyce", "papier", "nożyce", "kamień" };
        int randomNumber = 0;
        Random rnd = new Random();
        string CPUchoice;
        string playerChoice;
        int playerwins;
        int AIwins;

        public Form1()
        {
            InitializeComponent();
            countDownTimer.Enabled = true;
            playerChoice = "brak";
            txtTime.Text = "5";

            // Zmiana tekstu przycisków na polski
            btnRock.Text = "Kamień";
            btnPaper.Text = "Papier";
            btnScissors.Text = "Nożyce";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "kamień";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "papier";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "nożyce";
        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            timerPerRound -= 1;
            txtTime.Text = timerPerRound.ToString();
            roundsText.Text = "Rundy: " + rounds; // Tłumaczenie

            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 6;

                randomNumber = rnd.Next(0, CPUchoiceList.Length);
                CPUchoice = CPUchoiceList[randomNumber];

                switch (CPUchoice)
                {
                    case "kamień":
                        picCPU.Image = Properties.Resources.rock;
                        break;
                    case "papier":
                        picCPU.Image = Properties.Resources.paper;
                        break;
                    case "nożyce":
                        picCPU.Image = Properties.Resources.scissors;
                        break;
                }

                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (playerwins > AIwins)
                    {
                        MessageBox.Show("Gracz wygrywa grę!"); // Tłumaczenie
                    }
                    else
                    {
                        MessageBox.Show("CPU wygrywa grę!"); // Tłumaczenie
                    }
                    gameover = true;
                }
            }
        }

        private void checkGame()
        {
            if (playerChoice == "kamień" && CPUchoice == "papier")
            {
                AIwins += 1;
                rounds -= 1;
                MessageBox.Show("CPU wygrywa, Papier pokrywa Kamień"); // Tłumaczenie
            }
            else if (playerChoice == "nożyce" && CPUchoice == "kamień")
            {
                AIwins += 1;
                rounds -= 1;
                MessageBox.Show("CPU wygrywa, Kamień tłucze Nożyce"); // Tłumaczenie
            }
            else if (playerChoice == "papier" && CPUchoice == "nożyce")
            {
                AIwins += 1;
                rounds -= 1;
                MessageBox.Show("CPU wygrywa, Nożyce tną Papier"); // Tłumaczenie
            }
            else if (playerChoice == "kamień" && CPUchoice == "nożyce")
            {
                playerwins += 1;
                rounds -= 1;
                MessageBox.Show("Gracz wygrywa, Kamień tłucze Nożyce"); // Tłumaczenie
            }
            else if (playerChoice == "papier" && CPUchoice == "kamień")
            {
                playerwins += 1;
                rounds -= 1;
                MessageBox.Show("Gracz wygrywa, Papier pokrywa Kamień"); // Tłumaczenie
            }
            else if (playerChoice == "nożyce" && CPUchoice == "papier")
            {
                playerwins += 1;
                rounds -= 1;
                MessageBox.Show("Gracz wygrywa, Nożyce tną Papier"); // Tłumaczenie
            }
            else if (playerChoice == "brak")
            {
                MessageBox.Show("Wybierz swój ruch!"); // Tłumaczenie
            }
            else
            {
                MessageBox.Show("Remis!"); // Tłumaczenie
            }

            startNextRound();
        }

        public void startNextRound()
        {
            if (gameover) return;

            // Tłumaczenie komunikatu wyniku
            txtMessage.Text = "Gracz: " + playerwins + " - " + "CPU: " + AIwins;
            playerChoice = "brak";
            countDownTimer.Enabled = true;
            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;
        }

        private void restartGame(object sender, EventArgs e)
        {
            playerwins = 0;
            AIwins = 0;
            rounds = 3;
            // Tłumaczenie komunikatu wyniku
            txtMessage.Text = "Gracz: " + playerwins + " - " + "CPU: " + AIwins;
            playerChoice = "brak";
            txtTime.Text = "5";
            countDownTimer.Enabled = true;
            picPlayer.Image = Properties.Resources.qq;
            picCPU.Image = Properties.Resources.qq;
            gameover = false;
        }
    }
}