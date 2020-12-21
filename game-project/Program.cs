using System;

namespace game_project
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        // Static so we can refer to it from CommandReset()
        public static bool shouldReset;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            do
            {
                shouldReset = false;
                using (var game = new Game1())
                    game.Run();
            } while (shouldReset);
        }
    }
}
