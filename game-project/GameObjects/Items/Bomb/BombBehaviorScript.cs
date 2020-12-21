using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    class BombBehaviorScript : BehaviorScript
    {
        private float explosionTime = 0;
        public bool IsExploded { get; set; } = false;

        public override void Update(GameTime gameTime)
        {
            // set currentTime upon first call
            if (explosionTime == 0) explosionTime = (float)gameTime.TotalGameTime.TotalMilliseconds + Constants.BOMB_EXPLOSION_TIME_MS;
            // current time
            float time = (float)gameTime.TotalGameTime.TotalMilliseconds;
            // get position
            var transform = entity.GetComponent<Transform>();
            // if exploded
            if (time >= explosionTime)
            {
                Sound.PlaySound(Sound.SoundEffects.Bomb_Blow, entity, !Sound.SOUND_LOOPS);
                IsExploded = true;
                // check collision once
                entity.GetComponent<Sprite>().SetVisible(false);
                Scene.Add(new BombExplosion(LinkItemSpriteFactory.Instance.CreateExplosionFinished(), transform.position));
                Entity.Destroy(entity);
            }
        }
    }
}
