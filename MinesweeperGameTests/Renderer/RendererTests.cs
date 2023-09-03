using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MinesweeperGame.Tests
{
    [TestClass()]
    public class RendererTests
    {
        Dictionary<ConsoleKey, IMoveStrategy> strategies = null;
        IGame game = null;
        int gridSize = 8;
        int initialLives = 5;
        private Mock<IMineService> mineService = null;

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
        }


        [TestMethod()]
        public void Render_Test01_RenderStatus_Lives_Left_AND_Moves_Taken_Message()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"Lives Left: {game.Lives}\r\nMoves Taken: {game.Moves}\r\n";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod()]
        public void Render_Test02_RenderResult_Game_Over_Message()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderResult(game);
                string expectedOutput = $"Game Over - You ran out of lives!";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod()]
        public void Render_Test03_RenderResult_Congratulations_Message()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                // Act
                renderer.RenderResult(game);
                string expectedOutput = $"Congratulations! You reached the other side of the board in 7 moves.\r\n";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }


        [TestMethod()]
        public void Render_Test04_RenderStatus_Current_Position_Message()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"Current Position: {Helpers.GetChessboardPosition(game.PlayerX, game.PlayerY, game.GridSize)}\r\n";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod()]
        public void Render_Test05_RenderStatus_Current_Board_X0_Y0()
        {
            // Arrange
            IRenderer renderer = new Renderer();

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
        [TestMethod()]
        public void Render_Test06_RenderStatus_Current_Board_X0_Y1()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                game.ProcessMove(ConsoleKey.RightArrow);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"- P - - - - - -";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod()]
        public void Render_Test07_RenderStatus_Current_Board_X0_Y2()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"- - P - - - - -";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }


        [TestMethod()]
        public void Render_Test08_RenderStatus_Current_Board_X0_Y7()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);
                game.ProcessMove(ConsoleKey.RightArrow);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"- - - - - - - P";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }

        [TestMethod()]
        public void Render_Test09_RenderStatus_Current_Board_X1_Y0()
        {
            // Arrange
            IRenderer renderer = new Renderer();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                game.ProcessMove(ConsoleKey.DownArrow);

                // Act
                renderer.RenderStatus(game);
                string expectedOutput = $"- - - - - - - -";

                // Assert
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
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