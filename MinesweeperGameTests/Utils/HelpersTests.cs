using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class HelpersTests
    {

        private int gridSize = 8;

        [TestMethod()]
        public void GetChessboardPosition_Test01_Start_Postion()
        {
            int x = 0;
            int y = 0;
            string expected = "A8";

            string actual = Helpers.GetChessboardPosition(x, y, gridSize);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetChessboardPosition_Test02_End_Postion()
        {
            int x = 7;
            int y = 7;
            string expected = "H1";

            string actual = Helpers.GetChessboardPosition(x, y, gridSize);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0, 1, "A7")]
        [DataRow(0, 2, "A6")]
        [DataRow(0, 6, "A2")]
        [DataRow(0, 7, "A1")]
        [DataRow(6, 0, "G8")]
        [DataRow(7, 0, "H8")]
        [DataRow(4, 3, "E5")]
        [DataRow(5, 4, "F4")]
        [DataRow(3, 6, "D2")]
        public void GetChessboardPosition_Test03(int x, int y, string expected)
        {

            string actual = Helpers.GetChessboardPosition(x, y, gridSize);

            Assert.AreEqual(expected, actual);
        }
    }
}