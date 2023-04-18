namespace MinesweeperTask.Model
{
    internal class MinefieldCell
    {
        public MinefieldCellStatus Status { get; private set; }

        MinefieldCell(MinefieldCellStatus status)
        {
            Status = status;
        }
    }
}
