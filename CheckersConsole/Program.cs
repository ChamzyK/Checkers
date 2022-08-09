namespace CheckersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetGame(args[0]).Start();
        }
        static IGame GetGame(string path)
        {
            return new ConsoleCheckers(new FileRepository(path));
        }
    }
}
