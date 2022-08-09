using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersLib.BoardElements.Tests
{
    [TestClass()]
    public class FigureTypeMethodsTests
    {
        [TestMethod()]
        public void IsWhiteTest()
        {
            //arrange
            var type = FigureType.WQueen;

            //act
            var result = type.IsWhite();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsBlackTest()
        {
            //arrange
            var type = FigureType.BCheck;

            //act
            var result = type.IsBlack();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            //arrange
            var type = FigureType.Empty;

            //act
            var result = type.IsEmpty();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsCheckTest()
        {
            //arrange
            var type = FigureType.WQueen;

            //act
            var result = type.IsCheck();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsQueenTest()
        {
            //arrange
            var type = FigureType.BQueen;

            //act
            var result = type.IsQueen();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetColorTest()
        {
            //arrange
            var type = FigureType.Empty;

            //act
            var color = type.GetColor();

            //assert
            Assert.AreEqual(Color.None, color);
        }
    }
}