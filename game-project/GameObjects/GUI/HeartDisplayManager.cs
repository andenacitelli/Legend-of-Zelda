using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Link;
using game_project.Levels;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace game_project.GameObjects.GUI
{
    class HeartDisplayManager : BehaviorScript
    {
        private List<Heart> hearts;
        private Vector2 origin;
        private LinkHealthManagement linkHealth;
        private Backdrop backdrop;
        bool started = false;

        public HeartDisplayManager(List<Heart> hearts, Vector2 origin, Backdrop backdrop)
        {
            this.hearts = hearts;
            this.origin = origin;
            this.backdrop = backdrop;
        }

        public override void Update(GameTime gameTime)
        {
            // Refresh where we get it from every frame instead of how we used to do it, which was just grabbing the reference once at the beginning
            linkHealth = LevelManager.link.GetComponent<LinkHealthManagement>();
            if (!started)
            {
                var bT = backdrop.GetComponent<Transform>();
                for (int i = 0; i < linkHealth.health / Constants.LINK_HEALTH_PER_HEART; i++)
                {
                    var h = new Heart();
                    hearts.Add(h);
                    Scene.Add(h);
                    var t = h.GetComponent<Transform>();
                    t.position += origin;
                    t.position.X += i * 40;
                    bT.AddChild(h);
                }
                started = true;
            }
            else
            {
                float currentHealth = (float)linkHealth.health / (float)Constants.LINK_HEALTH_PER_HEART;

                int halfHearts = (int)(currentHealth * 2f);

                for (int i = 0; i < Constants.LINK_STARTING_HEALTH / Constants.LINK_HEALTH_PER_HEART; i++)
                {
                    // is the current heart whole, half or empty?
                    var h = hearts[i];
                    var s = h.GetComponent<Sprite>();

                    if (i * 2 < halfHearts)
                    {
                        s.SetSprite(ItemSpriteFactory.Instance.CreateHeartFull());
                        if (i * 2 + 1 == halfHearts)
                        {
                            s.SetSprite(ItemSpriteFactory.Instance.CreateHeartHalf());
                        }
                    }
                    else
                    {
                        s.SetSprite(ItemSpriteFactory.Instance.CreateHeartEmpty());

                    }
                }
            }
        }
    }
}
