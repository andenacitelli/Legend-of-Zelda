using System;
using System.Collections.Generic;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Projectiles;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class AquamentusAttack : BehaviorScript
    {
        float msBetweenShots = 2000;
        float ms = 0;
        public float angle = 10f;
        List<Fireball> fireballs = new List<Fireball>();
        protected BasicSprite RoamSprite = BossSpriteFactory.Instance.CreateAquamentus();
        protected BasicSprite AttackSprite = BossSpriteFactory.Instance.CreateAquamentusAttack();

        public AquamentusAttack()
        {
        }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            ms += delta;

            if (ms > Constants.AQUAMENTUS_TIME_TO_START_ROAM_MS)
            {
                entity.GetComponent<Sprite>().SetSprite(RoamSprite);
                entity.GetComponent<Sprite>().SetUpdateFrameSpeed(25);
            }

            if (ms > Constants.AQUAMENTUS_TIME_BETWEEN_SHOTS_MS - Constants.AQUAMENTUS_ATTACK_WINDOUP_TIME_MS)
            {
                entity.GetComponent<Sprite>().SetSprite(AttackSprite);
                entity.GetComponent<Sprite>().SetUpdateFrameSpeed(25);
            }

            if (ms > Constants.AQUAMENTUS_TIME_BETWEEN_SHOTS_MS)
            {
                ms = 0;
                Fire();
            }
        }

        private void Fire()
        {
            // Get Link, Aquamentus position and figure out angle between them 
            Vector2 linkPos = Scene.Find("Link").GetComponent<Transform>().WorldPosition;
            Vector2 aquamentusPos = entity.GetComponent<Transform>().position;
            float angle = (float) Math.Atan2(linkPos.Y - aquamentusPos.Y, linkPos.X- aquamentusPos.X);

            var pos = entity.GetComponent<Transform>().position;
            var fireball0 = new Fireball(pos, (angle - Constants.AQUAMENTUS_FIREBALL_ANGLE_RADS) % (2 * (float)Math.PI)); // Google says this works right... so let's trust google
            var fireball1 = new Fireball(pos, angle % (2 * (float)Math.PI));
            var fireball2 = new Fireball(pos, (angle + Constants.AQUAMENTUS_FIREBALL_ANGLE_RADS) % (2 * (float)Math.PI));

            fireballs.Add(fireball0);
            fireballs.Add(fireball1);
            fireballs.Add(fireball2);
        }
    }
}
