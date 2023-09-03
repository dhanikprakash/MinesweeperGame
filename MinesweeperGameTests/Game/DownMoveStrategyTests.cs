using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class DownMoveStrategyTests
    {
        private IMoveStrategy moveStrategy = null;

        [TestInitialize()]
        public void Initialize()
        {
            moveStrategy = new DownMoveStrategy();
        }


        [TestMethod()]
        public void DownMoveStrategy_Test01_IsValidMove_When_Y_Less_Than_GridSize()
        {
            bool expected = true;

            bool actual = moveStrategy.IsValidMove(2, 2, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DownMoveStrategy_Test02_IsNotValidMove_When_Y_Equals_GridSize()
        {
            bool expected = false;

            bool actual = moveStrategy.IsValidMove(0, 7, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DownMoveStrategy_Test03_Move_Increment_Y()
        {
            int x = 1;
            int y = 1;
            int expectedX = 1;
            int expectedY = 2;

            var (actualX, actualY) = moveStrategy.Move(x, y);

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);


        }
    }
}