using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.GUI;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class FirstItemCollisionResponse : ECS.Components.CollisionResponse
    {
        private Item currentItem;
        public FirstItemCollisionResponse(Item entity) : base(entity)
        {
            currentItem = entity;
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(LinkCollisionResponse other)
        {
            Link link = (Link)other.entity;
            LinkInventory linkInventory = link.GetComponent<LinkInventory>();

            // update item inventory numbers
            switch (currentItem.GetItemType())
            {
                case "bow":
                    linkInventory.AddUseableItem((int)ItemInventory.UseInventory.BOW);
                    // Console.WriteLine("Bow = " + linkInventory.GetUseableItemCount((int)ItemInventory.UseInventory.BOW));
                    LevelManager.backdrop.Bow.GetComponent<Sprite>().SetVisible(true);
                    break;
                case "raft":
                    linkInventory.AddPassiveItem((int)ItemInventory.PassiveIventory.RAFT);
                    // Console.WriteLine("Raft = " + linkInventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.RAFT));
                    break;
                case "ladder":
                    linkInventory.AddPassiveItem((int)ItemInventory.PassiveIventory.LADDER);
                    // Console.WriteLine("Ladder = " + linkInventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.LADDER));
                    break;
                case "powerBand":
                    linkInventory.AddPassiveItem((int)ItemInventory.PassiveIventory.POWER_BAND);
                    // Console.WriteLine("Power Band = " + linkInventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.POWER_BAND));
                    break;
                default:
                    break;
            }

            Sprite itemSprite = entity.GetComponent<Sprite>();
            int itemSpriteWidth = itemSprite.sprite.frames[itemSprite.sprite.currentFrame].Width;
            LinkBehavior linkBehavior = link.GetComponent<LinkBehavior>();
            linkBehavior.picking_up_item = true;
            linkBehavior.linkHands = 1;
            Transform linkTrans = link.GetComponent<Transform>();
            linkTrans.position += new Vector2(-itemSpriteWidth / 2, 0);
            Sprite linkSprite = link.GetComponent<Sprite>();
            int linkSpriteHeight = linkSprite.sprite.frames[linkSprite.sprite.currentFrame].Height;
            entity.GetComponent<Transform>().position += new Vector2(0, -linkSpriteHeight);
            entity.GetComponent<ItemDeletionTimer>().startTimer = true;

        }

    }
}
