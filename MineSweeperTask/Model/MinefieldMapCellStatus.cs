namespace MinesweeperTask.Model
{
    internal enum MinefieldMapCellStatus
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
        FlagMarked = 9,
        QuestionMarked = 10,
        Hidden = 11,
        Mined = 12,
        MistakenlyFlagMarkedAsMined = 13,
        Explosion = 14
    }
}
