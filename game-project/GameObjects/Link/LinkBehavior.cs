using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Projectiles;
using game_project.Levels;
using game_project.Sounds;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static game_project.Controllers.Input;

namespace game_project.GameObjects.Link
{
    class LinkBehavior : BehaviorScript
    {
        // Protected = Visible to this class and anything inheriting from it
        // sprites
        protected BasicSprite LinkMoveLeft = LinkSpriteFactory.Instance.CreateLinkWalkingLeft();
        protected BasicSprite LinkMoveRight = LinkSpriteFactory.Instance.CreateLinkWalkingRight();
        protected BasicSprite LinkMoveUp = LinkSpriteFactory.Instance.CreateLinkWalkingUp();
        protected BasicSprite LinkMoveDown = LinkSpriteFactory.Instance.CreateLinkWalkingDown();

        protected BasicSprite LinkItemLeft = LinkSpriteFactory.Instance.CreateLinkUseItemLeft();
        protected BasicSprite LinkItemRight = LinkSpriteFactory.Instance.CreateLinkUseItemRight();
        protected BasicSprite LinkItemUp = LinkSpriteFactory.Instance.CreateLinkUseItemUp();
        protected BasicSprite LinkItemDown = LinkSpriteFactory.Instance.CreateLinkUseItemDown();

        protected BasicSprite LinkSwordLeft = LinkSpriteFactory.Instance.CreateLinkWoodenSwordLeft();
        protected BasicSprite LinkSwordRight = LinkSpriteFactory.Instance.CreateLinkWoodenSwordRight();
        protected BasicSprite LinkSwordUp = LinkSpriteFactory.Instance.CreateLinkWoodenSwordUp();
        protected BasicSprite LinkSwordDown = LinkSpriteFactory.Instance.CreateLinkWoodenSwordDown();

        protected BasicSprite LinkPickUpOneHand = LinkSpriteFactory.Instance.CreateLinkPickUpItemOneHand();
        protected BasicSprite LinkPickUpTwoHands = LinkSpriteFactory.Instance.CreateLinkPickUpItemTwoHands();

        // fields / properties
        public static Constants.Direction linkDirection;
        public bool attacking = false;
        public bool damaged = false;
        private bool keyPressed = false;
        private int attack_frame = 0;
        // item pickup
        public int linkHands = 1;
        public bool picking_up_item = false;
        private float picking_up_time = 0;

        // bomb / item usage
        public Vector2 BombAdd { get; set; }

        readonly HashSet<Inputs> inputs = new HashSet<Inputs>();
        public static Constants.Direction oldLinkDirection;

        private readonly Sword sword;
        private readonly WideLink wideLink;

