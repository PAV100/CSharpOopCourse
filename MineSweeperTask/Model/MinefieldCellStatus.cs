namespace MinesweeperTask.Model
{
    internal enum MinefieldCellStatus
    {
        Free = 0,
        OneMineNext = 1,
        TwoMinesNext = 2,
        ThreeMinesNext = 3,
        FourMinesNext = 4,
        FiveMinesNext = 5,
        SixMinesNext = 6,
        SevenMinesNext = 7,
        EightMinesNext = 8,
        Mined = 9
    }
}
