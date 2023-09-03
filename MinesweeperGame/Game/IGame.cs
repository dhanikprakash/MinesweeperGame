namespace MinesweeperGame
{
    public interface IGame
    {
        int PlayerX { get; }
        int PlayerY { get; }
        int Lives { get; }
        int Moves { get; }
        int GridSize { get; }
        bool IsValidMove(ConsoleKey move);
        void ProcessMove(ConsoleKey move);
        bool IsGameOver();
    }
}
