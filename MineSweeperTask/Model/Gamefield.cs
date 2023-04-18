using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    internal class Gamefield
    {
        private Dictionary<(int colunmIndex, int rowIndex), MinefieldCell> minefield;

        private Dictionary<(int colunmIndex, int rowIndex), MinefieldMapCell> minefieldMap;

        public GameLevel gameLevel;

        public int unmarkedMinesCounter;

        public int timeCounter;



        Gamefield()
        {

        }
    }
}
