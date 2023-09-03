namespace MinesweeperGame
{
    public class DownMoveStrategy : IMoveStrategy
    {
        public bool IsValidMove(int playerX, int playerY, int gridSize)
        {
            return playerY < gridSize - 1;
        }

        public (int newPlayerX, int newPlayerY) Move(int playerX, int playerY)
        {
            return (playerX, ++playerY);
        }
    }
}