        public LinkBehavior(Sword sword, WideLink wideLink)
        {
            linkDirection = Constants.Direction.UP;
            this.sword = sword;
            this.wideLink = wideLink;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite sprite = entity.GetComponent<Sprite>();
            Collider collider = entity.GetComponent<Collider>();
            Transform transform = entity.GetComponent<Transform>();
            LinkInventory linkInventory = entity.GetComponent<LinkInventory>();
            BasicSprite linkSprite = sprite.sprite;
            float speed = Constants.LINK_MOVEMENT_SPEED;
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // set initial bomb to up
            if (BombAdd.X == 0 && BombAdd.Y == 0)
            {
                BombAdd = new Vector2(0, -linkSprite.frames[linkSprite.currentFrame].Height * linkSprite.scalar);
                linkInventory.SetBombPos(BombAdd);

            }

            // Movement handling
            inputs.Clear();

            if (!GameStateManager.Transition)
            {
                if (Down(Inputs.LEFT))
                {
                    inputs.Add(Inputs.LEFT);
                }
                if (Down(Inputs.RIGHT))
                {
                    inputs.Add(Inputs.RIGHT);
                }
                if (Down(Inputs.UP))
                {
                    inputs.Add(Inputs.UP);
                }
                if (Down(Inputs.DOWN))
                {
                    inputs.Add(Inputs.DOWN);
                }
            }

            //var wideLinkColl = wideLink.GetComponent<Collider>();

            //print(wideLinkColl.CollidingWithRigid);
            //// If Link can move up/down, remove left/right inputs
            //if (wideLinkColl.CollidingWithRigid)
            //{
            //    if (
            //        (inputs.Contains(Inputs.LEFT) || inputs.Contains(Inputs.RIGHT)) &&
            //        (inputs.Contains(Inputs.UP) || inputs.Contains(Inputs.DOWN))
            //        )
            //    {
            //        switch (linkDirection)
            //        {
            //            case Constants.Direction.DOWN:
            //            case Constants.Direction.UP:
            //                inputs.Remove(Inputs.UP);
            //                inputs.Remove(Inputs.DOWN);
            //                break;
            //            case Constants.Direction.LEFT:
            //            case Constants.Direction.RIGHT:
            //                inputs.Remove(Inputs.RIGHT);
            //                inputs.Remove(Inputs.LEFT);
            //                break;
            //        }
            //    }
            //    //if (inputs.Contains(Inputs.LEFT) || inputs.Contains(Inputs.RIGHT))
            //    //{

            //    //    inputs.Remove(Inputs.LEFT);
            //    //    inputs.Remove(Inputs.RIGHT);
            //    //}

            //    //inputs.Remove(Inputs.UP);
            //    //inputs.Remove(Inputs.DOWN);
            //}

            // Else if Link cannot move up/down, remove up/down inputs and go left/right


            //print(inputs.Count);

            // Override left/right movements
            if (inputs.Contains(Inputs.DOWN) || inputs.Contains(Inputs.UP))
            {
                inputs.Remove(Inputs.LEFT);
                inputs.Remove(Inputs.RIGHT);
            }


            // Apply transformation based on remaining directions in set
            if (inputs.Contains(Inputs.RIGHT))
            {
                linkDirection = Constants.Direction.RIGHT;
                transform.position.X += delta * speed;
            }
            if (inputs.Contains(Inputs.LEFT))
            {
                linkDirection = Constants.Direction.LEFT;
                transform.position.X -= delta * speed;
            }
            if (inputs.Contains(Inputs.UP))
            {
                linkDirection = Constants.Direction.UP;
                transform.position.Y -= delta * speed;
            }
            if (inputs.Contains(Inputs.DOWN))
            {
                linkDirection = Constants.Direction.DOWN;
                transform.position.Y += delta * speed;
            }

            //print("{" + string.Join(", ", inputs) + "}, " + linkDirection);
            //print(linkDirection);

            // Set Link's sprite
            if (linkDirection != oldLinkDirection)
            {
                sprite.SetAnimate(true);
                switch (linkDirection)
                {
                    case Constants.Direction.UP:
                        sprite.SetSprite(LinkMoveUp);
                        BombAdd = new Vector2(0, -linkSprite.frames[linkSprite.currentFrame].Height * linkSprite.scalar);
                        break;
                    case Constants.Direction.DOWN:
                        sprite.SetSprite(LinkMoveDown);
                        BombAdd = new Vector2(0, linkSprite.frames[linkSprite.currentFrame].Height * linkSprite.scalar);
                        break;
                    case Constants.Direction.LEFT:
                        sprite.SetSprite(LinkMoveLeft);
                        BombAdd = new Vector2(-linkSprite.frames[linkSprite.currentFrame].Width * linkSprite.scalar, 0);
                        break;
                    case Constants.Direction.RIGHT:
                        sprite.SetSprite(LinkMoveRight);
                        BombAdd = new Vector2(linkSprite.frames[linkSprite.currentFrame].Width * linkSprite.scalar, 0);
                        break;
                }
                linkInventory.SetBombPos(BombAdd);
            }
            // Link should animate when walking the same direction
            sprite.AnimateIfNotAnimating();

            oldLinkDirection = linkDirection;

            if (inputs.Count == 0)
            {
                sprite.SetAnimate(false);
            }

            // Attack handling
            var swordTransform = sword.GetComponent<Transform>();

            if (Down(Inputs.ATTACK) || attacking)
            {
                //Shoot sword. Only happens first time.
                // Cleaner to do it here than inside the next switch statement.Way better readability(imo) and roughly equivalent performance
                if (entity.GetComponent<LinkHealthManagement>().health == Constants.LINK_STARTING_HEALTH)
                {
                    if (!attacking)
                    {
                        ShootSword(linkDirection);
                    }
                }

                attacking = true;

                Sound.PlaySound(Sound.SoundEffects.Sword_Slash, entity, !Sound.SOUND_LOOPS);
                sprite.SetAnimate(true);


                sword.State = Levels.EntityStates.Playing;
                switch (linkDirection)
                {
                    case Constants.Direction.UP:
                        sprite.SetSprite(LinkSwordUp);
                        swordTransform.position = sword.Up;
                        break;
                    case Constants.Direction.DOWN:
                        sprite.SetSprite(LinkSwordDown);
                        swordTransform.position = sword.Down;
                        break;
                    case Constants.Direction.LEFT:
                        sprite.SetSprite(LinkSwordLeft);
                        swordTransform.position = sword.Left;
                        break;
                    case Constants.Direction.RIGHT:
                        sprite.SetSprite(LinkSwordRight);
                        swordTransform.position = sword.Right;
                        break;
                }



                if (++attack_frame == Constants.LINK_ATTACK_FRAMES + 1)
                //if (++attack_frame == 300)
                {
                    attacking = false;
                    attack_frame = 0;
                }
            }
            else
            {
                sword.State = Levels.EntityStates.Disabled;
                swordTransform.position = sword.Home;
            }


            if (Down(Inputs.B_ITEM))
            {
                linkInventory.LinkUseBItem();
            }
            else if (Down(Inputs.BOMB)) // DELETE THIS // DELETE THIS // TESTING ONLY
            {
                if (linkInventory.useInventory[(int)ItemInventory.UseInventory.BOMB].amount.current > 0)
                {
                    Sound.PlaySound(Sound.SoundEffects.Bomb_Drop, entity, !Sound.SOUND_LOOPS); // No way to tell if it's a bomb from item class, so we play it from here
                    Item bomb = new Item(ItemSpriteFactory.Instance.CreateBomb(), transform.WorldPosition + BombAdd);
                    bomb.AddComponent(new BombBehaviorScript());
                    Scene.Add(bomb);
                    linkInventory.useInventory[(int)ItemInventory.UseInventory.BOMB].amount.AddCurrent(-1);

                    // Console.WriteLine("Bomb Amount = " + inventory.useInventory[(int)LinkInventory.UseInventory.BOMB].amount);
                }
            }

            // ToDo: Handle picking up items
            if (picking_up_item)
            {
                picking_up_time += delta;
                transform.position = transform.lastPosition;
                entity.GetComponent<LinkHealthManagement>().immune = true;
                switch (linkHands)
                {
                    case 1:
                        sprite.SetSprite(LinkPickUpOneHand);
                        sprite.SetAnimate(true);
                        break;
                    case 2:
                        sprite.SetSprite(LinkPickUpTwoHands);
                        sprite.SetAnimate(true);
                        break;
                }
                if (picking_up_time >= Constants.LINK_PICKUP_TIME_MS)
                {
                    picking_up_item = false;
                    picking_up_time = 0;
                    entity.GetComponent<LinkHealthManagement>().immune = false;
                }
            }
        }

        private void ShootSword(Constants.Direction direction)
        {
            SwordProjectile swordProjectile = new SwordProjectile(direction, entity);
            Scene.Add(swordProjectile);
        }
    }
}
