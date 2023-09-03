namespace MinesweeperGame
{

    public class Renderer : IRenderer
    {
        public void RenderStatus(IGame game)
        {
            Console.WriteLine($"Current Position: " + Helpers.GetChessboardPosition(game.PlayerX, game.PlayerY, game.GridSize));
            Console.WriteLine($"Lives Left: {game.Lives}");
            Console.WriteLine($"Moves Taken: {game.Moves}");
            RenderGrid(game);
        }

        public void RenderResult(IGame game)
        {
            if (game.PlayerX == game.GridSize - 1)
            {
                Console.WriteLine($"Congratulations! You reached the other side of the board in {game.Moves} moves.");
            }
            else
            {
                Console.WriteLine("Game Over - You ran out of lives!");
            }
        }

        protected void RenderGrid(IGame game)
        {
            for (int row = 0; row < game.GridSize; row++)
            {
                for (int col = 0; col < game.GridSize; col++)
                {
                    if (row == game.PlayerY && col == game.PlayerX)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }


    }
}
