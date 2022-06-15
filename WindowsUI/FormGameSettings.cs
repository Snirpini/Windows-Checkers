using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameLogic;

namespace WindowsUI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (!isValidPlayerName(player1NameTextBox.Text) || !isValidPlayerName(player2NameTextBox.Text))
            {
                MessageBox.Show("Please enter valid names without whitespaces!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool isValidPlayerName(string i_PlayerName)
        {
            return !string.IsNullOrWhiteSpace(i_PlayerName) && !i_PlayerName.Contains(' ');
        }

        private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            player2NameTextBox.Enabled = player2CheckBox.Checked;
            if(!player2NameTextBox.Enabled)
            {
                player2NameTextBox.Text = Player.k_ComputerDefaultName;
            }
            else
            {
                player2NameTextBox.Clear();
                player2NameTextBox.Focus();
            }
        }

        private void playerNameTextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.ForeColor == Color.DarkGray)
            {
                textBox.Clear();
                textBox.ForeColor = Color.Black;
            }
        }

        private void playerNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.ForeColor = Color.DarkGray;

                if (textBox == player1NameTextBox)
                {
                    textBox.Text = GameLogic.Player.k_Player1DefaultName;
                }
                else if (!player2CheckBox.Focused)
                {
                    textBox.Text = GameLogic.Player.k_Player2DefaultName;
                }
            }
        }

        public Board.eBoardSize BoardSize
        {
            get
            {
                Board.eBoardSize boardSize;

                if(radioButtonSmallSize.Checked)
                {
                    boardSize = Board.eBoardSize.Small;
                }
                else if(radioButtonMediumSize.Checked)
                {
                    boardSize = Board.eBoardSize.Medium;
                }
                else
                {
                    boardSize = Board.eBoardSize.Large;
                }

                return boardSize;
            }
        }

        public string Player1Name
        {
            get
            {
                return player1NameTextBox.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                return player2NameTextBox.Text;
            }
        }

        public Player.eType Player2Type
        {
            get
            {
                return player2CheckBox.Checked ? Player.eType.Human : Player.eType.Computer;
            }
        }
    }
}
