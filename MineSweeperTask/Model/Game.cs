using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    internal class Game
    {
        public GameStatus gameStatus;

        public GameLevel gameLevel;

        private Dictionary<(int ColunmIndex, int RowIndex), MinefieldCell> minefield;

        private Dictionary<(int ColunmIndex, int RowIndex), MinefieldMapCell> minefieldMap;

        public int unmarkedMinesCounter;

        public int timeCounter;

        Game()
        {
            gameStatus = GameStatus.Ready;

            gameLevel = new GameLevel(GameLevelName.Beginner, 0, 0, 0);

            minefield = new Dictionary<(int ColunmIndex, int RowIndex), MinefieldCell>();

            minefieldMap = new Dictionary<(int ColunmIndex, int RowIndex), MinefieldMapCell>();

            unmarkedMinesCounter = gameLevel.MinesCount;

            timeCounter = 0;
        }
    }
}
