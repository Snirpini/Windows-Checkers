using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void player1NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSmallSize_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonMediumSize_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
