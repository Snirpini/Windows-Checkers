using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameLogic;

namespace WindowsUI
{
    partial class GameBoardForm 
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeFormBySetting()
        {
            System.Drawing.Size FormSize;
            Label player1NameLabel = new Label();
            Label player2NameLabel = new Label();
            int player1LabelWidth, player2LabelWidth, player1LabelX, player2LabelX;

            player1LabelWidth = (m_GameSettings.Player1Name.Length * 12) + 5;
            player2LabelWidth = (m_GameSettings.Player2Name.Length * 12) + 5;
            player1LabelX = 10;

            FormSize = getFormSize();
            this.ClientSize = FormSize; 
            this.Text = "Checkers";
            player1NameLabel.Text = m_GameSettings.Player1Name + ":";
            player1NameLabel.Location = new System.Drawing.Point(player1LabelX, 30);
            player1NameLabel.Size = new Size(player1LabelWidth, 20);
            player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            player2NameLabel.Text = m_GameSettings.Player2Name + ":";
            player2LabelX = player1NameLabel.Right + 50; 
            player2NameLabel.Location = new System.Drawing.Point(player2LabelX, 30);
            player2NameLabel.Size = new Size(player2LabelWidth, 20);
            player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.Controls.AddRange(new Control[] { player1NameLabel, player2NameLabel });

        }

        private void initializeBoard()
        {
            int Boardsize = (int)m_GameSettings.BoardSize;
            m_BoardButtons = new Button[Boardsize, Boardsize];
            System.Drawing.Point startLineButton = new System.Drawing.Point(frameDistance, topDistance);
            System.Drawing.Point location = startLineButton;

            for(int i = 0; i < Boardsize; i++)
            {
                for(int j = 0; j < Boardsize; j++)
                {
                    m_BoardButtons[i, j] = new Button();
                    m_BoardButtons[i, j].Location = location;
                    m_BoardButtons[i, j].Size = m_BoardButtonSize;
                    this.Controls.Add(m_BoardButtons[i, j]);
                    this.m_BoardButtons[i, j].Click += m_BoardButton_Click;
                    setBottonColorAndActivity(i, j);
                    setSign(i, j);
                    location = setNewButtonLocation(i, j);
                }

                startLineButton.Y += m_BoardButtonSize.Height;
                location = startLineButton; 
            }
        }

        private void setSign(int i_Row, int i_Col)
        {
            string sign;
            GameLogic.Point location = new GameLogic.Point(i_Row, i_Col);
            if(m_Game.GetGamePieceColor(location) == GamePiece.eColor.Black)
            {
                sign = m_Game.CheckIsGamePieceKing(location) ? "K" : "X";
                m_BoardButtons[i_Row, i_Col].Text = sign;
            }
            else if(m_Game.GetGamePieceColor(location) == GamePiece.eColor.White)
            {
                sign = m_Game.CheckIsGamePieceKing(location) ? "U" : "O";
                m_BoardButtons[i_Row, i_Col].Text = sign;
            }
        }
      

      
    }
}