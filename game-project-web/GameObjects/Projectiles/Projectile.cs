using game_project.ECS;

namespace game_project.GameObjects.Projectiles
{
    public class Projectile : Entity
    {
        public Projectile()
        {
            Scene.AddToLayer(Scene.Layers.Projectile, this);
        }
    }
}
