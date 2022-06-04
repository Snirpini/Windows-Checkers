namespace WindowsUI
{
    partial class GameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.radioButtonSmallSize = new System.Windows.Forms.RadioButton();
            this.radioButtonMediumSize = new System.Windows.Forms.RadioButton();
            this.radioButtonBigSize = new System.Windows.Forms.RadioButton();
            this.player1NameTextBox = new System.Windows.Forms.TextBox();
            this.player2NameTextBox = new System.Windows.Forms.TextBox();
            this.player2CheckBox = new System.Windows.Forms.CheckBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.playersLabel = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardSizeLabel.Location = new System.Drawing.Point(12, 31);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(107, 25);
            this.boardSizeLabel.TabIndex = 0;
            this.boardSizeLabel.Text = "Board Size:";
            this.boardSizeLabel.Click += new System.EventHandler(this.boardSizeLabel_Click);
            // 
            // radioButtonSmallSize
            // 
            this.radioButtonSmallSize.AutoSize = true;
            this.radioButtonSmallSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSmallSize.Location = new System.Drawing.Point(32, 59);
            this.radioButtonSmallSize.Name = "radioButtonSmallSize";
            this.radioButtonSmallSize.Size = new System.Drawing.Size(64, 24);
            this.radioButtonSmallSize.TabIndex = 1;
            this.radioButtonSmallSize.TabStop = true;
            this.radioButtonSmallSize.Text = "6 X 6";
            this.radioButtonSmallSize.UseVisualStyleBackColor = true;
            this.radioButtonSmallSize.CheckedChanged += new System.EventHandler(this.radioButtonSmallSize_CheckedChanged);
            // 
            // radioButtonMediumSize
            // 
            this.radioButtonMediumSize.AutoSize = true;
            this.radioButtonMediumSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMediumSize.Location = new System.Drawing.Point(116, 59);
            this.radioButtonMediumSize.Name = "radioButtonMediumSize";
            this.radioButtonMediumSize.Size = new System.Drawing.Size(64, 24);
            this.radioButtonMediumSize.TabIndex = 1;
            this.radioButtonMediumSize.TabStop = true;
            this.radioButtonMediumSize.Text = "8 X 8";
            this.radioButtonMediumSize.UseVisualStyleBackColor = true;
            this.radioButtonMediumSize.CheckedChanged += new System.EventHandler(this.radioButtonMediumSize_CheckedChanged);
            // 
            // radioButtonBigSize
            // 
            this.radioButtonBigSize.AutoSize = true;
            this.radioButtonBigSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBigSize.Location = new System.Drawing.Point(200, 59);
            this.radioButtonBigSize.Name = "radioButtonBigSize";
            this.radioButtonBigSize.Size = new System.Drawing.Size(82, 24);
            this.radioButtonBigSize.TabIndex = 1;
            this.radioButtonBigSize.TabStop = true;
            this.radioButtonBigSize.Text = "10 X 10";
            this.radioButtonBigSize.UseVisualStyleBackColor = true;
            this.radioButtonBigSize.CheckedChanged += new System.EventHandler(this.radioButtonBigSize_CheckedChanged);
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1NameTextBox.Location = new System.Drawing.Point(154, 143);
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(130, 26);
            this.player1NameTextBox.TabIndex = 2;
            this.player1NameTextBox.TextChanged += new System.EventHandler(this.player1NameTextBox_TextChanged);
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.Enabled = false;
            this.player2NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2NameTextBox.Location = new System.Drawing.Point(154, 183);
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(130, 26);
            this.player2NameTextBox.TabIndex = 2;
            this.player2NameTextBox.Text = "Computer";
            this.player2NameTextBox.TextChanged += new System.EventHandler(this.player2NameTextBox_TextChanged);
            // 
            // player2CheckBox
            // 
            this.player2CheckBox.AutoSize = true;
            this.player2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2CheckBox.Location = new System.Drawing.Point(45, 183);
            this.player2CheckBox.Name = "player2CheckBox";
            this.player2CheckBox.Size = new System.Drawing.Size(88, 24);
            this.player2CheckBox.TabIndex = 3;
            this.player2CheckBox.Text = "Player 2:";
            this.player2CheckBox.UseVisualStyleBackColor = true;
            this.player2CheckBox.CheckedChanged += new System.EventHandler(this.player2CheckBox_CheckedChanged);
            // 
            // doneButton
            // 
            this.doneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(207, 225);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(98, 29);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersLabel.Location = new System.Drawing.Point(16, 105);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(72, 20);
            this.playersLabel.TabIndex = 5;
            this.playersLabel.Text = "Players:";
            this.playersLabel.Click += new System.EventHandler(this.playersLabel_Click);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(45, 143);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(69, 20);
            this.player1Label.TabIndex = 6;
            this.player1Label.Text = "Player 1:";
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 266);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.player2CheckBox);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player1NameTextBox);
            this.Controls.Add(this.radioButtonBigSize);
            this.Controls.Add(this.radioButtonMediumSize);
            this.Controls.Add(this.radioButtonSmallSize);
            this.Controls.Add(this.boardSizeLabel);
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.RadioButton radioButtonSmallSize;
        private System.Windows.Forms.RadioButton radioButtonMediumSize;
        private System.Windows.Forms.RadioButton radioButtonBigSize;
        private System.Windows.Forms.TextBox player1NameTextBox;
        private System.Windows.Forms.TextBox player2NameTextBox;
        private System.Windows.Forms.CheckBox player2CheckBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label player1Label;
    }
}

