using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersLib.BoardElements.Tests
{
    [TestClass()]
    public class ColorMethodsTests
    {
        [TestMethod()]
        public void GetCheckTypeTest()
        {
            //arrange
            var color = Color.White;

            //act
            var checkType = color.GetChecker();

            //assert
            Assert.AreEqual(FigureType.WCheck, checkType);
        }
    }
}