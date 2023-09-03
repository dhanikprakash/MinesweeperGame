using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class GameTests
    {
        Dictionary<ConsoleKey, IMoveStrategy> strategies = null;
        IGame game = null;
        int gridSize = 8;
        int initialLives = 5;
        private Mock<IMineService> mineService = null;
        private IRenderer renderer = null;

        [TestInitialize()]
        public void Initialize()
        {
            mineService = new Mock<IMineService>();
            //mock to disable mines
            mineService.Setup(x => x.GenerateMines(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>())).Returns(GetNoMinesData(8, 8));

            strategies = new Dictionary<ConsoleKey, IMoveStrategy>
            {
                {ConsoleKey.UpArrow, new UpMoveStrategy()},
                {ConsoleKey.DownArrow, new DownMoveStrategy()},
                {ConsoleKey.LeftArrow, new LeftMoveStrategy()},
                {ConsoleKey.RightArrow, new RightMoveStrategy()}
            };

            game = new Game(gridSize, initialLives, mineService.Object, strategies);
            renderer = new Renderer();
        }

        [TestMethod]
        [DataRow(ConsoleKey.RightArrow)]
        [DataRow(ConsoleKey.RightArrow)]
        public void Game_Test01_StartGame_IsValidMove_Right_Down(ConsoleKey key)
        {
            bool expected = true;

            bool actual = game.IsValidMove(key);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(ConsoleKey.A)]
        [DataRow(ConsoleKey.Z)]
        [DataRow(ConsoleKey.P)]
        [DataRow(ConsoleKey.S)]
        public void Game_Test02_StartGame_IsInValidMove_Non_Arrow_keys(ConsoleKey key)
        {
            bool expected = false;

            bool actual = game.IsValidMove(key);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Game_Test03_StartGame_Render_Current_Position_A8()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"Current Position: A8\r\n";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }
        [TestMethod]
        public void Game_Test04_StartGame_Render_Full_Lives_Left()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"Lives Left: {initialLives}\r\n";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod]
        public void Game_Test05_StartGame_Render_Zero_Moves_Taken()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"Moves Taken: 0\r\n";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod]
        public void Game_Test06_StartGame_Render_Current_Position()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"P - - - - - - -";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod]
        public void Game_Test07_Process_Move_Update_Current_Position()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                int expectedY = 0;
                int expectedX = 1;

                // Act
                game.ProcessMove(ConsoleKey.RightArrow);
                renderer.RenderStatus(game);
                string expectedMoves = $"Moves Taken: 1\r\n";
                string expectedPosition = $"Current Position: B8\r\n";
                string expectedOutput = $"- P - - - - - -";

                // Assert

                Assert.AreEqual(expectedX, game.PlayerX);
                Assert.AreEqual(expectedY, game.PlayerY);
                Assert.IsFalse(game.IsGameOver());
                Assert.IsTrue(sw.ToString().Contains(expectedPosition));
                Assert.IsTrue(sw.ToString().Contains(expectedMoves));
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod]
        public void Game_Test08_Process_Move_Right_Update_Current_Position()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                int expectedY = 0;
                int expectedX = 6;

                // Act
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                renderer.RenderStatus(game);
                string expectedMoves = $"Moves Taken: 6\r\n";
                string expectedPosition = $"Current Position: G8\r\n";
                string expectedOutput = $"- - - - - - P -";

                // Assert

                Assert.AreEqual(expectedX, game.PlayerX);
                Assert.AreEqual(expectedY, game.PlayerY);
                Assert.IsFalse(game.IsGameOver());
                Assert.IsTrue(sw.ToString().Contains(expectedPosition));
                Assert.IsTrue(sw.ToString().Contains(expectedMoves));
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod]
        public void Game_Test09_Process_Move_Right_Should_End_Game_When_MinesDisabled()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                int expectedY = 0;
                int expectedX = 7;

                // Act
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                renderer.RenderStatus(game);
                string expectedMoves = $"Moves Taken: 7\r\n";
                string expectedPosition = $"Current Position: H8\r\n";
                string expectedOutput = $"- - - - - - - P";

                // Assert

                Assert.AreEqual(expectedX, game.PlayerX);
                Assert.AreEqual(expectedY, game.PlayerY);
                Assert.IsTrue(sw.ToString().Contains(expectedPosition));
                Assert.IsTrue(sw.ToString().Contains(expectedMoves));
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));

                Assert.IsTrue(game.IsGameOver());
            }

        }


        private bool[,] GetNoMinesData(int rows, int cols)
        {
            var mineArray = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    mineArray[row, col] = false;
                }
            }

            return mineArray;
        }
    }
}