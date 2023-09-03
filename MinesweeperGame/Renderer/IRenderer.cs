namespace MinesweeperGame
{
    public interface IRenderer
    {
        void RenderStatus(IGame game);
        void RenderResult(IGame game);
    }
}
