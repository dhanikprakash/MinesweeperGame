namespace MinesweeperGame
{
    public class MineService : IMineService
    {
        public bool[,] GenerateMines(int rows, int cols, double density)
        {
            var random = new Random();
            var mineArray = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    mineArray[row, col] = random.NextDouble() < density;
                }
            }

            mineArray[0, 0] = false;

            return mineArray;
        }
    }
}
