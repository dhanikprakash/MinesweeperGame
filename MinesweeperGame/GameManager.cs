using MinesweeperGame;


class GameManager
{
    static void Main(string[] args)
    {

        int gridSize = 8;
        int initialLives = 5;
        IMineService mineService = new MineService();
        var strategies = new Dictionary<ConsoleKey, IMoveStrategy>
        {
            {ConsoleKey.UpArrow, new UpMoveStrategy()},
            {ConsoleKey.DownArrow, new DownMoveStrategy()},
            {ConsoleKey.LeftArrow, new LeftMoveStrategy()},
            {ConsoleKey.RightArrow, new RightMoveStrategy()}
        };


        IGame game = new Game(gridSize, initialLives, mineService, strategies);
        IRenderer renderer = new Renderer();
        Console.WriteLine("Welcome to the Minesweeper game!");
        while (!game.IsGameOver())
        {
            Console.Clear();
            renderer.RenderStatus(game);
            Console.Write("Enter your move (up-arrow, down-arrow, left-arrow, right-arrow): ");
            ConsoleKey move = Console.ReadKey().Key;

            if (game.IsValidMove(move))
            {
                game.ProcessMove(move);
            }
            else
            {
                Console.WriteLine("Invalid move. Please enter up-arrow, down-arrow, left-arrow, right-arrow.");
            }
        }

        Console.Clear();
        renderer.RenderStatus(game);
        renderer.RenderResult(game);
    }
}







