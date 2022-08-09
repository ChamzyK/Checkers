using CheckersLib.BoardElements;
using CheckersLib.Repositories;
using System.IO;

namespace CheckersUI
{
    class FileRepository : IRepository
    {
        public (string Name1, string Name2) ReadNames()
        {
            return ("Игрок1", "Игрок2");
        }

        public void SaveEndType(EndType endType)
        {
            using (var sw = new StreamWriter("result.txt"))
            {
                sw.WriteLine(endType.GetString());
            }
        }
    }
}
