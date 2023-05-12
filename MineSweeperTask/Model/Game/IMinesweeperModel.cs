namespace MinesweeperTask.Model.Game
{
    public interface IMinesweeperModel
    {
        public void ResetGame();

        public bool IsWin();

        public bool IsLoss();
    }
}
