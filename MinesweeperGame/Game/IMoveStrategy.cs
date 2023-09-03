namespace MinesweeperGame
{
    public interface IMoveStrategy
    {
        bool IsValidMove(int playerX, int playerY, int gridSize);
        (int newPlayerX, int newPlayerY) Move(int playerX, int playerY);
    }
}
