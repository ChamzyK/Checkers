using CheckersLib;
using CheckersLib.BoardElements;
using CheckersLib.GameEventArgs;
using CheckersLib.Repositories;
using System;

namespace CheckersConsole
{
    class ConsoleCheckers : IGame
    {
        public Board Checkers { get; private set; }
        public ConsoleDraw Drawer { get; private set; }
        public bool IsGame { get; set; }
        public EndType GameResult { get; private set; }

        private Location current;
        public Location Current
        {
            get { return current; }
            set
            {
                Drawer.RefreshSquareContent(Checkers[Current.X, Current.Y]);
                Drawer.DrawSelected(value.X, value.Y);
                current = value;
            }
        }

        public ConsoleCheckers(IRepository repo)
        {
            Drawer = new ConsoleDraw();
            Checkers = new Board(Drawer, repo);
            Checkers.EndEvent += Checkers_EndEvent;

            IsGame = true;
            Current = Checkers[0, 0].Position;
        }

        private void Checkers_EndEvent(object sender, EndEventArgs args)
        {
            GameResult = args.EndType;
            FinishGame();
        }
        public string Start()
        {
            while (IsGame)
            {
                DefineAction(Console.ReadKey(true).Key);
            }
            return GameResult.GetString();
        }
        private void DefineAction(ConsoleKey key)
        {
            if (key.IsArrowKey())
            {
                ShiftCurrent(key);
            }
            else if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
            {
                EnterCurrent();
            }
            else if (key == ConsoleKey.Escape)
            {
                FinishGame();
            }
        }
        private void ShiftCurrent(ConsoleKey arrowKey)
        {
            var (X, Y) = arrowKey.GetDirection();
            if (Checkers.InLocate(Current.X + X, Current.Y + Y))
            {
                Current = Checkers[Current.X + X, Current.Y + Y].Position;
            }
        }
        private void EnterCurrent()
        {
            if (!Checkers.TrySelect(Current))
            {
                if(Current == Checkers.SelectedPosition)
                {
                    Checkers.Unselect();
                }
                else
                {
                    Checkers.TryMove(Current);
                }    
            }
        }
        private void FinishGame()
        {
            IsGame = false;
            Console.Clear();
        }
    }
}
