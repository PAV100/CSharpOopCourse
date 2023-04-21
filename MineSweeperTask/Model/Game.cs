using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    internal class Game
    {
        public GameStatus gameStatus;

        public Gamefield gamefield;

        private Settings settings;

        private Statistics statistics;

        private HighScores highScores;

        public Game()
        {
            gameStatus = GameStatus.Ready;

            settings = new(GameLevelName.Beginner, 0, 0, 0);

            gamefield = new Gamefield(settings.RowsCount, settings.ColumnsCount, settings.MinesCount);

            statistics = new();

            gamefield.SetSettings(settings);
            gamefield.SetStatistics(statistics);

            settings.SetGamel(this);
        }

        public void ResetGame()
        {
            gameStatus = GameStatus.Ready;

            gamefield.ResetGameField();

            statistics.ResetStatistics();
        }
    }
}
