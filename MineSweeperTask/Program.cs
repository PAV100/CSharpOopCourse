using MinesweeperTask.Model;
using System;
using System.Windows.Forms;

namespace MinesweeperTask
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GameModel gameModel = new();


            gameModel.gamefield.OpenCell(0, 0);

            gameModel.gamefield.MarkCell(1, 0);
            gameModel.gamefield.MarkCell(1, 0);
            gameModel.gamefield.MarkCell(1, 0);
            gameModel.gamefield.MarkCell(1, 0);
            gameModel.gamefield.MarkCell(1, 0);
            gameModel.gamefield.MarkCell(1, 0);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }
    }
}
