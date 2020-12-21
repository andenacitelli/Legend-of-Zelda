using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Layout;
using game_project.Levels;
using Microsoft.Xna.Framework;
using System;

namespace game_project.CollisionResponse
{
    public class StairsCollisionResponse : ECS.Components.CollisionResponse
    {
        private string nextRoomPath;
        private Vector2 startPos;
        public StairsCollisionResponse(Entity entity, string nextRoom) : base(entity)
        {
            nextRoomPath = nextRoom;
            switch (nextRoom)
            {
                case "0_0":
                    startPos = Constants.pos0_0;
                    break;
                case "1_0":
                    startPos = Constants.pos1_0;
                    break;
            }
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(LinkCollisionResponse other)
        {
            LevelManager.Load(nextRoomPath);

            LevelManager.mapRoot.GetComponent<Transform>().position = -1 * LevelManager.currentLevel.Root.GetComponent<Transform>().position;
            LevelManager.mapRoot.GetComponent<Transform>().position.Y += Level.screen_height;
            // "other" here should be Link
            other.entity.GetComponent<Transform>().position = LevelManager.currentLevel.Root.GetComponent<Transform>().position + startPos;
        }

    }
}
