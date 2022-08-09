using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersLib.BoardElements.Tests
{
    [TestClass()]
    public class EndTypeMethodsTests
    {
        [TestMethod()]
        public void GetStringTest()
        {
            //arrange
            var endType = EndType.Standoff;

            //act
            var result = endType.GetString();

            //assert
            Assert.AreEqual("Ничья", result);
        }
    }
}