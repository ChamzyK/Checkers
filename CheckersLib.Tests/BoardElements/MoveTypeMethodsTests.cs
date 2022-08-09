using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersLib.BoardElements.Tests
{
    [TestClass()]
    public class MoveTypeMethodsTests
    {
        [TestMethod()]
        public void IsMoveTest()
        {
            //arrange
            var move = MoveType.Cancel;

            //act
            var result = move.IsMove();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsAttackTest()
        {
            //arrange
            var move = MoveType.AttackTransformationWithContinue;

            //act
            var result = move.IsAttack();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsContinueAttackTest()
        {
            //arrange
            var move = MoveType.AttackWithContinue;

            //act
            var result = move.IsContinueAttack();

            //assert
            Assert.IsTrue(result);
        }
    }
}