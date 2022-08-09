using CheckersLib.BoardElements;
using System;

namespace CheckersLib.GameEventArgs
{
    public class EndEventArgs : EventArgs
    {
        public EndType EndType { get; }
        public EndEventArgs(EndType endType)
        {
            EndType = endType;
        }

    }
}
