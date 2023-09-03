namespace MinesweeperGame
{
    public static class Helpers
    {
        public static string GetChessboardPosition(int x, int y, int gridSize)
        {
            char column = (char)('A' + x);
            int row = gridSize - y;
            return $"{column}{row}";
        }
    }
}
