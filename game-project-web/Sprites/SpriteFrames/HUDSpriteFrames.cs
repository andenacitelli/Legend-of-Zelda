using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace game_project.Content.Sprites
{
    class HUDSpriteFrames
    {
        public Dictionary<string, Rectangle> frames;
        public HUDSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // useable items
            frames.Add("HUDRupee", new Rectangle(346, 27, 8, 8));
            frames.Add("HUDKey", new Rectangle(346, 43, 8, 8));
            frames.Add("HUDBomb", new Rectangle(346, 51, 8, 8));
            frames.Add("Boomerang", new Rectangle(585, 141, 5, 8));
            frames.Add("Bomb", new Rectangle(604, 137, 8, 14));
            frames.Add("Bow", new Rectangle(633, 137, 8, 16));

            // dungeon items
            frames.Add("MapItem", new Rectangle(601, 156, 8, 16));
            frames.Add("CompassItem", new Rectangle(612, 156, 15, 16));

            // map pieces
            frames.Add("Closed", new Rectangle(519, 108, 8, 8));
            frames.Add("RightDoor", new Rectangle(528, 108, 8, 8));
            frames.Add("LeftDoor", new Rectangle(537, 108, 8, 8));
            frames.Add("LeftRightDoor", new Rectangle(546, 108, 8, 8));
            frames.Add("DownDoor", new Rectangle(555, 108, 8, 8));
            frames.Add("DownRightDoor", new Rectangle(564, 108, 8, 8));
            frames.Add("DownLeftDoor", new Rectangle(573, 108, 8, 8));
            frames.Add("DownLeftRightDoor", new Rectangle(582, 108, 8, 8));
            frames.Add("TopDoor", new Rectangle(591, 108, 8, 8));
            frames.Add("TopRightDoor", new Rectangle(600, 108, 8, 8));
            frames.Add("TopLeftDoor", new Rectangle(609, 108, 8, 8));
            frames.Add("TopLeftRightDoor", new Rectangle(618, 108, 8, 8));
            frames.Add("TopDownDoor", new Rectangle(627, 108, 8, 8));
            frames.Add("TopDownRightDoor", new Rectangle(636, 108, 8, 8));
            frames.Add("TopDownLeftDoor", new Rectangle(645, 108, 8, 8));
            frames.Add("AllDoors", new Rectangle(654, 108, 8, 8));

            // map frame
            frames.Add("Map", new Rectangle(354, 112, 128, 80));
            frames.Add("MapYellowSquare", new Rectangle(369, 157, 8, 8));

            // squares
            frames.Add("GreenSquare", new Rectangle(519, 126, 3, 3));
            frames.Add("WhiteSquare", new Rectangle(528, 126, 3, 3));
            frames.Add("RedSquare", new Rectangle(537, 126, 3, 3));
            frames.Add("BlueSquare", new Rectangle(546, 126, 3, 3));
            frames.Add("NavySquare", new Rectangle(555, 126, 3, 3));

            // minimap
            frames.Add("MinimapLayout", new Rectangle(687, 58, 63, 31));
            frames.Add("MinimapTile", new Rectangle(681, 108, 8, 4));
            frames.Add("MinimapBlack", new Rectangle(672, 108, 8, 4));
            frames.Add("MinimapTileTop", new Rectangle(663, 108, 8, 8));
            frames.Add("MinimapTileBottom", new Rectangle(672, 108, 8, 8));
            frames.Add("MinimapTileBoth", new Rectangle(681, 108, 8, 8));
        }
    }
}
