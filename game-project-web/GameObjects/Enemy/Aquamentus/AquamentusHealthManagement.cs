using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.Content.Sprites.SpriteFactories;
using game_project.CollisionResponse;
using game_project.Sounds;
using game_project.GameObjects.Block;
using game_project.Levels;

namespace game_project.GameObjects.Enemy
{
    class AquamentusHealthManagement : EnemyHealthManagement
    {
        public AquamentusHealthManagement(int startingHealth) : base(startingHealth)
        {
            this.health = startingHealth;
        }

        public override void Die()
        {
            Sound.PlaySound(Sound.SoundEffects.Boss_Scream1, entity, !Sound.SOUND_LOOPS);
            Item heartContainer = new Item(ItemSpriteFactory.Instance.CreateHeartContainer(), entity.GetComponent<Transform>().position);
            heartContainer.AddComponent(new ItemDeletionTimer());
            Collider coll = new Collider
            {
                response = new SpecialItemCollisionResponse(heartContainer)
            };
            heartContainer.AddComponent(coll);
            heartContainer.SetItemType("heartContainer");
            LevelManager.currentLevel.Root.GetComponent<Transform>().AddChild(heartContainer);

            // temp fix to open door when aquamentus dies
            Door door = (Door) Scene.Find("right");
            door.doorType = Door.Type.Open;

            Entity.Destroy(entity);
        }

        // Needs overridden because we play a different sound for Aquamentus
        public override void DeductHealth(int healthToDeduct)
        {
            Sound.PlaySound(Sound.SoundEffects.Boss_Hit, !Sound.SOUND_LOOPS);
            health -= healthToDeduct;
        }
    }
}
