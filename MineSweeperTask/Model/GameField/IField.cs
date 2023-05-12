using MinesweeperTask.Model.GameSettings;
using MinesweeperTask.Model.GameStatistics;
using System;
using System.Collections.Generic;

namespace MinesweeperTask.Model.GameField
{
    public interface IField
    {
        void PlaceMinefieldExceptFreeCell(int freeCellRowIndex, int freeCellColumnIndex);

        (int RowIndex, int ColumnIndex) GenerateIndices(Random randomNumberGenerator, int freeCellRowIndex, int freeCellColumnIndex);

        bool IsMined(int rowIndex, int columnIndex);

        int GetNeighborMinesCount(int rowIndex, int columnIndex);

        void ResetGamefield();

        //List<(int RowIndex, int ColumnIndex)> GetNeighborCellsListIfTheyAllFree(int rowIndex, int columnIndex);

        //IEnumerable<(int RowIndex, int ColumnIndex)> NeighborFreeCellsAreaTraversal(int rowIndex, int columnIndex);

        //void SetSettings(Settings settings);

        //void SetStatistics(Statistics statistics);

        //int OpenCell(int rowIndex, int columnIndex);

        //void MarkCell(int rowIndex, int columnIndex);

        //MinefieldMapCellStatus GetCellStatus(int rowIndex, int columnIndex);
    }
}
