using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class SelectedWeaponDisplayManager : BehaviorScript
    {
        private LinkInventory linkInventory;

        public SelectedWeaponDisplayManager()
        {
        }

        public override void Update(GameTime gameTime)
        {
            var sprite = entity.GetComponent<Sprite>();
            linkInventory = Scene.Find("Link").GetComponent<LinkInventory>();
            switch (linkInventory.GetCurrentWeapon())
            {
                case ItemInventory.WeaponTypes.WOODEN_SWORD:
                    sprite.SetSprite(LinkItemSpriteFactory.Instance.CreateWoodenSwordUp());
                    break;
                case ItemInventory.WeaponTypes.MAGIC_SWORD:
                    sprite.SetSprite(LinkItemSpriteFactory.Instance.CreateWhiteRedSwordUp());
                    break;
            }
        }
    }
}
