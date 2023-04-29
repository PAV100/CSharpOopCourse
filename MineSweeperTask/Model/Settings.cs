namespace MinesweeperTask.Model
{
    internal class Settings
    {
        public bool IsQuestionMarkEnabled { get; set; }

        public bool IsSafeFirstMove { get; set; }

        public int CustomMinColumnsCount { get; } = 1;
        public int CustomMaxColumnsCount { get; } = 50;

        public int CustomMinRowsCount { get; } = 1;
        public int CustomMaxRowsCount { get; } = 50;

        public int CustomMinMinesCount { get; } = 0;
        public int CustomMaxMinesCount { get; private set; }

        public int CustomDefaultColumnsCount { get; set; }

        public int CustomDefaultRowsCount { get; set; }

        public int CustomDefaultMinesCount { get; set; }

        public GameLevelName Name { get; private set; }

        public int ColumnsCount { get; set; }

        public int RowsCount { get; set; }

        public int MinesCount { get; set; }

        public GameModel gameModel;

        public Settings(GameLevelName name, int columnsCount = 0, int rowsCount = 0, int minesCount = 0)
        {
            IsQuestionMarkEnabled = true;

            IsSafeFirstMove = true;

            SetGameLevelParameters(name, columnsCount, rowsCount, minesCount);
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void SetGamelModel(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void SetGameLevel(GameLevelName name, int columnsCount = 0, int rowsCount = 0, int minesCount = 0)
        {
            SetGameLevelParameters(name, columnsCount, rowsCount, minesCount);
            gameModel.ResetGame();
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void SetGameLevelParameters(GameLevelName name, int columnsCount = 0, int rowsCount = 0, int minesCount = 0)
        {
            Name = name;

            switch (name)
            {
                case GameLevelName.Beginner:
                    RowsCount = 9;
                    ColumnsCount = 9;
                    MinesCount = 10;
                    break;
                case GameLevelName.Amateur:
                    RowsCount = 16;
                    ColumnsCount = 16;
                    MinesCount = 30;
                    break;
                case GameLevelName.Professional:
                    RowsCount = 16;
                    ColumnsCount = 30;
                    MinesCount = 50;
                    break;
                case GameLevelName.Custom:
                    RowsCount = GetLimitedValue(rowsCount, CustomMinRowsCount, CustomMaxRowsCount);
                    ColumnsCount = GetLimitedValue(columnsCount, CustomMinColumnsCount, CustomMaxColumnsCount);
                    CustomMaxMinesCount = ColumnsCount * RowsCount - (IsSafeFirstMove ? 1 : 0);
                    MinesCount = GetLimitedValue(minesCount, CustomMinMinesCount, CustomMaxMinesCount);
                    break;
            }

            CustomDefaultRowsCount = RowsCount;
            CustomDefaultColumnsCount = ColumnsCount;
            CustomDefaultMinesCount = MinesCount;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        private static int GetLimitedValue(int value, int lowlimit, int highLimit)
        {
            if (value < lowlimit)
            {
                return lowlimit;
            }

            if (value > highLimit)
            {
                return highLimit;
            }

            return value;
        }
    }
}
