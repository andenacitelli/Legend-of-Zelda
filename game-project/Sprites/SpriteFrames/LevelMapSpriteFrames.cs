using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace game_project.Content.Sprites
{
    class LevelMapSpriteFrames
    {

        public Dictionary<string, Rectangle> frames;
        public LevelMapSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();
            // exterior
            frames.Add("Exterior", new Rectangle(521, 11, 256, 176));
            // doors
            /// top
            frames.Add("TopWall", new Rectangle(815, 11, 32, 32));
            frames.Add("TopOpen", new Rectangle(848, 11, 32, 32));
            frames.Add("TopOpenHalf", new Rectangle(848, 11, 32, 16));
            frames.Add("TopLock", new Rectangle(881, 11, 32, 32));
            frames.Add("TopBoss", new Rectangle(914, 11, 32, 32));
            frames.Add("TopHole", new Rectangle(947, 11, 32, 32));
            frames.Add("TopHoleHalf", new Rectangle(947, 11, 32, 16));
            /// left
            frames.Add("LeftWall", new Rectangle(815, 44, 32, 32));
            frames.Add("LeftOpen", new Rectangle(848, 44, 32, 32));
            frames.Add("LeftOpenHalf", new Rectangle(848, 44, 16, 32));
            frames.Add("LeftLock", new Rectangle(881, 44, 32, 32));
            frames.Add("LeftBoss", new Rectangle(914, 44, 32, 32));
            frames.Add("LeftHole", new Rectangle(947, 44, 32, 32));
            frames.Add("LeftHoleHalf", new Rectangle(947, 44, 16, 32));
            /// right
            frames.Add("RightWall", new Rectangle(815, 77, 32, 32));
            frames.Add("RightOpen", new Rectangle(848, 77, 32, 32));
            frames.Add("RightOpenHalf", new Rectangle(864, 77, 16, 32));
            frames.Add("RightLock", new Rectangle(881, 77, 32, 32));
            frames.Add("RightBoss", new Rectangle(914, 77, 32, 32));
            frames.Add("RightHole", new Rectangle(947, 77, 32, 32));
            frames.Add("RightHoleHalf", new Rectangle(963, 77, 16, 32));
            /// bottom
            frames.Add("DownWall", new Rectangle(815, 110, 32, 32));
            frames.Add("DownOpen", new Rectangle(848, 110, 32, 32));
            frames.Add("DownOpenHalf", new Rectangle(848, 126, 32, 16));
            frames.Add("DownLock", new Rectangle(881, 110, 32, 32));
            frames.Add("DownBoss", new Rectangle(914, 110, 32, 32));
            frames.Add("DownHole", new Rectangle(947, 110, 32, 32));
            frames.Add("DownHoleHalf", new Rectangle(947, 126, 32, 16));
            //tiles
            frames.Add("TileBasic", new Rectangle(984, 11, 16, 16));
            frames.Add("TileRaised", new Rectangle(1001, 11, 16, 16));
            frames.Add("TileStatueFace", new Rectangle(1018, 11, 16, 16));
            frames.Add("TileStatueDragon", new Rectangle(1035, 11, 16, 16));
            frames.Add("TileBlack", new Rectangle(984, 28, 16, 16));
            frames.Add("TileSand", new Rectangle(1001, 28, 16, 16));
            frames.Add("TileNavy", new Rectangle(1018, 28, 16, 16));
            frames.Add("TileBlue", new Rectangle(783, 79, 16, 16));
            frames.Add("TileStairs", new Rectangle(1035, 28, 16, 16));
            frames.Add("TileBlackBricks", new Rectangle(984, 45, 16, 16));
            frames.Add("TileWhiteStripes", new Rectangle(1001, 45, 16, 16));
            frames.Add("TileInvis", new Rectangle(1018, 45, 16, 16));
            // blue tiles
            frames.Add("TileBlueStatueFace", new Rectangle(468, 75, 16, 16));
            frames.Add("TileBlueStatueDragon", new Rectangle(468, 91, 16, 16));
            // item room
            frames.Add("RoomItem", new Rectangle(421, 1009, 256, 160));
            // dungeon room
            frames.Add("RoomDungeon", new Rectangle(682, 1009, 256, 160));
            // interiors
            /// first row
            frames.Add("RoomBlankFloor", new Rectangle(1, 192, 192, 112));
            frames.Add("RoomEntrance", new Rectangle(196, 192, 192, 112));
            frames.Add("RoomTwoSixes", new Rectangle(391, 192, 192, 112));
            frames.Add("RoomOneSixes", new Rectangle(586, 192, 192, 112));
            frames.Add("RoomFourOnesClose", new Rectangle(781, 192, 192, 112));
            frames.Add("RoomFourOnesFar", new Rectangle(976, 192, 192, 112));
            /// second row
            frames.Add("RoomOneOne", new Rectangle(1, 307, 192, 112));
            frames.Add("RoomFiveTwos", new Rectangle(196, 307, 192, 112));
            frames.Add("RoomGrid", new Rectangle(391, 307, 192, 112));
            frames.Add("RoomWaterMaze", new Rectangle(586, 307, 192, 112));
            frames.Add("RoomRightBlock", new Rectangle(781, 307, 192, 112));
            frames.Add("RoomStatuesContained", new Rectangle(976, 307, 192, 112));
            /// third row
            frames.Add("RoomDiamondStairs", new Rectangle(1, 422, 192, 112));
            frames.Add("RoomWaterHourglass", new Rectangle(196, 422, 192, 112));
            frames.Add("RoomStatuesCorners", new Rectangle(391, 422, 192, 112));
            frames.Add("RoomSand", new Rectangle(586, 422, 192, 112));
            frames.Add("RoomRightBlockStairs", new Rectangle(781, 422, 192, 112));
            frames.Add("RoomDiagonals", new Rectangle(976, 422, 192, 112));
            /// fourth row
            frames.Add("RoomHorizontalStripe", new Rectangle(1, 537, 192, 112));
            frames.Add("RoomReverseC", new Rectangle(196, 537, 192, 112));
            frames.Add("RoomTwoOnes", new Rectangle(391, 537, 192, 112));
            frames.Add("RoomMaze", new Rectangle(586, 537, 192, 112));
            frames.Add("RoomWaterHorizontalStripe", new Rectangle(781, 537, 192, 112));
            frames.Add("RoomWaterIsland", new Rectangle(976, 537, 192, 112));
            /// fifth row
            frames.Add("RoomStatuesBottomCorners", new Rectangle(1, 652, 192, 112));
            frames.Add("RoomTopBlock", new Rectangle(196, 652, 192, 112));
            frames.Add("RoomWaterDiamond", new Rectangle(391, 652, 192, 112));
            frames.Add("RoomTwoArrows", new Rectangle(586, 652, 192, 112));
            frames.Add("RoomWaterVerticalStripe", new Rectangle(781, 652, 192, 112));
            frames.Add("RoomThreeHoriztonalStripes", new Rectangle(976, 652, 192, 112));
            /// sixth row
            frames.Add("RoomWaterIslandNoAccess", new Rectangle(1, 767, 192, 112));
            frames.Add("RoomStatuesTwo", new Rectangle(196, 767, 192, 112));
            frames.Add("RoomSquareBlock", new Rectangle(391, 767, 192, 112));
            frames.Add("RoomWaterTwoHorizStripes", new Rectangle(586, 767, 192, 112));
            frames.Add("RoomBlockSpiral", new Rectangle(781, 767, 192, 112));
            frames.Add("RoomSkull", new Rectangle(976, 767, 192, 112));
            /// seventh row
            frames.Add("RoomBlockHoles", new Rectangle(1, 882, 192, 112));
            frames.Add("RoomTwoVerticalStripes", new Rectangle(196, 882, 192, 112));
            frames.Add("RoomGridFilled", new Rectangle(391, 882, 192, 112));
            frames.Add("RoomSword", new Rectangle(586, 882, 192, 112));
            frames.Add("RoomWaterHalf", new Rectangle(781, 882, 192, 112));
            frames.Add("RoomBlack", new Rectangle(976, 882, 192, 112));
        }

    }
}
