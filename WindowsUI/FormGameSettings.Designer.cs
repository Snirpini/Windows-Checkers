namespace WindowsUI
{
    partial class FormGameSettings
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
            this.radioButtonLargeSize = new System.Windows.Forms.RadioButton();
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
            this.boardSizeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardSizeLabel.Location = new System.Drawing.Point(12, 31);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(107, 25);
            this.boardSizeLabel.TabIndex = 0;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // radioButtonSmallSize
            // 
            this.radioButtonSmallSize.AutoSize = true;
            this.radioButtonSmallSize.Checked = true;
            this.radioButtonSmallSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSmallSize.Location = new System.Drawing.Point(32, 59);
            this.radioButtonSmallSize.Name = "radioButtonSmallSize";
            this.radioButtonSmallSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButtonSmallSize.Size = new System.Drawing.Size(61, 25);
            this.radioButtonSmallSize.TabIndex = 1;
            this.radioButtonSmallSize.TabStop = true;
            this.radioButtonSmallSize.Text = "6 x 6";
            this.radioButtonSmallSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonMediumSize
            // 
            this.radioButtonMediumSize.AutoSize = true;
            this.radioButtonMediumSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMediumSize.Location = new System.Drawing.Point(116, 59);
            this.radioButtonMediumSize.Name = "radioButtonMediumSize";
            this.radioButtonMediumSize.Size = new System.Drawing.Size(61, 25);
            this.radioButtonMediumSize.TabIndex = 1;
            this.radioButtonMediumSize.Text = "8 x 8";
            this.radioButtonMediumSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonLargeSize
            // 
            this.radioButtonLargeSize.AutoSize = true;
            this.radioButtonLargeSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLargeSize.Location = new System.Drawing.Point(200, 59);
            this.radioButtonLargeSize.Name = "radioButtonLargeSize";
            this.radioButtonLargeSize.Size = new System.Drawing.Size(79, 25);
            this.radioButtonLargeSize.TabIndex = 1;
            this.radioButtonLargeSize.Text = "10 x 10";
            this.radioButtonLargeSize.UseVisualStyleBackColor = true;
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1NameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.player1NameTextBox.Location = new System.Drawing.Point(137, 143);
            this.player1NameTextBox.MaxLength = 20;
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(142, 29);
            this.player1NameTextBox.TabIndex = 2;
            this.player1NameTextBox.Text = "Player1";
            this.player1NameTextBox.Enter += new System.EventHandler(this.playerNameTextBox_Enter);
            this.player1NameTextBox.Leave += new System.EventHandler(this.playerNameTextBox_Leave);
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.Enabled = false;
            this.player2NameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2NameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.player2NameTextBox.Location = new System.Drawing.Point(137, 183);
            this.player2NameTextBox.MaxLength = 20;
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(142, 29);
            this.player2NameTextBox.TabIndex = 2;
            this.player2NameTextBox.Text = "Computer";
            this.player2NameTextBox.Enter += new System.EventHandler(this.playerNameTextBox_Enter);
            this.player2NameTextBox.Leave += new System.EventHandler(this.playerNameTextBox_Leave);
            // 
            // player2CheckBox
            // 
            this.player2CheckBox.AutoSize = true;
            this.player2CheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2CheckBox.Location = new System.Drawing.Point(20, 183);
            this.player2CheckBox.Name = "player2CheckBox";
            this.player2CheckBox.Size = new System.Drawing.Size(88, 25);
            this.player2CheckBox.TabIndex = 3;
            this.player2CheckBox.Text = "Player 2:";
            this.player2CheckBox.UseVisualStyleBackColor = true;
            this.player2CheckBox.CheckedChanged += new System.EventHandler(this.player2CheckBox_CheckedChanged);
            // 
            // doneButton
            // 
            this.doneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.doneButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.playersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playersLabel.Location = new System.Drawing.Point(16, 105);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(69, 21);
            this.playersLabel.TabIndex = 0;
            this.playersLabel.Text = "Players:";
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(39, 143);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(69, 21);
            this.player1Label.TabIndex = 0;
            this.player1Label.Text = "Player 1:";
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.doneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(317, 266);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.player2CheckBox);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player1NameTextBox);
            this.Controls.Add(this.radioButtonLargeSize);
            this.Controls.Add(this.radioButtonMediumSize);
            this.Controls.Add(this.radioButtonSmallSize);
            this.Controls.Add(this.boardSizeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.RadioButton radioButtonSmallSize;
        private System.Windows.Forms.RadioButton radioButtonMediumSize;
        private System.Windows.Forms.RadioButton radioButtonLargeSize;
        private System.Windows.Forms.TextBox player1NameTextBox;
        private System.Windows.Forms.TextBox player2NameTextBox;
        private System.Windows.Forms.CheckBox player2CheckBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label player1Label;
    }
}

