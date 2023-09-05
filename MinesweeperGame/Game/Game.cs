namespace MinesweeperGame
{
    public class Game : IGame
    {
        private int gridSize;
        private int playerX;
        private int playerY;
        private int lives;
        private int moves;
        private bool[,] mines;
        private bool gameOver;
        private Dictionary<ConsoleKey, IMoveStrategy> strategies;

        public Game(int gridSize, int initialLives, IMineService mineService, Dictionary<ConsoleKey, IMoveStrategy> strategies)
        {
            playerX = 0;
            playerY = 0;
            moves = 0;
            gameOver = false;
            this.gridSize = gridSize;
            this.strategies = strategies;
            lives = initialLives;
            mines = mineService.GenerateMines(gridSize, gridSize, 0.2);
        }

        public int PlayerX => playerX;
        public int PlayerY => playerY;
        public int Lives => lives;
        public int Moves => moves;

        public int GridSize => gridSize;

        public bool IsValidMove(ConsoleKey move)
        {
            var result = false;
            if (strategies.TryGetValue(move, out var strategy))
            {
                result = strategy.IsValidMove(PlayerX, PlayerY, gridSize);
            }
            return result;

        }

        public void ProcessMove(ConsoleKey move)
        {
            moves++;
            int newPlayerX = playerX;
            int newPlayerY = playerY;

            if (strategies.TryGetValue(move, out var strategy))
            {
                (newPlayerX, newPlayerY) = strategy.Move(newPlayerX, newPlayerY);
            }

            if (!mines[newPlayerY, newPlayerX])
            {
                playerX = newPlayerX;
                playerY = newPlayerY;
            }
            else
            {
                lives--;
                if (lives <= 0)
                {
                    gameOver = true;
                }
            }

        }

        public bool IsGameOver()
        {
            return gameOver || playerX == gridSize - 1 || playerY == gridSize - 1;
        }

    }
}
