namespace MinesweeperTask.Model.GameField
{
    public class MinefieldCell
    {
        public bool isMined { get; set; }

        public int NeighborMinesCount { get; set; }

        public MinefieldCellStatus Status { get; set; }

        public void Mark(bool IsQuestionMarkEnabled)
        {
            if (Status == MinefieldCellStatus.Hidden)
            {
                Status = MinefieldCellStatus.FlagMarked;
                return;
            }

            if (Status == MinefieldCellStatus.FlagMarked)
            {
                if (IsQuestionMarkEnabled)
                {
                    Status = MinefieldCellStatus.QuestionMarked;
                    return;
                }

                Status = MinefieldCellStatus.Hidden;
                return;
            }

            if (Status == MinefieldCellStatus.QuestionMarked)
            {
                Status = MinefieldCellStatus.Hidden;
            }
        }

        public void Open()
        {
            if (Status == MinefieldCellStatus.Hidden || Status == MinefieldCellStatus.QuestionMarked)
            {
                Status = MinefieldCellStatus.Opened;
            }
        }
    }
}
