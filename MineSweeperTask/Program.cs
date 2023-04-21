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
            Game game = new();


            game.gamefield.OpenCell(0, 0);

            game.gamefield.MarkCell(1, 0);
            game.gamefield.MarkCell(1, 0);
            game.gamefield.MarkCell(1, 0);
            game.gamefield.MarkCell(1, 0);
            game.gamefield.MarkCell(1, 0);
            game.gamefield.MarkCell(1, 0);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }
    }
}
