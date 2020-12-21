using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;
using System.Linq;

namespace game_project.GameObjects.GUI
{
    class MapDisplay : BehaviorScript
    {

        public Vector2 startPosition = new Vector2(128, 32);

        public MapTile[,] tiles = new MapTile[8, 8];

        public MapDisplay(Transform parent)
        {
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int col = 0; col < tiles.GetLength(1); col++)
                {
                    int x = row - 1;
                    int y = col - 2;
                    var pos = new Vector2(row, col) * 32 + startPosition;
                    var s = new Sprite(HUDSpriteFactory.Instance.CreateMapYellowSquare());


                    //if (Level.ValidLevels.Contains(x + "_" + y))
                    //{
                    //    s = new Sprite(HUDSpriteFactory.Instance.CreateMapAllDoors());
                    //}

                    MapTile t = new MapTile(s, pos);
                    tiles[row, col] = t;
                    Scene.Add(t);
                    parent.AddChild(t);

                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int col = 0; col < tiles.GetLength(1); col++)
                {
                    int x = row - 1;
                    int y = col - 2;
                    var pos = new Vector2(row, col) * 32 + startPosition;


                    if (LevelManager.cache.Keys.Contains(x + "_" + y))
                    {
                        var s = HUDSpriteFactory.Instance.CreateMapAllDoors();
                        tiles[row, col].GetComponent<Sprite>().sprite = s;
                    }


                }
            }
        }
    }
}
