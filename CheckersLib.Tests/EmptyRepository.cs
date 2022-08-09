using CheckersLib.BoardElements;
using CheckersLib.Repositories;

namespace CheckersLib.Tests
{
    class EmptyRepository : IRepository
    {
        public (string Name1, string Name2) ReadNames()
        {
            return ("Player1", "Player2");
        }

        public void SaveEndType(EndType endType)
        {

        }
    }
}
