using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class InvalidMoveEnteredEventArgs : EventArgs
    {
        public enum eInvalidReason
        {
            OutOfBoard,
            SourceIsEmpty,
            SourceIsOpponent,
            InvalidCheckersMove,
            HasMandatoryMove,
            MultipleCapture
        }

        private readonly eInvalidReason r_InvalidReason;

        public InvalidMoveEnteredEventArgs(eInvalidReason i_InvalidReason)
        {
            r_InvalidReason = i_InvalidReason;
        }

        public eInvalidReason InvalidReason 
        {
            get
            {
                return r_InvalidReason;
            }
        }
    }
}
