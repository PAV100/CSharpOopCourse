namespace MinesweeperTask.Model.GameField
{
    public enum MinefieldMapCellStatus
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
        Mined = 9,
        Hidden = 10,
        Opened = 11,
        FlagMarked = 10,
        QuestionMarked = 11,        
        MistakenlyFlagMarkedAsMined = 13,
        Explosion = 14
    }
}
