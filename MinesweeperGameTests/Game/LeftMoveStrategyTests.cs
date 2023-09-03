using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class LeftMoveStrategyTests
    {
        private IMoveStrategy moveStrategy = null;

        [TestInitialize()]
        public void Initialize()
        {
            moveStrategy = new LeftMoveStrategy();
        }


        [TestMethod()]
        public void LeftMoveStrategy_Test01_IsValidMove_When_X_Greater_Than_One()
        {
            bool expected = true;

            bool actual = moveStrategy.IsValidMove(2, 0, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftMoveStrategy_Test02_IsNotValidMove_When_X_Less_Than_One()
        {
            bool expected = false;

            bool actual = moveStrategy.IsValidMove(0, 0, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LeftMoveStrategy_Test03_Move_Decreemnt_X()
        {
            int x = 1;
            int y = 1;
            int expectedX = 0;
            int expectedY = 1;

            var (actualX, actualY) = moveStrategy.Move(x, y);

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);


        }
    }
}