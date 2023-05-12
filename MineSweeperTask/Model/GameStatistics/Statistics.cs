namespace MinesweeperTask.Model.GameStatistics
{
    public class Statistics : IStatistics
    {
        private int gamerMovesCount;

        public int unmarkedMinesCounter;

        public int timeCounter;

        /// <summary>
        /// Returns an enumerator that iterates through ???
        /// </summary>
        /// <returns>The number of opened free cells</returns>
        public void ResetStatistics()
        {

        }
    }
}
