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
    public partial class GameSettings : Form
    {
        
        public GameSettings()
        {
            InitializeComponent();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {

        }

        private void boardSizeLabel_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonBigSize_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = Board.eBoardSize.Large;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void player1NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSmallSize_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = Board.eBoardSize.Small;
        }

        private void radioButtonMediumSize_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = Board.eBoardSize.Medium;
        }

        private void playersLabel_Click(object sender, EventArgs e)
        {

        }

        private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            player2NameTextBox.Enabled = player2CheckBox.Checked;
            if(!player2NameTextBox.Enabled)
            {
                player2NameTextBox.Text = "Computer";
            }
            else
            {
                player2NameTextBox.Clear();
                player2NameTextBox.Focus();
            }
        }

        private void player2NameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private Board.eBoardSize m_BoardSize;

        public Board.eBoardSize BoardSize
        {
            get
            {
                return m_BoardSize; 
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
    }
}
