using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    internal class GameModel
    {
        public GameStatus gameStatus;

        public Gamefield gamefield;

        private Settings settings;

        private Statistics statistics;

        private HighScores highScores;

        public GameModel()
        {
            gameStatus = GameStatus.Ready;

            settings = new(GameLevelName.Beginner);

            gamefield = new Gamefield(settings.RowsCount, settings.ColumnsCount, settings.MinesCount);

            statistics = new();

            gamefield.SetSettings(settings);
            gamefield.SetStatistics(statistics);

            settings.SetGamelModel(this);
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
