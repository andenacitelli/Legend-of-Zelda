using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class SelectedItemDisplayManager : BehaviorScript
    {
        private LinkInventory linkInventory;
        private readonly float scale = 1.5f;
        private readonly float boomerang_scale = 1.2f;

        public SelectedItemDisplayManager()
        {
        }

        public override void Update(GameTime gameTime)
        {
            var sprite = entity.GetComponent<Sprite>();
            linkInventory = Scene.Find("Link").GetComponent<LinkInventory>();
            switch (linkInventory.GetBKey())
            {
                case ItemInventory.UseInventory.BOOMERANG:
                    sprite.SetSprite(HUDSpriteFactory.Instance.CreateBoomerang());
                    sprite.sprite.scalar *= Constants.HUD_BOOMERANG_SCALE * boomerang_scale;
                    break;
                case ItemInventory.UseInventory.BOMB:
                    sprite.SetSprite(HUDSpriteFactory.Instance.CreateBomb());
                    sprite.sprite.scalar *= Constants.HUD_BOMB_SCALE * scale;
                    break;
                case ItemInventory.UseInventory.BOW:
                    sprite.SetSprite(HUDSpriteFactory.Instance.CreateBow());
                    sprite.sprite.scalar *= Constants.HUD_BOW_SCALE * scale;
                    break;
            }
        }
    }
}
