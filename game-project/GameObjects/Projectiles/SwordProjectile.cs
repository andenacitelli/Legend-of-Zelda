using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sounds;
using System;

namespace game_project.GameObjects.Projectiles
{
    class SwordProjectile : Projectile
    {
        public Constants.Direction direction;

        public SwordProjectile(Constants.Direction direction, Entity entity)
        {
            // Starts at Link
            var entityTransform = entity.GetComponent<Transform>();
            this.direction = direction;
            GetComponent<Transform>().position = entityTransform.WorldPosition;
            Sound.PlaySound(Sound.SoundEffects.Sword_Shoot, false);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Item);

            // Sword sprite changes based on direction it was fired 
            Sprite s;
            switch (direction)
            {
                case Constants.Direction.UP:
                    s = new Sprite(LinkItemSpriteFactory.Instance.CreateWhiteBlueSwordUp());
                    break;
                case Constants.Direction.RIGHT:
                    s = new Sprite(LinkItemSpriteFactory.Instance.CreateWhiteBlueSwordRight());
                    break;
                case Constants.Direction.DOWN:
                    s = new Sprite(LinkItemSpriteFactory.Instance.CreateWhiteBlueSwordDown());
                    break;
                case Constants.Direction.LEFT:
                    s = new Sprite(LinkItemSpriteFactory.Instance.CreateWhiteBlueSwordLeft());
                    break;
                default:
                    Console.WriteLine("Unable to get direction of link sword projectile!");
                    return;
            }
            AddComponent(s);
            s.SetAnimate(true);

            // Controls movement of the entity 
            BehaviorScript b = new SwordProjectileMovement(direction);
            AddComponent(b);

            // Covers collision of the entity (in our case, just moves in the direction until it hits an enemy or a wall)
            var coll = new Collider();
            coll.response = new SwordBeamCollisionResponse(this); // Half a heart of damage, we'll say 
            AddComponent(coll);
        }
    }
}
