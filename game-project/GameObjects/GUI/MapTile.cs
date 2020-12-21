using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class MapTile : Entity
    {

        public MapTile(Sprite s, Vector2 pos)
        {
            Constants.SetLayerDepth(this, Constants.LayerDepth.Text);
            var transform = GetComponent<Transform>();
            transform.position = pos;
            AddComponent(s);
        }


    }
}
