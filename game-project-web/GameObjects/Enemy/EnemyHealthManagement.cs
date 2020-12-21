using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class EnemyHealthManagement : BehaviorScript
    {
        // Overall tracker for enemy's health
        public int health;

        public EnemyHealthManagement(int startingHealth)
        {
            this.health = startingHealth;
        }

        public virtual void DeductHealth(int healthToDeduct)
        {
            // Console.WriteLine("Deducting " + healthToDeduct.ToString() + " from Enemy.");
            health -= healthToDeduct;
        }

        public virtual void Die()
        {
            Sound.PlaySound(Sound.SoundEffects.Enemy_Die, entity, !Sound.SOUND_LOOPS);
            Entity.Destroy(entity);

            // POTENTIAL TO DO: implement star burst if we can find the sprite or end up making it
        }

        public override void Update(GameTime gameTime)
        {
            // Console.WriteLine("Enemy Health: " + health.ToString());
            if (health <= 0)
            {
                Die();
            }
        }
    }
}
