﻿namespace MinesweeperTask.Model
{
    internal class GameLevel
    {
        private const int MinColumnsCount = 1;
        private const int MaxColumnsCount = 50;

        private const int MinRowsCount = 1;
        private const int MaxRowsCount = 50;

        private const int MinMinesCount = 0;

        public int CustomDefaultColumnsCount { get; set; }

        public int CustomDefaultRowsCount { get; set; }

        public int CustomDefaultMinsCount { get; set; }


        public GameLevelName Name { get; private set; }

        public int ColumnsCount { get; set; }

        public int RowsCount { get; set; }

        public int MinesCount { get; set; }

        public GameLevel(GameLevelName name, int columnsCount, int rowsCount, int minesCount)
        {
            Name = name;

            switch (Name)
            {
                case GameLevelName.Beginner:
                    ColumnsCount = 9;
                    RowsCount = 9;
                    MinesCount = 10;
                    break;
                case GameLevelName.Amateur:
                    ColumnsCount = 16;
                    RowsCount = 16;
                    MinesCount = 30;
                    break;
                case GameLevelName.Professional:
                    ColumnsCount = 30;
                    RowsCount = 16;
                    MinesCount = 50;
                    break;
                case GameLevelName.Custom:
                    ColumnsCount = GetLimitedValue(columnsCount, MinColumnsCount, MaxColumnsCount);
                    CustomDefaultColumnsCount = ColumnsCount;
                    RowsCount = GetLimitedValue(rowsCount, MinRowsCount, MaxRowsCount);
                    CustomDefaultRowsCount = RowsCount;
                    MinesCount = GetLimitedValue(minesCount, MinMinesCount, ColumnsCount * RowsCount);
                    CustomDefaultMinsCount = MinesCount;
                    break;
            }
        }

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
