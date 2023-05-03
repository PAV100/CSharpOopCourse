namespace MinesweeperTask.Model
{
    internal class MinefieldCell
    {
        public bool Mined { get; set; }

        public int MinesInNeighborCellsCount { get; set; }

        public MinefieldMapCellStatus Status { get; set; }

        public MinefieldMapCellStatus NextMark()
        {
            return Status;
        }

        public MinefieldMapCellStatus Open()
        {
            return Status;
        }
    }
}
