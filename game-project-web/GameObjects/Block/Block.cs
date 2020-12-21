using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Block
{
    public class Block : Entity
    {

        public Block(BasicSprite sprite, Vector2 position)
        {
            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = position;
            Constants.SetLayerDepth(this, Constants.LayerDepth.Block);

            Sprite s = new Sprite(sprite);
            AddComponent(s);

            var coll = new Collider();
            AddComponent(coll);
            coll.response = new BaseCollisionResponse(this);

        }

    }
}
