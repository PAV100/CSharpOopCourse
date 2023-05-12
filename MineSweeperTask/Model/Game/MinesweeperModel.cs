using MinesweeperTask.Model.GameField;
using MinesweeperTask.Model.GameSettings;
using MinesweeperTask.Model.GameStatistics;
using MinesweeperTask.Model.GameHighScores;

namespace MinesweeperTask.Model.Game
{
    public class MinesweeperModel : IMinesweeperModel
    {
        public GameStatus gameStatus;

        private Settings settings;

        private Statistics statistics;

        public Field gamefield;

        private HighScores highScores;

        public MinesweeperModel()
        {
            gameStatus = GameStatus.Ready;

            settings = new(GameLevelName.Beginner);

            statistics = new();

            gamefield = new Field(settings, statistics);

            highScores = new HighScores();
        }

        public void ResetGame()
        {
            gameStatus = GameStatus.Ready;

            gamefield.ResetGamefield();

            statistics.ResetStatistics();
        }

        public bool IsWin()
        {
            return false;
        }

        public bool IsLoss()
        {
            return false;
        }
    }
}
