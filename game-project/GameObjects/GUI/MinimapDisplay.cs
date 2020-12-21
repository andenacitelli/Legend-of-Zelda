using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace game_project.GameObjects.GUI
{
    class MinimapDisplay : BehaviorScript
    {
        public MapTile[,] tiles = new MapTile[8, 8];
        private HUDItem bossRoom;
        private HUDItem linkPosition;

        // var s = new Sprite(HUDSpriteFactory.Instance.CreateMinimapTile());
        public List<Vector2> MapCoords = new List<Vector2>()
        {
            // second row
            new Vector2(2, 1),
            new Vector2(3, 1),
            // third row
            new Vector2(3, 2),
            new Vector2(5, 2),
            new Vector2(6, 2),
            // fourth row
            new Vector2(1, 3),
            new Vector2(2, 3),
            new Vector2(3, 3),
            new Vector2(4, 3),
            new Vector2(5, 3),
            // fifth row
            new Vector2(2, 4),
            new Vector2(3, 4),
            new Vector2(4, 4),
            // sixth row
            new Vector2(3, 5),
            // seventh row
            new Vector2(2, 6),
            new Vector2(3, 6),
            new Vector2(4, 6),
        };

        public MinimapDisplay(Transform parent)
        {
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int col = 0; col < tiles.GetLength(1); col++)
                {
                    var pos = new Vector2(row * 32, col * 16);

                    var s = new Sprite(HUDSpriteFactory.Instance.CreateMinimapBlack());
                    MapTile t = new MapTile(s, pos);
                    tiles[row, col] = t;
                    Scene.Add(t);
                    parent.AddChild(t);
                }
            }

            // link
            linkPosition = new HUDItem(HUDSpriteFactory.Instance.CreateMapGreenSquare(), new Vector2(0, 0));
            SetLinkPosition();
            Constants.SetLayerDepth(linkPosition, Constants.LayerDepth.Debug);
            Scene.Add(linkPosition);
            parent.AddChild(linkPosition);

            // boss
            bossRoom = new HUDItem(HUDSpriteFactory.Instance.CreateMapBossLocation(), new Vector2(0, 0));
            var bossSprite = bossRoom.GetComponent<Sprite>();
            bossSprite.SetVisible(false);
            bossSprite.SetAnimate(true);
            bossSprite.SetUpdateFrameSpeed(10);
            SetBossPosition();
            Constants.SetLayerDepth(bossRoom, Constants.LayerDepth.Debug);
            Scene.Add(bossRoom);
            parent.AddChild(bossRoom);
        }

        public void MinimapVisible()
        {
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int col = 0; col < tiles.GetLength(1); col++)
                {
                    Vector2 currentRowCol = new Vector2(row, col);

                    if (MapCoords.Contains(currentRowCol))
                    {
                        tiles[row, col].GetComponent<Sprite>().SetSprite(HUDSpriteFactory.Instance.CreateMinimapTile());
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!Game1.inBossRush)
            {
                SetLinkPosition();
            }
        }

        public void BossRoomVisible()
        {
            bossRoom.GetComponent<Sprite>().SetVisible(true);
        }

        private void SetLinkPosition()
        {
            string currentLevel = LevelManager.currentLevelPath;
            var split = currentLevel.Split('_');
            int roomX = Int16.Parse(split[0]);
            int roomY = Int16.Parse(split[1]);

            linkPosition.GetComponent<Transform>().position = new Vector2(((roomX + 1) * 32) + 8, (roomY + 1) * 16);
        }

        private void SetBossPosition()
        {
            int roomX = 5;
            int roomY = 0;

            bossRoom.GetComponent<Transform>().position = new Vector2(((roomX + 1) * 32) + 8, (roomY + 2) * 16);
        }
    }
}
