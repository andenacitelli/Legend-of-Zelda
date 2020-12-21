using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class SpecialItemCollisionResponse : ECS.Components.CollisionResponse
    {
        private Item currentItem;
        private bool done = false;
        public SpecialItemCollisionResponse(Item entity) : base(entity)
        {
            currentItem = entity;
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }


        public override void ResolveCollision(LinkCollisionResponse other)
        {
            if (!done)
            {
                Link link = (Link)other.entity;
                LinkInventory linkInventory = link.GetComponent<LinkInventory>();

                // update item inventory numbers
                switch (currentItem.GetItemType())
                {
                    case "heartContainer":
                        Scene.Find("link").GetComponent<LinkHealthManagement>().health = Constants.LINK_STARTING_HEALTH;
                        Sound.PlaySound(Sound.SoundEffects.Get_Heart, false);
                        break;
                    case "triforce":
                        linkInventory.AddPassiveItem((int)ItemInventory.PassiveIventory.TRIFORCE);
                        // Console.WriteLine("Triforce = " + linkInventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.TRIFORCE));
                        break;
                    default:
                        break;
                }

                // animation for picking up item
                LinkBehavior linkBehavior = link.GetComponent<LinkBehavior>();
                linkBehavior.picking_up_item = true;
                linkBehavior.linkHands = 2;
                Sprite linkSprite = entity.GetComponent<Sprite>();
                int linkSpriteHeight = linkSprite.sprite.frames[linkSprite.sprite.currentFrame].Height;
                int linkSpriteWidth = linkSprite.sprite.frames[linkSprite.sprite.currentFrame].Width;
                Sprite itemSprite = entity.GetComponent<Sprite>();
                int itemSpriteHeight = itemSprite.sprite.frames[itemSprite.sprite.currentFrame].Height;
                int itemSpriteWidth = itemSprite.sprite.frames[itemSprite.sprite.currentFrame].Width;
                Transform linkTrans = link.GetComponent<Transform>();
                linkTrans.position += new Vector2(0, itemSpriteHeight);
                Transform itemPos = entity.GetComponent<Transform>();
                itemPos.position += new Vector2(0, -itemSpriteHeight);
                currentItem.GetComponent<ItemDeletionTimer>().startTimer = true;

                // if triforce we should quit the game? make black screen? credits?
                done = true;
                if (currentItem.GetItemType() == "triforce")
                {
                    LevelManager.Victory();
                }
            }
        }

    }
}
