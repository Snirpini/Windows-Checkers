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
    public partial class FormGame : Form
    {
        private const int k_BoardPictureBoxSize = 50;
        private const int k_TopDistance = 60;
        private const int k_FrameDistance = 10;
        private const int k_PlayerLabelY = 20;
        private const int k_ComputerMoveDelay = 2000;

        private readonly GameLogic.Game r_Game = new GameLogic.Game();
        private readonly FormGameSettings r_FormGameSettings = new FormGameSettings();
        private PictureBox m_PictureBoxSource;
        
        public FormGame()
        {
            r_Game.NewRoundWasSet += r_Game_newRoundWasSet;
            r_Game.MoveMade += r_Game_MoveMade;
            r_Game.InvalidMoveEntered += r_Game_InvalidMoveEntered;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (r_FormGameSettings.DialogResult == DialogResult.OK)
            {
                initGame();
            }
        }

        private void initGame()
        {
            InitializeFormBySetting();
            r_Game.InitGame(r_FormGameSettings.Player1Name, r_FormGameSettings.Player2Name, r_FormGameSettings.Player2Type, r_FormGameSettings.BoardSize);
        }

        private void r_Game_newRoundWasSet(object sender, EventArgs e)
        {
            updateBoardFromLogicalBoard();
            updateScores();
            highlightCurrentPlayerNameLabel();
        }

        private void updateBoardFromLogicalBoard()
        {
            int boardSize = r_Game.GetBoardSize();

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (GameLogic.Board.IsSquareBlack(row, col))
                    {
                        updatePictureBoxFromLogicBoard(pictureBoxsMatrix[row, col]);
                    }
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxCurr = sender as PictureBox;
            GameLogic.Point currLocationOnBoard = getLocationOnLogicBoard(pictureBoxCurr.Location);

            if (r_Game.CheckIsOwnedByCurrentPlayer(currLocationOnBoard))
            {
                if (m_PictureBoxSource == pictureBoxCurr)
                {
                    unsetPictureBoxSource();
                }
                else
                {
                    setPictureBoxSource(pictureBoxCurr);
                }
            }
            else if (m_PictureBoxSource != null && r_Game.CheckIsEmpty(currLocationOnBoard))
            {
                GameLogic.Move userMove = new GameLogic.Move(getLocationOnLogicBoard(m_PictureBoxSource.Location), currLocationOnBoard);
                unsetPictureBoxSource();
                r_Game.MakeUserMove(userMove);
            }
        }

        private void setPictureBoxSource(PictureBox i_PictureBox)
        {
            if (m_PictureBoxSource != null)
            {
                unsetPictureBoxSource();
            }

            m_PictureBoxSource = i_PictureBox;
            i_PictureBox.BackColor = Color.DodgerBlue;
        }

        private void unsetPictureBoxSource()
        {
            if (m_PictureBoxSource != null)
            {
                m_PictureBoxSource.BackColor = Color.White;
                m_PictureBoxSource = null;
            }
        }

        private void r_Game_MoveMade(object sender, EventArgs e)
        {
            GameLogic.MoveMadeEventArgs mm = e as GameLogic.MoveMadeEventArgs;
            PictureBox pictureBoxSrc = pictureBoxsMatrix[mm.Move.Source.X, mm.Move.Source.Y];
            PictureBox pictureBoxDest = pictureBoxsMatrix[mm.Move.Destination.X, mm.Move.Destination.Y];

            updatePictureBoxFromLogicBoard(pictureBoxSrc);
            updatePictureBoxFromLogicBoard(pictureBoxDest);

            if (mm.CapturedGamePieceLocation.HasValue)
            {
                PictureBox pictureBoxCaptured = pictureBoxsMatrix[mm.CapturedGamePieceLocation.Value.X, mm.CapturedGamePieceLocation.Value.Y];
                updatePictureBoxFromLogicBoard(pictureBoxCaptured);
            }

            if (r_Game.CheckIsRoundOver())
            {
                roundOver();
            }
            else
            {
                highlightCurrentPlayerNameLabel();

                if (r_Game.CurrentPlayerType() == GameLogic.Player.eType.Computer)
                {
                    timerToComputerMove.Start();
                }
            }
        }

        private void r_Game_InvalidMoveEntered(object sender, EventArgs e)
        {
            GameLogic.InvalidMoveEnteredEventArgs ime = e as GameLogic.InvalidMoveEnteredEventArgs;
            StringBuilder errorMessageSB = new StringBuilder("Invalid Move!");

            switch (ime.InvalidReason)
            {
                case GameLogic.InvalidMoveEnteredEventArgs.eInvalidReason.HasMandatoryMove:
                    errorMessageSB.AppendLine().Append("You have a mandatory move!");
                    break;
                case GameLogic.InvalidMoveEnteredEventArgs.eInvalidReason.MultipleCapture:
                    errorMessageSB.AppendLine().Append("You have another cupture!");
                    break;
            }

            MessageBox.Show(errorMessageSB.ToString(), this.Text);
        }

        private void updateScores()
        {
            labelPlayer1Score.Text = r_Game.GetPlayerScore(GameLogic.Player.ePlayerNumber.Player1).ToString();
            labelPlayer2Score.Text = r_Game.GetPlayerScore(GameLogic.Player.ePlayerNumber.Player2).ToString();
        }

        private void highlightCurrentPlayerNameLabel()
        {
            GameLogic.Player.ePlayerNumber currentPlayerNumber = r_Game.GetCurrentPlayerNumber();

            labelPlayer1Name.BackColor = labelPlayer1Score.BackColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.OrangeRed : Color.Transparent;
            labelPlayer2Name.BackColor = labelPlayer2Score.BackColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.Transparent : Color.Black;
            labelPlayer2Name.ForeColor = labelPlayer2Score.ForeColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.Black : Color.White;
        }

        private void timerToComputerMove_Tick(object sender, EventArgs e)
        {
            timerToComputerMove.Stop();
            r_Game.MakeComputerMove();
        }

        private void updatePictureBoxFromLogicBoard(PictureBox i_PictureBox)
        {
            Image gamePieceImage;
            GameLogic.Point location = getLocationOnLogicBoard(i_PictureBox.Location);
            GameLogic.GamePiece.eColor? gamePieceColor = r_Game.GetGamePieceColor(location);
            bool isKing;

            if (gamePieceColor == null)
            {
                gamePieceImage = null;
            }
            else
            {
                isKing = r_Game.CheckIsGamePieceKing(location);

                if (gamePieceColor == GameLogic.GamePiece.eColor.Black)
                {
                    if (isKing)
                    {
                        gamePieceImage = global::WindowsUI.Properties.Resources.GamePiece_Red_King;
                    }
                    else
                    {
                        gamePieceImage = global::WindowsUI.Properties.Resources.GamePiece_Red;
                    }
                }
                else
                {
                    if (isKing)
                    {
                        gamePieceImage = global::WindowsUI.Properties.Resources.GamePiece_Black_King;
                    }
                    else
                    {
                        gamePieceImage = global::WindowsUI.Properties.Resources.GamePiece_Black;
                    }
                }
            }
            
            i_PictureBox.Image = gamePieceImage;
        }

        private GameLogic.Point getLocationOnLogicBoard(System.Drawing.Point i_Location)
        {
            int y = (i_Location.Y - k_TopDistance) / k_BoardPictureBoxSize;
            int x = (i_Location.X - k_FrameDistance) / k_BoardPictureBoxSize;

            return new GameLogic.Point(y, x);
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                roundOver();
                if (this.DialogResult != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void roundOver()
        {
            string msg = generateRoundOverMessage();
            DialogResult dialogResult = MessageBox.Show(msg, this.Text, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                unsetPictureBoxSource();
                r_Game.SetNewRound();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private string generateRoundOverMessage()
        {
            StringBuilder msgSB = new StringBuilder();
            GameLogic.Game.eRoundResult roundResult = r_Game.RoundResult();

            if (roundResult == GameLogic.Game.eRoundResult.Draw)
            {
                msgSB.Append("Tie!");
            }
            else
            {
                msgSB.AppendFormat("{0} won!", r_Game.GetWinnerName(roundResult));
            }

            msgSB.AppendLine();
            msgSB.Append("Another Round?");

            return msgSB.ToString();
        }
    }
}