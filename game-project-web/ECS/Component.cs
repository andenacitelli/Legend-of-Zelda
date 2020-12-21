using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace game_project.ECS
{
    public class Component
    {
        public Entity entity;

        public bool setForDeletion { get; set; } = false;

        public Component() { }

        public void SetForDeletion()
        {
            setForDeletion = true;
        }

        public virtual void Init() { }

        public virtual void Update(GameTime gameTime) { }

        public void print(object value)
        {
            Debug.WriteLine(value);
        }
    }
}
