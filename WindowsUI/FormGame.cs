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
    public partial class FormGame : Form
    {
        private const int k_BoardButtonSize = 50;
        private const int k_TopDistance = 60;
        private const int k_FrameDistance = 10;

        private readonly Game r_Game = new Game();
        private readonly FormGameSettings r_FormGameSettings = new FormGameSettings();
        private GameLogic.Point? m_Source;
        private GameLogic.Point? m_Destenation;
        public FormGame()
        {
            r_Game.BoardWasSet += r_Game_BoardWasSet;
            r_Game.CurrentPlayerChanged += r_Game_CurrentPlayerChanged;
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            r_FormGameSettings.FormClosed += r_FormGameSettings_FormClosed;
            r_FormGameSettings.ShowDialog();
        }

        private void r_FormGameSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(r_FormGameSettings.DialogResult == DialogResult.Cancel)
            {
                this.Opacity = 0;
                this.Close();
            }
            else if (r_FormGameSettings.DialogResult == DialogResult.OK)
            {
                initGame();
            }
        }

        private void m_BoardButton_Click(object sender, EventArgs e)
        {
            if(m_Source == null)
            {
              m_Source = getLocationByPoint(this.ActiveControl.Location);
            }
            else
            {
            m_Destenation = getLocationByPoint(this.ActiveControl.Location);
                makeMove(new GameLogic.Move((GameLogic.Point)m_Source, (GameLogic.Point)m_Destenation));
            }

            

        }

        private void initGame()
        {
            InitializeFormBySetting();
            r_Game.InitGame(r_FormGameSettings.Player1Name, r_FormGameSettings.Player2Name, r_FormGameSettings.Player2Type, r_FormGameSettings.BoardSize);
            //setNewRound();
        }

        private void setBottonColorAndActivity(int i_Row, int i_Col)
        {
            if (Board.IsSquareBlack(i_Row, i_Col))
            {
                buttonsMatrix[i_Row, i_Col].BackColor = Color.White;
            }
            else
            {
                buttonsMatrix[i_Row, i_Col].BackColor = Color.Gray;
            }

            buttonsMatrix[i_Row, i_Col].Enabled = false;
        }

        private void updateBoard()
        {
            int size = (int)r_FormGameSettings.BoardSize;
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    setSign(i, j);
                }
            }
        }

        private void updateScores()
        {

        }

        private void r_Game_BoardWasSet(object sender, EventArgs e)
        {
            int boardSize = r_Game.GetBoardSize();
            
            for(int row = 0; row < boardSize; row++)
            {
                for(int col = 0; col < boardSize; col++)
                {
                    if(GameLogic.Board.IsSquareBlack(row, col))
                    {
                        setUsableButton(buttonsMatrix[row, col], new GameLogic.Point(row, col));
                    }
                }
            }
        }

        private void r_Game_CurrentPlayerChanged(object sender, EventArgs e)
        {
            CurrentPlayerChangedEventArgs cpc = e as CurrentPlayerChangedEventArgs;

            foreach(GameLogic.Point location in cpc.CurrentPlayerGamePiecesLocationList)
            {
                enableButton(buttonsMatrix[location.X, location.Y]);
            }

            foreach (GameLogic.Point location in cpc.NextPlayerGamePiecesLocationList)
            {
                disableButton(buttonsMatrix[location.X, location.Y]);
            }
        }

        private void enableButton(Button i_Button)
        {
            i_Button.Enabled = true;
        }

        private void disableButton(Button i_Button)
        {
            i_Button.Enabled = false;
        }

        private void setUsableButton(Button i_Button, GameLogic.Point i_Location)
        {
            i_Button.Enabled = false;
            i_Button.Text = getGamePieceSign(i_Location);
        }

        private string getGamePieceSign(GameLogic.Point i_Location)
        {
            char gamePieceSign;
            GamePiece.eColor? gamePieceColor = r_Game.GetGamePieceColor(i_Location);

            if (gamePieceColor == null)
            {
                gamePieceSign = ' ';
            }
            else if (gamePieceColor == GamePiece.eColor.Black)
            {
                gamePieceSign = r_Game.CheckIsGamePieceKing(i_Location) ? 'K' : 'X';
            }
            else
            {
                gamePieceSign = r_Game.CheckIsGamePieceKing(i_Location) ? 'U' : 'O';
            }

            return gamePieceSign.ToString();
        }

        private System.Drawing.Size getFormSize()
        {
            int height, width;

            height = ((int)r_FormGameSettings.BoardSize * k_BoardButtonSize) + k_TopDistance + k_FrameDistance;
            width = ((int)r_FormGameSettings.BoardSize * k_BoardButtonSize)  + (k_FrameDistance * 2);

            return new System.Drawing.Size(width, height);
        }

        private GameLogic.Point getLocationByPoint(System.Drawing.Point i_Location)
        {
            int x = (i_Location.X - k_FrameDistance) / k_BoardButtonSize; 
            int y = (i_Location.Y - k_TopDistance) / k_BoardButtonSize;

            return new GameLogic.Point(y, x);
        }

        private void makeMove(GameLogic.Move i_Move)
        {
            r_Game.MakeUserMove(i_Move);
            updateBoard();
        }

    }
}
