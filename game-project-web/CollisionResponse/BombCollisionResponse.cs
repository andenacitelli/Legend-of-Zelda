using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Block;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Sounds;

namespace game_project.CollisionResponse
{
    public class BombCollisionResponse : ECS.Components.CollisionResponse
    {
        bool EnemyCollided;
        public BombCollisionResponse(Entity entity) : base(entity)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(DoorCollisionResponse other)
        {
            // if door is bombable, switch sprite to bombed hole and change collision response to door collision repsonse. 
            Door door = (Door)other.entity;
            if (door.doorType == Door.Type.BombWall)
            {
                switch (door.name)
                {
                    case "up":
                        door.GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateTopHole());
                        break;
                    case "down":
                        door.GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateDownHole());
                        break;
                    case "left":
                        door.GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateLeftHole());
                        break;
                    case "right":
                        door.GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateRightHole());
                        break;
                }
                door.doorType = Door.Type.Open;
            }
        }

        public override void ResolveCollision(EnemyCollisionResponse other)
        {
            if (!EnemyCollided)
            {
                Enemy enemy = (Enemy)other.entity;

                Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, entity, !Sound.SOUND_LOOPS);
                // take damage
                if (enemy.GetType().Equals(typeof(Stalfo)))
                {
                    enemy.GetComponent<StalfoHealthManagement>().DeductHealth(Constants.BOMB_DAMAGE);
                }
                else if (enemy.GetType().Equals(typeof(Aquamentus)))
                {
                    enemy.GetComponent<AquamentusHealthManagement>().DeductHealth(Constants.BOMB_DAMAGE);
                }
                else
                {
                    enemy.GetComponent<EnemyHealthManagement>().DeductHealth(Constants.BOMB_DAMAGE);
                }
                EnemyCollided = true;
            }
        }

    }
}
