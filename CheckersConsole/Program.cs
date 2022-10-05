namespace CheckersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length == 1 ? args[0] : string.Empty;
            GetGame(path).Start();
        }
        static IGame GetGame(string path)
        {
            return new ConsoleCheckers(new FileRepository(path));
        }
    }
}
