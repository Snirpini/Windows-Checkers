using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class MoveMadeEventArgs : EventArgs
    {
        private readonly Move r_Move;
        private readonly Point? r_CapturedGamePieceLocation;

        internal MoveMadeEventArgs(Move i_Move, Point? i_CapturedGamePieceLocation)
        {
            r_Move = i_Move;
            r_CapturedGamePieceLocation = i_CapturedGamePieceLocation;
        }

        public Move Move
        {
            get
            {
                return r_Move;
            }
        }

        public Point? CapturedGamePieceLocation
        {
            get
            {
                return r_CapturedGamePieceLocation;
            }
        }
    }
}
