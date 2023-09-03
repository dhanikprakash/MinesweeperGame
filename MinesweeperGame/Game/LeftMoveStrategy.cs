namespace MinesweeperGame
{
    public class LeftMoveStrategy : IMoveStrategy
    {
        public bool IsValidMove(int playerX, int playerY, int gridSize)
        {
            return playerX > 0;
        }

        public (int newPlayerX, int newPlayerY) Move(int playerX, int playerY)
        {
            return (--playerX, playerY);
        }
    }
}
