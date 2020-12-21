using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.GameObjects.Items
{
    public class NPC : Entity
    {

        public NPC(BasicSprite givenSprite, Vector2 pos)
        {
            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = pos;
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            Sprite sprite = new Sprite(givenSprite);
            AddComponent(sprite);

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
