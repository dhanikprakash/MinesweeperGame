namespace MinesweeperGame
{
    public class RightMoveStrategy : IMoveStrategy
    {
        public bool IsValidMove(int playerX, int playerY, int gridSize)
        {
            return playerX < gridSize - 1;
        }

        public (int newPlayerX, int newPlayerY) Move(int playerX, int playerY)
        {
            return (++playerX, playerY);
        }
    }
}
