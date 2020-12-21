using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace game_project
{
    //class LayerDepthsHelper
    //{
    //    public List<Constants.LayerDepths> = new List<Constants.LayerDepths>();
    //}

    public static class Constants
    {
        /* Notes:
         * - All units are in half-hearts (e.g a "6" in here means three full hearts). 
         * 
         * Sources:
         * https://www.zeldaspeedruns.com/tww/general-knowledge/damage-values for damage values.
         * */

        /* GENERAL */
        public const int MillisecInSec = 1000;
        static readonly Random _R = new Random();
        public static int GetRandomIntMinMax(int min, int max)
        {
            return _R.Next(min, max);
        }

        /* ENUMS */
        public enum Direction { UP, RIGHT, DOWN, LEFT }
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }

        /* LAYER DRAWING */
        public const float LAYER_DEPTH_DEBUG = 1.0f;
        public const float LAYER_DEPTH_TEXT = 1.0f;
        public const float LAYER_DEPTH_BACKDROP = 0.995f;
        public const float LAYER_DEPTH_DOORS = 0.99f;
        public const float LAYER_DEPTH_PLAYER = 0.98f;
        public const float LAYER_DEPTH_ITEM = 0.4f;
        public const float LAYER_DEPTH_ENEMY = 0.5f;
        public const float LAYER_DEPTH_BLOCK = 0.1f;
        public const float LAYER_DEPTH_ROOM = 0.05f;

        public enum LayerDepth
        {
            Debug,
            Text,
            Boxes,
            Backdrop,
            Doors,
            Player,
            Item,
            Enemy,
            Block,
            Room
        }

        private static List<LayerDepth> orderedDepths = new List<LayerDepth>();
        public static float[] layerDepths;

        /* Window Drawing */
        public const int SCREEN_PREFERRED_WIDTH_PX = 1024;
        public const int SCREEN_PREFERRED_HEIGHT_PX = 910;
        public static Point SCREEN_WINDOW_ORIGIN = new Point(100, 100);
        public const string STARTING_LEVEL = "2_5";

        static Constants()
        {
            orderedDepths = Enum.GetValues(typeof(LayerDepth)).Cast<LayerDepth>().ToList();
            int count = orderedDepths.Count();
            layerDepths = new float[count];
            for (int i = 0; i < count; i++)
            {
                float actualDepth = 1 - (float)i / (float)count;
                layerDepths[i] = actualDepth;
            }

        }

        public static float SetLayerDepth(Entity entity, LayerDepth depth)
        {
            int index = orderedDepths.FindIndex(x => x == depth);
            float result = layerDepths[index];
            entity.GetComponent<Transform>().layerDepth = result;
            return result;
        }
        public static float GetLayerDepth(LayerDepth depth)
        {
            int index = orderedDepths.FindIndex(x => x == depth);
            float result = layerDepths[index];
            return result;
        }


        /* LINK */
        public const int LINK_STARTING_HEALTH = 6;
        public const int LINK_HEALTH_PER_HEART = 2;
        public const int LINK_SWORD_DAMAGE = 1;
        public const int LINK_BOOMERANG_DAMAGE = 1;
        public const int LINK_ATTACK_FRAMES = 28;
        public const int LINK_DAMAGE_FRAMES = 28;
        public const int LINK_PICKUP_TIME_MS = 2 * MillisecInSec;
        public const float LINK_MOVEMENT_SPEED = .5f;
        public const float SWORD_BEAM_SPEED = .4f;
        public const int SWORD_BEAM_DAMAGE = 2;
        public const int LINK_LOW_HEALTH_THRESHOLD = 2;

        /* ENEMIES */
        // General
        public const float ENEMY_FREEZE_TIME = 3 * MillisecInSec;
        public const int ENEMY_KNOCKBACK_DISTANCE = 150;
        public const int ENEMY_KNOCKBACK_FRAMES = 10;

        // Aquamentus
        public const int AQUAMENTUS_TIME_BETWEEN_SHOTS_MS = 2000;
        public const float AQUAMENTUS_FIREBALL_ANGLE_DEGS = 20f; // In DEGREES
        public const float AQUAMENTUS_FIREBALL_ANGLE_RADS = AQUAMENTUS_FIREBALL_ANGLE_DEGS * (float)Math.PI / 180; // In RADIANS
        public const int AQUAMENTUS_TIME_TO_START_ROAM_MS = 350;
        public const int AQUAMENTUS_ATTACK_WINDOUP_TIME_MS = 250;
        public const int AQUAMENTUS_HEALTH = 200;
        public const float AQUAMENTUS_MOVEMENT_SPEED = .02f;

        // Fireball
        public const int FIREBALL_DAMAGE = 1;

        // Blade Trap
        public const int BLADETRAP_HEALTH = 1; // Unused
        public const int BLADETRAP_CONTACT_DAMAGE = 1;
        public const float BLADETRAP_MOVEMENT_SPEED = .2f;

        // Gel 
        public const int GEL_HEALTH = 1;
        public const int GEL_CONTACT_DAMAGE = 1;
        public const int GEL_INITIAL_STOP_TIME = 20;
        public const int GEL_MOVE_AGAIN_TIME = 40;
        public const int GEL_CHANGE_DIRECTION_TIME = 60;

        // Goriya
        public const int GORIYA_HEALTH = 1;
        public const int GORIYA_CONTACT_DAMAGE = 1;
        public const int GORIYA_FRAMES_TO_FLIP_AT = 10;
        public const float GORIYA_MOVEMENT_SPEED = .2f;
        public const int GORIYA_BOOMERANG_FRAMES = 70;

        // Keese
        public const int KEESE_HEALTH = 1;
        public const int KEESE_CONTACT_DAMAGE = 1;
        public const float KEESE_MOVEMENT_SPEED = .2f;
        public const int KEESE_DELTA_X = 2;

        // Stalfo
        public const int STALFO_HEALTH = 1;
        public const int STALFO_CONTACT_DAMAGE = 1;
        public const float STALFO_MOVEMENT_SPEED = .1f;
        public const int STALFOS_ANIMATION_FRAMES = 7;

        // Wallmaster
        public const int WALLMASTER_HEALTH = 50;
        public const int WALLMASTER_CONTACT_DAMAGE = 1;
        public const float WALLMASTER_MOVEMENT_SPEED = .2f;
        public const int WALLMASTER_DIRECTION_SWITCH_WAIT = 60;

        /* PROJECTILES */
        // Boomerang
        public const float BOOMERANG_ACCEL = .03f;
        public const float BOOMERANG_INITIAL_SPEED = 1f;
        public const float BOOMERANG_INITIAL_RETURN_SPEED = .03f;

        // Fireball
        public const float FIREBALL_LIFETIME_MS = 3 * MillisecInSec; // ms
        public const float FIREBALL_SPEED = .2f;

        /* ITEMS */
        // General
        public const float ITEM_DELETION_TIME_MS = 2 * MillisecInSec;
        public const float ITEM_MOVEMENT_SPEED = .1f;

        // Bomb
        public const int BOMB_DAMAGE = 100;
        public const float BOMB_EXPLOSION_TIME_MS = 1 * MillisecInSec;
        public const int BOMB_PICKUP_COUNT = 4;

        /* BLOCKS */
        public const float BLOCK_TIME_TO_MOVE_MS = 1 * MillisecInSec;
        public const float BLOCK_MOVEMENT_SPEED = .065f;
        public const int WALL_THICKNESS = 127; // px 
        public const int WALL_THICKNESS_TOP = 127 + 29; // px 
        public const int WALL_TOP_WIDTH = 448; // px 
        public const int WALL_SIDE_WIDTH = 288; // px 

        /* LEVEL LOADING */
        public const float SCREEN_HEIGHT_MULTIPLICATIVE_RATIO = .77f;
        public const int SCREEN_HEIGHT_OFFSET = 4;
        public const int HORIZ_GRID_UNITS = 16;
        public const int VERT_GRID_UNITS = 11;
        public const int STARTING_LEVEL_INDEX = 11;

        /* LINK START POSITIONS */
        public static readonly Vector2 pos0_0 = new Vector2(195, 260);
        public static readonly Vector2 pos1_0 = new Vector2(440, 550);

        /* HUD */
        public const float HUD_ITEM_SCALE = 0.5f;
        public const float HUD_TEXT_SCALE = 0.5f;
        public const float HUD_BOOMERANG_SCALE = 1.5f;
        public const float HUD_BOMB_SCALE = 0.9f;
        public const float HUD_BOW_SCALE = 0.8f;

        /* TEXT */
        public enum TextHorizontal { LeftAligned, CenterAligned, RightAligned }
        public enum TextVertical { TopAligned, CenterAligned, BottomAligned }
        public const float TEXT_MOVEMENT_TIME = 100;
        public const int DUNGEON_NPC_TEXT_WIDTH = 175 * (int)SPRITE_SCALAR;
        public const int DUNGEON_NPC_TEXT_HEIGHT = 32 * (int)SPRITE_SCALAR;

        /* SPRITES */
        public const int SPRITE_UPDATES_PER_FRAME = 7;
        public const float SPRITE_SCALAR = 4f;

        /* OTHER */
        public const int POOF_UPDATE_FRAME_SPEED = 14;
        public const int FIRE_FRAMES = 7;

    }
}
