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
    public partial class GameBoardForm : Form
    {
        private Game m_Game = new Game();
        private GameSettings m_GameSettings = new GameSettings();
        private Button[,] m_BoardButtons;
        private Label m_player1Score = new Label();
        private Label m_player2Score = new Label();
        private Size m_BoardButtonSize = new Size(50, 50);
        private int topDistance = 60;
        private int frameDistance = 10;
        private GameLogic.Point? m_Source;
        private GameLogic.Point? m_Destenation; 
        public GameBoardForm()
        {
            InitializeComponent();
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            initGameSetting();
        }

        private bool initGameSetting() 
        {
            bool initGame = false;
            Player.eType player2Type;

            if(m_GameSettings.ShowDialog() == DialogResult.OK)
            {
                player2Type = m_GameSettings.Player2Name.Equals("Computer") ? Player.eType.Computer : Player.eType.Human;
                m_Game.InitGame(m_GameSettings.Player1Name, m_GameSettings.Player2Name, player2Type, m_GameSettings.BoardSize);
                initializeBoard();
                InitializeFormBySetting();
                initGame = true;
            }
           
            return initGame;
        }

        private void setBottonColorAndActivity(int i_Row, int i_Col)
        {
            if ((i_Row % 2 == 0 && i_Col % 2 != 0) || (i_Row % 2 != 0 && i_Col % 2 == 0))
            {
                m_BoardButtons[i_Row, i_Col].BackColor = Color.White;
            }
            else
            {
                m_BoardButtons[i_Row, i_Col].BackColor = Color.Gray;
                m_BoardButtons[i_Row, i_Col].Enabled = false;
            }
        }

        private void updateBoard()
        {
            int size = (int)m_GameSettings.BoardSize;
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    setSign(i, j);
                }
            }
        }

        private System.Drawing.Point setNewButtonLocation(int i_Row, int i_Col)
        {
            System.Drawing.Point lastLocation;
            int x, y;

            lastLocation = m_BoardButtons[i_Row, i_Col].Location;
            y = lastLocation.Y;
            x = lastLocation.X + m_BoardButtonSize.Width;

            return new System.Drawing.Point(x, y);
        }

        private System.Drawing.Size getFormSize()
        {
            int height, width;

            height = ((int)m_GameSettings.BoardSize * m_BoardButtonSize.Height) + topDistance + frameDistance;
            width = ((int)m_GameSettings.BoardSize * m_BoardButtonSize.Height)  + (frameDistance * 2);

            return new System.Drawing.Size(width, height);
        }

        private GameLogic.Point getLocationByPoint(System.Drawing.Point i_Location)
        {
            int x = (i_Location.X - frameDistance) / m_BoardButtonSize.Width; 
            int y = (i_Location.Y - topDistance) / m_BoardButtonSize.Height;

            return new GameLogic.Point(y, x);
        }

        private void makeMove(GameLogic.Move i_Move)
        {
            m_Game.MakeUserMove(i_Move);
            updateBoard();
        }
    }
}
