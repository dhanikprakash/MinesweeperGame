namespace MinesweeperGame
{
    public class UpMoveStrategy : IMoveStrategy
    {
        public bool IsValidMove(int playerX, int playerY, int gridSize)
        {
            return playerY > 0;
        }

        public (int newPlayerX, int newPlayerY) Move(int playerX, int playerY)
        {
            return (playerX, --playerY);
        }
    }
}
