using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class EnemyHealthManagement : HealthManagement
    {
        // Overall tracker for enemy's health

        public EnemyHealthManagement(int startingHealth)
        {
            this.health = startingHealth;
            immune = false;
        }

        public virtual void Die()
        {
            LevelManager.EnemyKilled();
            Sound.PlaySound(Sound.SoundEffects.Enemy_Die, entity, !Sound.SOUND_LOOPS);
            Entity.Destroy(entity);
            Item.ItemDrop(entity.GetComponent<Transform>().position);
            Scene.Find("link").GetComponent<LinkXPManager>().EnemyKill_XPIncrease();
            // POTENTIAL TO DO: implement star burst if we can find the sprite or end up making it
        }

        public override void Update(GameTime gameTime)
        {
            // Console.WriteLine("Enemy Health: " + health.ToString());
            if (health <= 0)
            {
                Die();
            }

            DamageIndication();
        }
    }
}
