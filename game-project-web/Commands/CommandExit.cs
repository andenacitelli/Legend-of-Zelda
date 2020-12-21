namespace game_project.Commands
{
    class CommandExit : ICommand
    {
        // Game1 has a static instance of itself defined in its constructor
        public void Execute()
        {
            Game1.self.Exit();
        }
    }
}
