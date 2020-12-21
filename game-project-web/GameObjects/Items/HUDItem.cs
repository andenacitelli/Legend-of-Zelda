using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    public class HUDItem : Entity
    {
        public HUDItem(BasicSprite sprite, Vector2 position, float scalar = 1.0f, bool visible = true)
        {

            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = position;

            Constants.SetLayerDepth(this, Constants.LayerDepth.Debug);

            Sprite spriteComponent = new Sprite(sprite);
            spriteComponent.SetVisible(visible);
            spriteComponent.sprite.scalar *= scalar;
            AddComponent(spriteComponent);
        }

    }
}
