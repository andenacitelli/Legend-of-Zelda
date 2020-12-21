using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace game_project.GameObjects.Items
{
    class BombExplosionBehaviorScript : BehaviorScript
    {
        private double framesToDraw, framesDrawn;
        private static readonly int bombWidth = 8;
        private static readonly int bombHeight = 14;
        private static readonly int fullShift = 8;
        private static readonly int halfShift = 4;

        private readonly Vector2 none = new Vector2(0, 0);
        private readonly Vector2 left = new Vector2(-bombWidth * fullShift, 0);
        private readonly Vector2 right = new Vector2(bombWidth * fullShift, 0);
        private readonly Vector2 bottomLeft = new Vector2(-bombWidth * halfShift, bombHeight * halfShift);
        private readonly Vector2 bottomRight = new Vector2(bombWidth * halfShift, bombHeight * halfShift);
        private readonly Vector2 topLeft = new Vector2(-bombWidth* halfShift, -bombHeight * halfShift);
        private readonly Vector2 topRight = new Vector2(bombWidth * halfShift, -bombHeight * halfShift);

        private readonly List<Vector2> leftExplosionPositions;
        private readonly List<Vector2> rightExplosionPositions;

        private readonly List<Entity> leftExplosions = new List<Entity>();
        private readonly List<Entity> rightExplosions = new List<Entity>();
        private readonly List<Entity> rightHalfExplosions = new List<Entity>();

        public BombExplosionBehaviorScript()
        {
            this.framesToDraw = 0;
            this.framesDrawn = 0;

            leftExplosionPositions = new List<Vector2>
            {
                topLeft,
                right,
                none,
                bottomRight
            };

            rightExplosionPositions = new List<Vector2>
            {
                topRight,
                left,
                none,
                bottomLeft
            };

        }

        // Translate in the direction specified for the specified number of frames, then self-destruct
        public override void Update(GameTime gameTime)
        {
            // position
            Vector2 pos = entity.GetComponent<Transform>().position;
            // intialize some things
            if (framesToDraw == 0)
            {
                framesToDraw = entity.GetComponent<Sprite>().sprite.updatesPerFrame * 3 * 7;
                foreach (Vector2 posAdd in leftExplosionPositions)
                {
                    leftExplosions.Add(createExplosionFull(pos + posAdd));
                }
                foreach (Vector2 posAdd in rightExplosionPositions)
                {
                    rightExplosions.Add(createExplosionFull(pos + posAdd));
                    rightHalfExplosions.Add(createExplosionHalf(pos + posAdd));
                }
            }

            framesDrawn++;
            // explosion sequence
            if ((int) framesDrawn == (int) framesToDraw * (1.0/7))
            {
                ShowExplosions(leftExplosions);
            }
            if ((int) framesDrawn == (int) framesToDraw * (2.0/7))
            {
                HideExplosions(leftExplosions);
                ShowExplosions(rightExplosions);
            }
            if ((int)framesDrawn == (int)framesToDraw * (3.0 / 7))
            {
                HideExplosions(rightExplosions);
                ShowExplosions(leftExplosions);
            }
            if ((int)framesDrawn == (int)framesToDraw * (4.0 / 7))
            {
                HideExplosions(leftExplosions);
                ShowExplosions(rightExplosions);
            }
            if ((int)framesDrawn == (int)framesToDraw * (5.0 / 7))
            {
                HideExplosions(rightExplosions);
                ShowExplosions(leftExplosions);
            }
            if ((int)framesDrawn == (int)framesToDraw * (6.0 / 7))
            {
                HideExplosions(leftExplosions);
                ShowExplosions(rightHalfExplosions);
            }

            if (framesDrawn > framesToDraw)
            {
                DestroyExplosions(leftExplosions);
                DestroyExplosions(rightExplosions);
                DestroyExplosions(rightHalfExplosions);
                Entity.Destroy(entity);
            }
        }

        private Entity createExplosionFinished(Vector2 pos)
        {
            Entity explosion = new Item(LinkItemSpriteFactory.Instance.CreateExplosionFinished(), pos);
            explosion.GetComponent<Sprite>().SetVisible(false);
            Scene.Add(explosion);
            return explosion;
        }
        private Entity createExplosionHalf(Vector2 pos)
        {
            Entity explosion = new Item(LinkItemSpriteFactory.Instance.CreateExplosionHalf(), pos);
            explosion.GetComponent<Sprite>().SetVisible(false);
            Scene.Add(explosion);
            return explosion;
        }
        private Entity createExplosionFull(Vector2 pos)
        {
            Entity explosion = new Item(LinkItemSpriteFactory.Instance.CreateExplosionFull(), pos);
            explosion.GetComponent<Sprite>().SetVisible(false);
            Scene.Add(explosion);
            return explosion;
        }

        private void HideExplosions(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                entity.GetComponent<Sprite>().SetVisible(false);
            }
        }
        private void ShowExplosions(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                entity.GetComponent<Sprite>().SetVisible(true);
            }
        }

        private void DestroyExplosions(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                Entity.Destroy(entity);
            }
        }
    }
}
