using CheckersLib.BoardElements;
using CheckersLib.Repositories;
using System;
using System.IO;

namespace CheckersConsole
{
    class FileRepository : IRepository
    {
        public string Path { get; set; }
        private readonly (string Name1, string Name2) standardNames = ("Player1", "Player2");

        public FileRepository(string path)
        {
            Path = path;
        }
        public (string Name1, string Name2) ReadNames()
        {
            if (!string.IsNullOrEmpty(Path) && File.Exists(Path))
            {
                return GetNames();
            }
            else
            {
                return standardNames;
            }
        }
        private (string Name1, string Name2) GetNames()
        {
            string[] names;
            using (var sr = new StreamReader(Path))
            {
                names = sr.ReadToEnd().Split(' ');
            }
            return SplitNames(names);
        }
        private (string Name1, string Name2) SplitNames(string[] names)
        {
            return names.Length == 2 ? (names[0], names[1]) : standardNames;
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
