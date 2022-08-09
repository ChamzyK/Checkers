using CheckersLib.BoardElements;
using System;

namespace CheckersLib.GameEventArgs
{
    public class MoveEventArgs : EventArgs
    {
        public MoveType MoveType { get; }
        public Location Begin { get; }
        public Location End { get; }

        public MoveEventArgs(MoveType moveType, Location begin, Location end)
        {
            MoveType = moveType;
            Begin = begin;
            End = end;
        }
    }
}
