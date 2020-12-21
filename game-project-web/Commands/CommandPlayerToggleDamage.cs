using game_project.Commands;
using game_project.GameObjects.Link;

namespace game_project.Controllers
{
    internal class CommandPlayerToggleDamage : ICommand
    {
        public void Execute()
        {
            // white, green, red, blue
            //var statePattern = Game1.link.GetComponent<LinkStatePattern>();
            //statePattern.damageState = new LinkDamaged(statePattern);
        }
    }
}