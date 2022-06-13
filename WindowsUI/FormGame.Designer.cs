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
            this.SuspendLayout();
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
        }

        private void InitializeFormBySetting()
        {
            int player1LabelWidth = (r_FormGameSettings.Player1Name.Length * 12) + 5;
            int player2LabelWidth = (r_FormGameSettings.Player2Name.Length * 12) + 5;
            int player1LabelX = 10;
            int player2LabelX;

            initButtonsMatrix();
            this.ClientSize = getFormSize();
            this.Text = "Checkers";
            labelPlayer1Name.Text = r_FormGameSettings.Player1Name + ":";
            labelPlayer1Name.Location = new System.Drawing.Point(player1LabelX, 30);
            labelPlayer1Name.Size = new Size(player1LabelWidth, 20);
            labelPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPlayer2Name.Text = r_FormGameSettings.Player2Name + ":";
            player2LabelX = labelPlayer1Name.Right + 50;
            labelPlayer2Name.Location = new System.Drawing.Point(player2LabelX, 30);
            labelPlayer2Name.Size = new Size(player2LabelWidth, 20);
            labelPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.Controls.AddRange(new Control[] { labelPlayer1Name, labelPlayer2Name });
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
                    buttonsMatrix[row, col].Size = new Size(k_BoardButtonSize, k_BoardButtonSize);
                    this.Controls.Add(buttonsMatrix[row, col]);
                    this.buttonsMatrix[row, col].Click += m_BoardButton_Click;
                    setBottonColorAndActivity(row, col);
                    //setSign(row, col); // Not here - move to setBoardAndGamePieces
                    location.X += k_BoardButtonSize;
                }

                firstButtonInLineLocation.Y += k_BoardButtonSize;
            }
        }

        private void setSign(int i_Row, int i_Col)
        {
            string sign;
            GameLogic.Point location = new GameLogic.Point(i_Row, i_Col);
            if(r_Game.GetGamePieceColor(location) == GamePiece.eColor.Black)
            {
                sign = r_Game.CheckIsGamePieceKing(location) ? "K" : "X";
                buttonsMatrix[i_Row, i_Col].Text = sign;
            }
            else if(r_Game.GetGamePieceColor(location) == GamePiece.eColor.White)
            {
                sign = r_Game.CheckIsGamePieceKing(location) ? "U" : "O";
                buttonsMatrix[i_Row, i_Col].Text = sign;
            }
        }

        private Button[,] buttonsMatrix;
        private Label labelPlayer1Name;
        private Label labelPlayer2Name;
        private Label labelPlayer1Score;
        private Label labelPlayer2Score;
    }
}