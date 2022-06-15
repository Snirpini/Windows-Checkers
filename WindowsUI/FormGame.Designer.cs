using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameLogic;

namespace WindowsUI
{
    partial class FormGame 
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

        private void InitializeComponent()
        {
            labelPlayer1Name = new Label();
            labelPlayer2Name = new Label();
            labelPlayer1Score = new Label();
            labelPlayer2Score = new Label();
            timerToComputerMove = new Timer();
            this.SuspendLayout();
            this.timerToComputerMove.Interval = k_ComputerMoveDelay;
            this.timerToComputerMove.Tick += new System.EventHandler(timerToComputerMove_Tick);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.Text = "Checkers";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.FormClosing += FormGame_FormClosing;
            this.ResumeLayout(false);
        }

        private void InitializeFormBySetting()
        {
            initButtonsMatrix();
            this.ClientSize = getFormSizeFromFormGameSettings();
            this.CenterToScreen();
            initLabelPlayerName(labelPlayer1Name);
            initLabelPlayerName(labelPlayer2Name);
            labelPlayer1Score.Location = new System.Drawing.Point(labelPlayer1Name.Right, 20);
            labelPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPlayer1Score.AutoSize = true;
            this.Controls.Add(labelPlayer1Score);
            labelPlayer2Score.Location = new System.Drawing.Point(labelPlayer2Name.Right, 20);
            labelPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPlayer2Score.AutoSize = true;
            this.Controls.Add(labelPlayer2Score);
        }

        private void initLabelPlayerName(Label i_LabelPlayerName)
        {
            int halfOfBoardWidth = (int)r_FormGameSettings.BoardSize / 2 * k_BoardButtonSize;
            int maxLabelLength = (halfOfBoardWidth - k_BoardButtonSize) / 10;
            StringBuilder labelTextSB = new StringBuilder();
            int labelLocationX;

            if(i_LabelPlayerName == labelPlayer1Name)
            {
                labelTextSB.Append(r_FormGameSettings.Player1Name);
                labelLocationX = k_FrameDistance;
            }
            else
            {
                labelTextSB.Append(r_FormGameSettings.Player2Name);
                labelLocationX = k_FrameDistance + halfOfBoardWidth;
            }

            if(labelTextSB.Length > maxLabelLength)
            {
                labelTextSB.Length = maxLabelLength;
            }

            labelTextSB.Append(" :");
            i_LabelPlayerName.Text = labelTextSB.ToString();
            i_LabelPlayerName.Location = new System.Drawing.Point(labelLocationX, 20);
            i_LabelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            i_LabelPlayerName.AutoSize = true;

            this.Controls.Add(i_LabelPlayerName);
        }

        private void initButtonsMatrix()
        {
            System.Drawing.Point location;
            System.Drawing.Point firstButtonInLineLocation = new System.Drawing.Point(k_FrameDistance, k_TopDistance);
            int boardSize = (int)r_FormGameSettings.BoardSize;

            buttonsMatrix = new Button[boardSize, boardSize];
            
            for (int row = 0; row < boardSize; row++)
            {
                location = firstButtonInLineLocation;

                for (int col = 0; col < boardSize; col++)
                {
                    buttonsMatrix[row, col] = new Button();
                    buttonsMatrix[row, col].Location = location;
                    initButton(row, col);
                    this.Controls.Add(buttonsMatrix[row, col]);
                    this.buttonsMatrix[row, col].Click += m_BoardButton_Click;
                    location.X += k_BoardButtonSize;
                }

                firstButtonInLineLocation.Y += k_BoardButtonSize;
            }
        }

        private void initButton(int i_Row, int i_Col)
        {
            Button button = buttonsMatrix[i_Row, i_Col];
            button.TabStop = false;
            button.Size = new Size(k_BoardButtonSize, k_BoardButtonSize);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            if (Board.IsSquareBlack(i_Row, i_Col))
            {
                button.BackColor = Color.White;
            }
            else
            {
                button.BackColor = Color.Gray;
                button.Enabled = false;
            }
        }

        private System.Drawing.Size getFormSizeFromFormGameSettings()
        {
            int height = ((int)r_FormGameSettings.BoardSize * k_BoardButtonSize) + k_TopDistance + k_FrameDistance;
            int width = ((int)r_FormGameSettings.BoardSize * k_BoardButtonSize) + (k_FrameDistance * 2);

            return new System.Drawing.Size(width, height);
        }

        private Button[,] buttonsMatrix;
        private Label labelPlayer1Name;
        private Label labelPlayer2Name;
        private Label labelPlayer1Score;
        private Label labelPlayer2Score;
        private Timer timerToComputerMove;
    }
}