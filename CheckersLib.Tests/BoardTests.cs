using CheckersLib;
using CheckersLib.BoardElements;
using CheckersLib.Drawing;
using CheckersLib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersLib.Tests
{
    //TODO: надо ли дописывать тесты для других типов хода и для дамки?
    //остались тесты для продолжающихся атак, трансформации и все типы ходов повторить для дамки
    [TestClass()]
    public class BoardTests
    {
        private IDraw emptyDraw = new EmptyDraw();
        private IRepository emptyRepo = new EmptyRepository();
        [TestMethod()]
        public void BoardTest()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);

            //act
            var square = board[1, 0];
            var figure = square.FigureType;

            //assert
            Assert.AreEqual(new Location(1, 0), square.Position);
            Assert.AreEqual(SquareType.Black, square.Background);
            Assert.AreEqual(FigureType.BCheck, figure);
        }
        [TestMethod()]
        public void InLocateTest()
        {
            //arrange
            var board = new Board(new EmptyDraw(), new EmptyRepository());

            //act
            var result1 = board.InLocate(7, 1);
            var result2 = board.InLocate(8, 8);

            //assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [TestMethod()]
        public void TryMoveTest_WhiteCheckMove()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);

            //act
            board.TrySelect(board[2, 5].Position);
            var whiteMove = board.TryMove(board[1, 4].Position);

            //assert
            Assert.AreEqual(MoveType.Move, whiteMove);
            Assert.AreEqual(FigureType.Empty, board[2, 5].FigureType);
            Assert.AreEqual(FigureType.WCheck, board[1, 4].FigureType);
        }
        [TestMethod()]
        public void TryMoveTest_BlackCheckAttack()
        {
            //arrange
            var squares = new Square[8, 8];
            var board = new Board(emptyDraw, emptyRepo) { TurnColor = Color.Black };
            squares[1, 0] = new Square(new Location(1, 0), board, FigureType.BCheck);
            squares[2, 1] = new Square(new Location(2, 1), board, FigureType.WCheck);
            board.SetField(squares);

            //act
            board.TrySelect(board[1, 0].Position);
            var blackAttack = board.TryMove(board[3, 2].Position);

            //assert
            Assert.AreEqual(MoveType.Attack, blackAttack);
            Assert.AreEqual(FigureType.Empty, board[1, 0].FigureType);
            Assert.AreEqual(FigureType.Empty, board[2, 1].FigureType);
            Assert.AreEqual(FigureType.BCheck, board[3, 2].FigureType);
        }
        [TestMethod()]
        public void TryMoveTest_BlackCheckMove()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo) { TurnColor = Color.Black };

            //act
            board.TrySelect(board[1, 2].Position);
            var blackMove = board.TryMove(board[0, 3].Position);

            //assert
            Assert.AreEqual(MoveType.Move, blackMove);
            Assert.AreEqual(FigureType.Empty, board[1, 2].FigureType);
            Assert.AreEqual(FigureType.BCheck, board[0, 3].FigureType);
        }
        [TestMethod()]
        public void TryMoveTest_WhiteCheckAttack()
        {
            //arrange
            var squares = new Square[8, 8];
            var board = new Board(emptyDraw, emptyRepo);
            squares[3, 2] = new Square(new Location(3, 2), board, FigureType.BCheck);
            squares[4, 3] = new Square(new Location(4, 3), board, FigureType.WCheck);
            board.SetField(squares);

            //act
            board.TrySelect(board[4, 3].Position);
            var whiteAttack = board.TryMove(board[2, 1].Position);

            //assert
            Assert.AreEqual(MoveType.Attack, whiteAttack);
            Assert.AreEqual(FigureType.Empty, board[4, 3].FigureType);
            Assert.AreEqual(FigureType.Empty, board[3, 2].FigureType);
            Assert.AreEqual(FigureType.WCheck, board[2, 1].FigureType);
        }
        [TestMethod()]
        public void UnselectTest()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);

            //act
            board.TrySelect(board[2, 5].Position);
            board.Unselect();

            //assert
            Assert.IsNull(board.SelectedPosition);
        }

        [TestMethod()]
        public void TrySelectTest_MovableCheck()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);

            //act
            board.TrySelect(board[2, 5].Position);

            //assert
            Assert.AreEqual(board[2, 5].Position, (Location)board.SelectedPosition);
        }
        [TestMethod()]
        public void TrySelectTest_UnmovableCheck()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);

            //act
            board.TrySelect(board[1, 0].Position);

            //assert
            Assert.IsNull(board.SelectedPosition);
        }
        [TestMethod()]
        public void TrySelectTest_Empty()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);

            //act
            board.TrySelect(board[0, 3].Position);

            //assert
            Assert.IsNull(board.SelectedPosition);
        }

        [TestMethod()]
        public void SetFieldTest_EmptyField()
        {
            //arrange
            var board = new Board(emptyDraw, emptyRepo);
            var squares = new Square[8, 8];

            //act
            board.SetField(squares);

            //assert
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(FigureType.Empty, board[i, j].FigureType);
                    Assert.AreEqual(new Location(i, j), board[i, j].Position);
                }
            }
        }
    }
}