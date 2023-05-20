using MinesweeperTask.Model.GameSettings;
using MinesweeperTask.Model.GameStatistics;
using System;
using System.Collections.Generic;

namespace MinesweeperTask.Model.GameField
{
    public class Field : IField
    {
        public MinefieldCell[,] minefield;

        private bool isMinesCountGreaterFreeCellsCount;

        private bool isMinefieldPlaced;

        private Settings settings;

        private Statistics statistics;

        public int RowsCount { get; }

        public int ColumnsCount { get; }

        private int MinesCount { get; }

        public Field(Settings settings, Statistics statistics)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings), "Settings entity must not be null.");
            }

            if (statistics is null)
            {
                throw new ArgumentNullException(nameof(statistics), "Statistics entity must not be null.");
            }

            this.settings = settings;
            this.statistics = statistics;

            RowsCount = settings.RowsCount;
            ColumnsCount = settings.ColumnsCount;
            MinesCount = settings.MinesCount;

            isMinesCountGreaterFreeCellsCount = MinesCount > RowsCount * ColumnsCount - MinesCount;

            minefield = new MinefieldCell[RowsCount, ColumnsCount];
            PlaceMinefieldExceptFreeCell(0, 0);
        }

        /// <summary>
        /// Method randomly places MinesCount mines in a class instance field minefield.
        /// Mines can be placed in all cells of minefield, but prohibited cell (if special setting IsSafeFirstMove is true).
        /// If the number of mines is greater than a half of the minefield method places "free cells" and all other cells considered mined.
        /// Then method places information about number of mines in next to mines cells. 
        /// </summary>
        /// <returns>Nothing</returns>
        public void PlaceMinefieldExceptFreeCell(int freeCellRowIndex, int freeCellColumnIndex)
        {
            int minefieldItemsToPlaceCount = MinesCount;
            bool isMined = false;

            if (isMinesCountGreaterFreeCellsCount)
            {
                minefieldItemsToPlaceCount = RowsCount * ColumnsCount - MinesCount;
                isMined = true;
            }

            FillIsMined(isMined);

            if (minefieldItemsToPlaceCount != 0)
            {
                PlaceItems(minefieldItemsToPlaceCount, !isMined, freeCellRowIndex, freeCellColumnIndex);
            }

            if (MinesCount != 0)
            {
                FillNeighborMinesCount();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void FillIsMined(bool value)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    minefield[i, j] = new MinefieldCell();
                    minefield[i, j].isMined = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void PlaceItems(int itemsCount, bool itemValue, int freeCellRowIndex, int freeCellColumnIndex)
        {
            Random randomNumberGenerator = new();

            for (int i = 0; i < itemsCount; i++)
            {
                var (RowIndex, ColumnIndex) = GenerateIndices(randomNumberGenerator, freeCellRowIndex, freeCellColumnIndex);
                minefield[RowIndex, ColumnIndex].isMined = itemValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void FillNeighborMinesCount()
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    minefield[i, j].NeighborMinesCount = GetNeighborMinesCount(i, j);
                }
            }
        }

        /// <summary>
        /// Method generates a pair of random indices, checks the pair was never returned before. Method guarantees that a cell[freeCellRowIndex, freeCellColumnIndex] never has a mine.
        /// </summary>
        /// <returns>A pair of indices as a tuple (int RowIndex, int ColumnIndex)</returns>
        public (int RowIndex, int ColumnIndex) GenerateIndices(Random randomNumberGenerator, int freeCellRowIndex, int freeCellColumnIndex)
        {
            if (settings.IsSafeFirstMove && isMinesCountGreaterFreeCellsCount && minefield[freeCellRowIndex, freeCellColumnIndex].isMined)
            {
                return (freeCellRowIndex, freeCellColumnIndex);
            }

            while (true)
            {
                int rowIndex = randomNumberGenerator.Next(0, RowsCount);
                int columnIndex = randomNumberGenerator.Next(0, ColumnsCount);

                if (isMinesCountGreaterFreeCellsCount != minefield[rowIndex, columnIndex].isMined)
                {
                    continue;
                }

                if (settings.IsSafeFirstMove && (rowIndex == freeCellRowIndex && columnIndex == freeCellColumnIndex))
                {
                    continue;
                }

                return (rowIndex, columnIndex);
            }
        }

        /// <summary>
        /// Cheks if a given cell contains a mine.
        /// </summary>
        /// <returns>True if a cell is mined, else otherwise</returns>
        public bool IsMined(int rowIndex, int columnIndex)
        {
            return minefield[rowIndex, columnIndex].isMined;
        }

        /// <summary>
        /// Determines how many neighbor cells a given cell has: 3, 5 or 8. Then counts mines in neighbor cells.
        /// </summary>
        /// <returns>A number of mines in neighbor cells</returns>
        public int GetNeighborMinesCount(int rowIndex, int columnIndex)
        {
            int startRowIndex = rowIndex - 1 < 0 ? 0 : rowIndex - 1;
            int endRowIndex = rowIndex + 1 > RowsCount - 1 ? RowsCount - 1 : rowIndex + 1;

            int startColumnIndex = columnIndex - 1 < 0 ? 0 : columnIndex - 1;
            int endColumnIndex = columnIndex + 1 > RowsCount - 1 ? RowsCount - 1 : columnIndex + 1;

            int minesCount = 0;

            for (int i = startRowIndex; i <= endRowIndex; i++)
            {
                for (int j = startColumnIndex; j <= endColumnIndex; j++)
                {
                    if (i != rowIndex || j != columnIndex)
                    {
                        if (IsMined(i, j))
                        {
                            minesCount++;
                        }
                    }
                }
            }

            return minesCount;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void ResetGamefield()
        {
            minefield.Initialize();
            isMinefieldPlaced = false;
        }







        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public List<(int RowIndex, int ColumnIndex)> GetNeighborCellsListIfTheyAllFree(int rowIndex, int columnIndex)
        //{
        //    int startRowIndex = rowIndex - 1 < 0 ? 0 : rowIndex - 1;
        //    int endRowIndex = rowIndex + 1 > RowsCount - 1 ? RowsCount - 1 : rowIndex + 1;

        //    int startColumnIndex = columnIndex - 1 < 0 ? 0 : columnIndex - 1;
        //    int endColumnIndex = columnIndex + 1 > RowsCount - 1 ? RowsCount - 1 : columnIndex + 1;

        //    List<(int RowIndex, int ColumnIndex)> list = new();

        //    for (int i = startRowIndex; i <= endRowIndex; i++)
        //    {
        //        for (int j = startColumnIndex; j <= endColumnIndex; j++)
        //        {
        //            if (i != rowIndex || j != columnIndex)
        //            {
        //                if (IsMined(i, j) || minefieldMap.GetValueOrDefault((i, j)) == MinefieldMapCellStatus.FlagMarked)
        //                {
        //                    list.Clear();
        //                    return list;
        //                }

        //                list.Add((i, j));
        //            }
        //        }
        //    }

        //    return list;
        //}

        ///// <summary>
        ///// Returns an enumerator that iterates through ???
        ///// </summary>
        ///// <returns>The sequence of ???</returns>
        //public IEnumerable<(int RowIndex, int ColumnIndex)> NeighborFreeCellsAreaTraversal(int rowIndex, int columnIndex)
        //{
        //    if (IsMined(rowIndex, columnIndex))
        //    {
        //        yield break;
        //    }

        //    List<(int RowIndex, int ColumnIndex)> visitedCellsList = new();

        //    Queue<(int RowIndex, int ColumnIndex)> queue = new();
        //    queue.Enqueue((rowIndex, columnIndex));

        //    while (queue.Count > 0)
        //    {
        //        (int RowIndex, int ColumnIndex) currentCell = queue.Dequeue();

        //        List<(int RowIndex, int ColumnIndex)> neighborFreeCellsList = GetNeighborCellsListIfTheyAllFree(currentCell.RowIndex, currentCell.ColumnIndex);

        //        foreach (var e in neighborFreeCellsList)
        //        {
        //            if (!queue.Contains(e) && !visitedCellsList.Contains(e))
        //            {
        //                queue.Enqueue(e);
        //            }
        //        }

        //        visitedCellsList.Add(currentCell);
        //        yield return currentCell;
        //    }
        //}



        ///// <summary>
        ///// Returns an enumerator that iterates through ???
        ///// </summary>
        ///// <returns>The number of opened free cells</returns>
        //public int OpenCell(int rowIndex, int columnIndex)
        //{
        //    if (!isMinefieldPlaced)
        //    {
        //        PlaceMinefieldExceptFreeCell(rowIndex, columnIndex);
        //        isMinefieldPlaced = true;
        //    }

        //    // if Hidden or QuestionMarked -> open
        //    if (minefieldMap.ContainsKey((rowIndex, columnIndex)) && minefieldMap.GetValueOrDefault((rowIndex, columnIndex)) != MinefieldMapCellStatus.QuestionMarked)
        //    {
        //        return 0;
        //    }

        //    MinefieldMapCellStatus cellStatus;

        //    if (IsMined(rowIndex, columnIndex))
        //    {
        //        cellStatus = MinefieldMapCellStatus.Explosion;
        //        minefieldMap.Add((rowIndex, columnIndex), cellStatus);
        //        //TODO call IsLoss() method
        //        return 0;
        //    }

        //    int openedFreeCellsCount = 0;

        //    foreach (var (RowIndex, ColumnIndex) in NeighborFreeCellsAreaTraversal(rowIndex, columnIndex))
        //    {
        //        cellStatus = GetNeighborMinesCount(RowIndex, ColumnIndex) switch
        //        {
        //            1 => MinefieldMapCellStatus.OneMineNext,
        //            2 => MinefieldMapCellStatus.TwoMinesNext,
        //            3 => MinefieldMapCellStatus.ThreeMinesNext,
        //            4 => MinefieldMapCellStatus.FourMinesNext,
        //            5 => MinefieldMapCellStatus.FiveMinesNext,
        //            6 => MinefieldMapCellStatus.SixMinesNext,
        //            7 => MinefieldMapCellStatus.SevenMinesNext,
        //            8 => MinefieldMapCellStatus.EightMinesNext,
        //            _ => MinefieldMapCellStatus.Free
        //        };

        //        minefieldMap.Add((RowIndex, ColumnIndex), cellStatus);
        //        openedFreeCellsCount++;
        //    }

        //    return openedFreeCellsCount;
        //}

        ///// <summary>
        ///// Returns an enumerator that iterates through ???
        ///// </summary>
        ///// <returns>The sequence of ???</returns>
        //public void MarkCell(int rowIndex, int columnIndex)
        //{
        //    // if Hidden -> Flagmarked
        //    if (!minefieldMap.ContainsKey((rowIndex, columnIndex)))
        //    {
        //        minefieldMap.Add((rowIndex, columnIndex), MinefieldMapCellStatus.FlagMarked);
        //        return;
        //    }

        //    // if Flagmarked -> Hidden / QuestionMarked
        //    if (minefieldMap.GetValueOrDefault((rowIndex, columnIndex)) == MinefieldMapCellStatus.FlagMarked)
        //    {
        //        minefieldMap.Remove((rowIndex, columnIndex));

        //        if (settings.IsQuestionMarkEnabled)
        //        {
        //            minefieldMap.Add((rowIndex, columnIndex), MinefieldMapCellStatus.QuestionMarked);
        //        }

        //        return;
        //    }

        //    // if QuestionMarked -> Hidden
        //    if (minefieldMap.GetValueOrDefault((rowIndex, columnIndex)) == MinefieldMapCellStatus.QuestionMarked)
        //    {
        //        minefieldMap.Remove((rowIndex, columnIndex));
        //    }
        //}

        ///// <summary>
        ///// Returns an enumerator that iterates through ???
        ///// </summary>
        ///// <returns>The sequence of ???</returns>
        //public MinefieldMapCellStatus GetCellStatus(int rowIndex, int columnIndex)
        //{
        //    return minefieldMap.GetValueOrDefault((rowIndex, columnIndex));
        //}

        ///// <summary>
        ///// Returns an enumerator that iterates through ???
        ///// </summary>
        ///// <returns>The sequence of ???</returns>
        //public List<(int RowIndex, int ColumnIndex)> GetNeighborCellsList(int rowIndex, int columnIndex)
        //{
        //    return null;
        //}
    }
}
