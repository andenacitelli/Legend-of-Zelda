using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    public class MovingItem : Entity
    {
        // Commit from separate branch; Will probably need to work in:  public Item(BasicSprite sprite)
        public MovingItem(bool moving, bool disappearing, int framesToDraw, Constants.Direction directionThrown)
        {
            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = new Vector2(250, 200);

            BasicSprite a = ItemSpriteFactory.Instance.CreateBomb();
            Sprite sprite = new Sprite(a);
            AddComponent(sprite);

            // Controls the item sprite actually moving across the screen. This isn't input-based movement.
            ItemMovement movement = new ItemMovement(moving, disappearing, framesToDraw, directionThrown);
            AddComponent(movement);
        }


    }
}
