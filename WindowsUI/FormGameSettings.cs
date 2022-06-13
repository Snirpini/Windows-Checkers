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
            if (string.IsNullOrWhiteSpace(player1NameTextBox.Text) || string.IsNullOrWhiteSpace(player2NameTextBox.Text))
            {
                MessageBox.Show("Please enter valid names!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
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

            set
            {
                player1NameTextBox.Text = value;
            }
        }

        public string Player2Name
        {
            get
            {
                return player2NameTextBox.Text;
            }

            set
            {
                player2NameTextBox.Text = value;
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
