using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class UpMoveStrategyTests
    {

        private IMoveStrategy moveStrategy = null;

        [TestInitialize()]
        public void Initialize()
        {
            moveStrategy = new UpMoveStrategy();
        }


        [TestMethod()]
        public void UpMoveStrategy_Test01_IsValidMove_When_Y_Greater_Than_One()
        {
            bool expected = true;

            bool actual = moveStrategy.IsValidMove(0, 2, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpMoveStrategy_Test02_IsNotValidMove_When_Y_Less_Than_One()
        {
            bool expected = false;

            bool actual = moveStrategy.IsValidMove(0, 0, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpMoveStrategy_Test03_Move_Decreemnt_Y()
        {
            int x = 1;
            int y = 1;
            int expectedX = 1;
            int expectedY = 0;

            var (actualX, actualY) = moveStrategy.Move(x, y);

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);


        }
    }
}