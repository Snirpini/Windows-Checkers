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
        private const int k_BoardButtonSize = 60;
        private const int k_TopDistance = 60;
        private const int k_FrameDistance = 10;
        private const int k_ComputerMoveDelay = 2000;

        private readonly Game r_Game = new Game();
        private readonly FormGameSettings r_FormGameSettings = new FormGameSettings();
        private Button m_ButtonSource;
        
        public FormGame()
        {
            r_Game.newRoundWasSet += r_Game_newRoundWasSet;
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
                        updateButtonFromLogicBoard(buttonsMatrix[row, col]);
                    }
                }
            }
        }

        private void m_BoardButton_Click(object sender, EventArgs e)
        {
            Button buttonCurr = sender as Button;
            GameLogic.Point currLocationOnBoard = getLocationOnLogicBoard(buttonCurr.Location);

            if (r_Game.CheckIsOwnedByCurrentPlayer(currLocationOnBoard))
            {
                if (m_ButtonSource == buttonCurr)
                {
                    unsetButtonSource();
                }
                else
                {
                    setButtonSource(buttonCurr);
                }
            }
            else if(m_ButtonSource != null && r_Game.CheckIsEmpty(currLocationOnBoard))
            {
                GameLogic.Move userMove = new GameLogic.Move(getLocationOnLogicBoard(m_ButtonSource.Location), currLocationOnBoard);
                r_Game.MakeUserMove(userMove);
            }
        }

        private void setButtonSource(Button i_Button)
        {
            if(m_ButtonSource != null)
            {
                unsetButtonSource();
            }

            m_ButtonSource = i_Button;
            i_Button.BackColor = Color.PowderBlue;
        }

        private void unsetButtonSource()
        {
            if(m_ButtonSource != null)
            {
                m_ButtonSource.BackColor = Color.White;
                m_ButtonSource = null;
            }
        }

        private void r_Game_MoveMade(object sender, EventArgs e)
        {
            MoveMadeEventArgs mm = e as MoveMadeEventArgs;
            Button buttonSrc = buttonsMatrix[mm.Move.Source.X, mm.Move.Source.Y];
            Button buttonDest = buttonsMatrix[mm.Move.Destination.X, mm.Move.Destination.Y];

            unsetButtonSource();
            updateButtonFromLogicBoard(buttonSrc);
            updateButtonFromLogicBoard(buttonDest);

            if(mm.CapturedGamePieceLocation.HasValue)
            {
                Button buttonCaptured = buttonsMatrix[mm.CapturedGamePieceLocation.Value.X, mm.CapturedGamePieceLocation.Value.Y];
                updateButtonFromLogicBoard(buttonCaptured);
            }

            if(r_Game.CheckIsRoundOver())
            {
                roundOver();
            }
            else
            {
                highlightCurrentPlayerNameLabel();

                if (r_Game.CurrentPlayerType() == Player.eType.Computer)
                {
                    timerToComputerMove.Start();
                }
            }
        }

        private void r_Game_InvalidMoveEntered(object sender, EventArgs e)
        {
            InvalidMoveEnteredEventArgs ime = e as InvalidMoveEnteredEventArgs;
            StringBuilder errorMessageSB = new StringBuilder("Invalid Move!");

            switch (ime.InvalidReason)
            {
                case InvalidMoveEnteredEventArgs.eInvalidReason.HasMandatoryMove:
                    errorMessageSB.AppendLine().Append("You have a mandatory move!");
                    break;
                case InvalidMoveEnteredEventArgs.eInvalidReason.MultipleCapture:
                    errorMessageSB.AppendLine().Append("You have another cupture!");
                    break;
            }

            unsetButtonSource();
            MessageBox.Show(errorMessageSB.ToString(), this.Text);
        }

        private void updateScores()
        {
            labelPlayer1Score.Text = r_Game.GetPlayerScore(GameLogic.Player.ePlayerNumber.Player1).ToString();
            labelPlayer2Score.Text = r_Game.GetPlayerScore(GameLogic.Player.ePlayerNumber.Player2).ToString();
        }

        //private void updatePlayerScore(GameLogic.Player.ePlayerNumber i_playerNumber)
        //{
        //    string playerName = r_Game.GetPlayerName(i_playerNumber);
        //    int playerScore = r_Game.GetPlayerScore(i_playerNumber);
        //    Label labelPlayerScore = i_playerNumber == GameLogic.Player.ePlayerNumber.Player1 ? labelPlayer1Name : labelPlayer2Name;

        //    labelPlayerScore.Text = $"{playerName} : {playerScore}";
        //}

        private void highlightCurrentPlayerNameLabel()
        {
            GameLogic.Player.ePlayerNumber currentPlayerNumber = r_Game.GetCurrentPlayerNumber();

            labelPlayer1Name.BackColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.Wheat : Color.Transparent;
            labelPlayer2Name.BackColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.Transparent : Color.Wheat;
            labelPlayer1Score.BackColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.Wheat : Color.Transparent;
            labelPlayer2Score.BackColor = currentPlayerNumber == GameLogic.Player.ePlayerNumber.Player1 ? Color.Transparent : Color.Wheat;
        }

        private void timerToComputerMove_Tick(object sender, EventArgs e)
        {
            timerToComputerMove.Stop();
            r_Game.MakeComputerMove();
        }

        private void updateButtonFromLogicBoard(Button i_Button)
        {
            string gamePieceSign;
            GameLogic.Point location = getLocationOnLogicBoard(i_Button.Location);
            GamePiece.eColor? gamePieceColor = r_Game.GetGamePieceColor(location);

            if (gamePieceColor == null)
            {
                gamePieceSign = " ";
            }
            else if (gamePieceColor == GamePiece.eColor.Black)
            {
                gamePieceSign = r_Game.CheckIsGamePieceKing(location) ? "K" : "X";
            }
            else
            {
                gamePieceSign = r_Game.CheckIsGamePieceKing(location) ? "U" : "O";
            }

            i_Button.Text = gamePieceSign;
        }

        private GameLogic.Point getLocationOnLogicBoard(System.Drawing.Point i_Location)
        {
            int y = (i_Location.Y - k_TopDistance) / k_BoardButtonSize;
            int x = (i_Location.X - k_FrameDistance) / k_BoardButtonSize;

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
                unsetButtonSource();
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
