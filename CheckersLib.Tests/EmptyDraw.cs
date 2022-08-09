using CheckersLib.BoardElements;
using CheckersLib.Drawing;

namespace CheckersLib.Tests
{
    class EmptyDraw : IDraw
    {
        public Board Board { get; set; }

        public void ClearAll()
        {

        }

        public void DrawAll()
        {

        }

        public void RefreshSquareContent(Square square)
        {

        }

        public void WriteNames((string name1, string name2) names)
        {

        }
    }
}
