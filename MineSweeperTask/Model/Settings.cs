namespace MinesweeperTask.Model
{
    internal class Settings
    {
        public bool IsQuestionMarkEnabled { get; set; }

        public bool IsSafeFirstMove { get; set; }

        public int MinColumnsCount { get; } = 1;
        public int MaxColumnsCount { get; } = 50;

        public int MinRowsCount { get; } = 1;
        public int MaxRowsCount { get; } = 50;

        public int MinMinesCount { get; } = 0;
        public int MaxMinesCount { get; private set; }

        public int CustomDefaultColumnsCount { get; set; }

        public int CustomDefaultRowsCount { get; set; }

        public int CustomDefaultMinesCount { get; set; }

        public GameLevelName Name { get; private set; }

        public int ColumnsCount { get; set; }

        public int RowsCount { get; set; }

        public int MinesCount { get; set; }

        public Game game;

        public Settings(GameLevelName name, int columnsCount, int rowsCount, int minesCount)
        {
            IsQuestionMarkEnabled = true;

            IsSafeFirstMove = true;

            SetGameLevelParameters(name, columnsCount, rowsCount, minesCount);
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void SetGamel(Game game)
        {
            this.game = game;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void SetGameLevel(GameLevelName name, int columnsCount, int rowsCount, int minesCount)
        {
            SetGameLevelParameters(name, columnsCount, rowsCount, minesCount);
            game.ResetGame();
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
                    RowsCount = GetLimitedValue(rowsCount, MinRowsCount, MaxRowsCount);
                    CustomDefaultRowsCount = RowsCount;

                    ColumnsCount = GetLimitedValue(columnsCount, MinColumnsCount, MaxColumnsCount);
                    CustomDefaultColumnsCount = ColumnsCount;

                    MaxMinesCount = ColumnsCount * RowsCount - (IsSafeFirstMove ? 1 : 0);
                    MinesCount = GetLimitedValue(minesCount, MinMinesCount, MaxMinesCount);
                    CustomDefaultMinesCount = MinesCount;
                    break;
            }
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
