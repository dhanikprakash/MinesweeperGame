using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class RightMoveStrategyTests
    {
        private IMoveStrategy moveStrategy = null;

        [TestInitialize()]
        public void Initialize()
        {
            moveStrategy = new RightMoveStrategy();
        }


        [TestMethod()]
        public void RightMoveStrategy_Test01_IsValidMove_When_X_Less_Than_GridSize()
        {
            bool expected = true;

            bool actual = moveStrategy.IsValidMove(2, 0, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightMoveStrategy_Test02_IsNotValidMove_When_X_Equals_GridSize()
        {
            bool expected = false;

            bool actual = moveStrategy.IsValidMove(7, 0, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightMoveStrategy_Test03_Move_Increment_X()
        {
            int x = 1;
            int y = 1;
            int expectedX = 2;
            int expectedY = 1;

            var (actualX, actualY) = moveStrategy.Move(x, y);

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);


        }
    }
}