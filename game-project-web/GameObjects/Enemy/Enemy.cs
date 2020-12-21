using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using game_project.CollisionResponse;

namespace game_project.GameObjects.Enemy
{
    public class Enemy : Entity
    {
        public bool frozen;
        // TODO: Try and move some code duplicated across enemies to here.
        public Enemy()
        {

        }
    }
}
