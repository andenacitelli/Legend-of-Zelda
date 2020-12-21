using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Link
{
    class LinkHealthManagement : BehaviorScript
    {
        // Overall tracker for Link's health (in half-hearts to avoid floating point weirdness)
        // ToDo: this ain't true anymore
        public int health;

        // Changed to true by the state pattern whenever
        public bool immune;

        public LinkHealthManagement()
        {
            this.health = Constants.LINK_STARTING_HEALTH;
            this.immune = false;
        }

        public void DeductHealth(int healthToDeduct)
        {
            if (!immune)
            {
                // Console.WriteLine("Deducting " + healthToDeduct.ToString() + " from Link.");
                health -= healthToDeduct;
                //immune = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Start up low health loop if he is below a certain threshold.
            // Note that, even if this is checked every frame, it's fast due to being all dictionary-based lookup and doesn't result in multiple effects playing due to how the sound system works.
            if (health <= Constants.LINK_LOW_HEALTH_THRESHOLD)
            {
                Sound.PlaySound(Sound.SoundEffects.LowHealth, entity, Sound.SOUND_LOOPS);
            }

            // Otherwise, stop the low health sound effect.
            // Note that, even if this is checked every frame, it's fast due to being all dictionary-based lookup and doesn't result in multiple effects playing due to how the sound system works.
            else
            {
                Sound.StopSound(Sound.SoundEffects.LowHealth, entity);
            }

            // Console.WriteLine("Link Health: " + health.ToString());
            if (health <= 0)
            {
                Sound.StopSound(Sound.SoundEffects.LowHealth, entity);
                Sound.PlaySound(Sound.SoundEffects.Link_Die, entity, !Sound.SOUND_LOOPS);
                Entity.Destroy(entity);
                LevelManager.Defeat();
            }
        }

    }
}
