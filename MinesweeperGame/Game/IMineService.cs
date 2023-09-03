namespace MinesweeperGame
{
    public interface IMineService
    {
        bool[,] GenerateMines(int rows, int cols, double density);
    }
}
