using game_project.CollisionResponse;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Link
{
    public class Sword : Entity
    {

        public Vector2 Up = new Vector2(10, -40);
        public Vector2 Down = new Vector2(25, 80);
        public Vector2 Left = new Vector2(-40, 25);
        public Vector2 Right = new Vector2(80, 25);


        public Vector2 Home = new Vector2(10, 40);
        public Sword()
        {
            Collider swordColl = new Collider(new RectangleF(0, 0, 20, 20));
            AddComponent(swordColl);
            swordColl.response.enabled = false;
            swordColl.response = new SwordCollisionResponse(this);

        }

    }
}
