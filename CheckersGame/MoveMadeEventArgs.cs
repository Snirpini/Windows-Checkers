using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class MoveMadeEventArgs : EventArgs
    {
        Move m_Move;
        Point? m_CapturedGamePieceLocation;

        internal MoveMadeEventArgs(Move i_Move, Point? i_CapturedGamePieceLocation)
        {
            m_Move = i_Move;
            m_CapturedGamePieceLocation = i_CapturedGamePieceLocation;
        }

        public Move Move
        {
            get
            {
                return m_Move;
            }
        }

        public Point? CapturedGamePieceLocation
        {
            get
            {
                return m_CapturedGamePieceLocation;
            }
        }
    }
}
