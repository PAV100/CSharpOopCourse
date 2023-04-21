using System;
using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    internal class Gamefield
    {
        private readonly Dictionary<(int RowIndex, int ColunmIndex), MinefieldMapCellStatus> minefield;

        private readonly bool isMinefieldInverted;

        private bool isMinefieldPlaced;

        private readonly Dictionary<(int RowIndex, int ColunmIndex), MinefieldMapCellStatus> minefieldMap;

        private Settings settings;

        private Statistics statistics;

        public int RowsCount { get; }

        public int ColumnsCount { get; }

        private int MinesCount { get; }

        public Gamefield(int rowsCount, int columnsCount, int minesCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            MinesCount = minesCount;

            isMinefieldInverted = minesCount > rowsCount * columnsCount / 2;

            if (isMinefieldInverted)
            {
                minefield = new(rowsCount * columnsCount - minesCount);
            }
            else
            {
                minefield = new(minesCount);
            }

            //PlaceMines();

            minefieldMap = new();
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void ResetGameField()
        {
            minefield.Clear();
            minefieldMap.Clear();

            isMinefieldPlaced = false;
            //PlaceMines();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void PlaceMineField()
        {
            minefield.Clear();

            int minefieldItemsToPlaceCount = MinesCount;
            MinefieldMapCellStatus minefieldItemToPlace = MinefieldMapCellStatus.Mined;

            if (isMinefieldInverted)
            {
                minefieldItemsToPlaceCount = RowsCount * ColumnsCount - MinesCount;
                minefieldItemToPlace = MinefieldMapCellStatus.Free;
            }

            if (minefieldItemsToPlaceCount == 0)
            {
                return;
            }

            Random randomNumberGenerator = new();

            for (int i = 0; i < minefieldItemsToPlaceCount; i++)
            {
                minefield.Add(GenerateIndices(randomNumberGenerator), minefieldItemToPlace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMined(int rowIndex, int columnIndex)
        {
            return isMinefieldInverted ^ minefield.ContainsKey((rowIndex, columnIndex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AreAllNeighborCellsFree(int rowIndex, int columnIndex)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<(int RowIndex, int ColumnIndex)> GetNeighborCellsListIfTheyAllFree(int rowIndex, int columnIndex)
        {
            int startRowIndex = rowIndex - 1 < 0 ? 0 : rowIndex - 1;
            int endRowIndex = rowIndex + 1 > RowsCount - 1 ? RowsCount - 1 : rowIndex + 1;

            int startColumnIndex = columnIndex - 1 < 0 ? 0 : columnIndex - 1;
            int endColumnIndex = columnIndex + 1 > RowsCount - 1 ? RowsCount - 1 : columnIndex + 1;

            List<(int RowIndex, int ColumnIndex)> list = new();

            for (int i = startRowIndex; i <= endRowIndex; i++)
            {
                for (int j = startColumnIndex; j <= endColumnIndex; j++)
                {
                    if (i != rowIndex || j != columnIndex)
                    {
                        if (IsMined(i, j))
                        {
                            //TODO if FlagMarked
                            list.Clear();
                            return list;
                        }

                        list.Add((i, j));
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        public IEnumerable<(int RowIndex, int ColumnIndex)> NeighborFreeCellsAreaTraversal(int rowIndex, int columnIndex)
        {
            if (IsMined(rowIndex, columnIndex))
            {
                yield break;
            }

            List<(int RowIndex, int ColumnIndex)> visitedCellsList = new();

            Queue<(int RowIndex, int ColumnIndex)> queue = new();
            queue.Enqueue((rowIndex, columnIndex));

            while (queue.Count > 0)
            {
                (int RowIndex, int ColumnIndex) currentCell = queue.Dequeue();

                List<(int RowIndex, int ColumnIndex)> neighborFreeCellsList = GetNeighborCellsListIfTheyAllFree(currentCell.RowIndex, currentCell.ColumnIndex);

                foreach (var e in neighborFreeCellsList)
                {
                    if (!queue.Contains(e) && !visitedCellsList.Contains(e))
                    {
                        queue.Enqueue(e);
                    }
                }

                visitedCellsList.Add(currentCell);
                yield return currentCell;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        private (int RowIndex, int ColunmIndex) GenerateIndices(Random randomNumberGenerator)
        {
            while (true)
            {
                int rowIndex = randomNumberGenerator.Next(0, RowsCount);
                int columnIndex = randomNumberGenerator.Next(0, ColumnsCount);

                if (!minefield.ContainsKey((rowIndex, columnIndex)))
                {
                    return (rowIndex, columnIndex);
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        public void SetSettings(Settings settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        public void SetStatistics(Statistics statistics)
        {
            this.statistics = statistics;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public int OpenCell(int rowIndex, int columnIndex)
        {
            if (!isMinefieldPlaced)
            {
                PlaceMineField();
                isMinefieldPlaced = true;
            }

            // if Hidden or QuestionMarked -> open
            if (minefieldMap.ContainsKey((rowIndex, columnIndex)) && minefieldMap.GetValueOrDefault((rowIndex, columnIndex)) != MinefieldMapCellStatus.QuestionMarked)
            {
                return 0;
            }

            MinefieldMapCellStatus cellStatus;

            if (IsMined(rowIndex, columnIndex))
            {
                cellStatus = MinefieldMapCellStatus.Explosion;
                minefieldMap.Add((rowIndex, columnIndex), cellStatus);
                return 0;
            }

            int openedFreeCellsCount = 0;

            foreach (var (RowIndex, ColumnIndex) in NeighborFreeCellsAreaTraversal(rowIndex, columnIndex))
            {
                cellStatus = GetNeighborMinesCount(RowIndex, ColumnIndex) switch
                {
                    1 => MinefieldMapCellStatus.OneMineNext,
                    2 => MinefieldMapCellStatus.TwoMinesNext,
                    3 => MinefieldMapCellStatus.ThreeMinesNext,
                    4 => MinefieldMapCellStatus.FourMinesNext,
                    5 => MinefieldMapCellStatus.FiveMinesNext,
                    6 => MinefieldMapCellStatus.SixMinesNext,
                    7 => MinefieldMapCellStatus.SevenMinesNext,
                    8 => MinefieldMapCellStatus.EightMinesNext,
                    _ => MinefieldMapCellStatus.Free
                };

                minefieldMap.Add((RowIndex, ColumnIndex), cellStatus);
                openedFreeCellsCount++;
            }

            return openedFreeCellsCount;
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        public void MarkCell(int rowIndex, int columnIndex)
        {
            // if Hidden -> Flagmarked
            if (!minefieldMap.ContainsKey((rowIndex, columnIndex)))
            {
                minefieldMap.Add((rowIndex, columnIndex), MinefieldMapCellStatus.FlagMarked);
                return;
            }

            // if Flagmarked -> Hidden / QuestionMarked
            if (minefieldMap.GetValueOrDefault((rowIndex, columnIndex)) == MinefieldMapCellStatus.FlagMarked)
            {
                minefieldMap.Remove((rowIndex, columnIndex));

                if (settings.IsQuestionMarkEnabled)
                {
                    minefieldMap.Add((rowIndex, columnIndex), MinefieldMapCellStatus.QuestionMarked);
                }

                return;
            }

            // if QuestionMarked -> Hidden
            if (minefieldMap.GetValueOrDefault((rowIndex, columnIndex)) == MinefieldMapCellStatus.QuestionMarked)
            {
                minefieldMap.Remove((rowIndex, columnIndex));
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        public MinefieldMapCellStatus GetCellStatus(int rowIndex, int columnIndex)
        {
            return minefieldMap.GetValueOrDefault((rowIndex, columnIndex));
        }

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The sequence of ???</returns>
        public List<(int RowIndex, int ColumnIndex)> GetNeighborCellsList(int rowIndex, int columnIndex)
        {
            return null;
        }
    }
}
