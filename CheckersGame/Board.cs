﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class Board
    {
        public enum eBoardSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

        private readonly GamePiece[,] r_GameBoard;

        internal Board(eBoardSize i_BoardSize)
        {
            r_GameBoard = new GamePiece[(int)i_BoardSize, (int)i_BoardSize];
        }

        internal GamePiece this[int i_Row, int i_Col]
        {
            get
            {
                return r_GameBoard[i_Row, i_Col];
            }
            set
            {
                r_GameBoard[i_Row, i_Col] = value;
            }
        }

        internal GamePiece this[Point i_position]
        {
            get
            {
                return this[i_position.X, i_position.Y];
            }
            set
            {
                this[i_position.X, i_position.Y] = value;
            }
        }

        internal int Size
        {
            get
            {
                return r_GameBoard.GetLength(0);
            }
        }

        internal void SetBoardAndGamePieces(Player[] i_Players)
        {
            setNonPlayerLand();

            foreach (Player player in i_Players)
            {
                setPlayerGamePiecesAndLand(player);
            }
        }

        private void setNonPlayerLand()
        {
            Point currLocation;

            for (int row = (this.Size / 2) - 1; row <= this.Size / 2; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    currLocation = new Point(row, col);
                    this[currLocation] = null;
                }
            }
        }

        private void setPlayerGamePiecesAndLand(Player i_Player)
        {
            GamePiece currGamePiece;
            Point currLocation;
            GamePiece.eColor pieceColor = i_Player.PlayerNumber == Player.ePlayerNumber.Player1 ? GamePiece.eColor.Black : GamePiece.eColor.White;
            int firstRow = i_Player.PlayerNumber == Player.ePlayerNumber.Player1 ? (this.Size / 2) + 1 : 0;
            int lastRow = i_Player.PlayerNumber == Player.ePlayerNumber.Player1 ? this.Size : (this.Size / 2) - 1;

            for (int row = firstRow; row < lastRow; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    currLocation = new Point(row, col);

                    if (isSquareBlack(currLocation))
                    {
                        currGamePiece = new GamePiece(currLocation, pieceColor);
                        i_Player.AddGamePiece(currGamePiece);
                        this[currLocation] = currGamePiece;
                    }
                    else
                    {
                        this[currLocation] = null;
                    }
                }
            }
        }

        public static bool IsSquareBlack(int i_Row, int i_Col)
        {
            return (i_Row % 2 == 0 && i_Col % 2 != 0) || (i_Row % 2 != 0 && i_Col % 2 == 0);
        }

        private bool isSquareBlack(Point i_Location)
        {
            return IsSquareBlack(i_Location.X, i_Location.Y);
        }

        internal bool CheckIsLocationInBound(Point i_Location)
        {
            return 0 <= i_Location.X && i_Location.X < this.Size && 0 <= i_Location.Y && i_Location.Y < this.Size;
        }
    }
}