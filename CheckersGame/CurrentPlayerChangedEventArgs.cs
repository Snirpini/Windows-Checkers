using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class CurrentPlayerChangedEventArgs : EventArgs
    {
        private List<Point> m_CurrentPlayerGamePiecesLocationList = new List<Point>();
        private List<Point> m_NextPlayerGamePiecesLocationList = new List<Point>();

        internal CurrentPlayerChangedEventArgs(List<Point> i_CurrentPlayerGamePiecesLocationList, List<Point> i_NextPlayerGamePiecesLocationList)
        {
            m_CurrentPlayerGamePiecesLocationList = i_CurrentPlayerGamePiecesLocationList;
            m_NextPlayerGamePiecesLocationList = i_NextPlayerGamePiecesLocationList;
        }

        public List<Point> CurrentPlayerGamePiecesLocationList
        {
            get
            {
                return m_CurrentPlayerGamePiecesLocationList;
            }
        }

        public List<Point> NextPlayerGamePiecesLocationList
        {
            get
            {
                return m_NextPlayerGamePiecesLocationList;
            }
        }
    }
}
