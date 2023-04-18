namespace MinesweeperTask.Model
{
    internal class MinefieldMapCell
    {
        public MinefieldMapCellStatus Status { get; private set; }

        MinefieldMapCell(MinefieldMapCellStatus status)
        {
            Status = status;
        }
    }
}
