using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class MineServiceTests
    {
        private IMineService mineService = null;

        [TestInitialize()]
        public void Initialize()
        {
            mineService = new MineService();
        }


        [TestMethod()]
        public void GenerateMines_Test01_Initial_Position_Not_A_Mine()
        {
            int rows = 8;
            int cols = 8;
            double density = 0.2;

            var actual = mineService.GenerateMines(rows, cols, density);


            Assert.IsFalse(actual[0, 0]);
        }
    }
}