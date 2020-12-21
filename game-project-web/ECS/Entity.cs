using System.Collections.Generic;
using System.Diagnostics;
using game_project.ECS.Components;
using game_project.Levels;

namespace game_project.ECS
{
    public class Entity
    {
        public int ID { get; set; }

        public string name = "";

        public EntityStates State
        {
            get
            {
                return state;
            }
            set
            {
                this.state = value;
                var transform = GetComponent<Transform>();
                foreach (Transform t in transform.Children)
                {
                    t.entity.State = value;
                }
            }
        }

        private EntityStates state = EntityStates.Playing;

        List<Component> components = new List<Component>();


        public Entity()
        {
            Transform transform = new Transform();
            AddComponent(transform);
        }


        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            component.entity = this;
            component.Init();
        }


        public static void Instantiate(Entity entity)
        {
            Scene.Add(entity);
        }

        public static void Destroy(Entity entity)
        {
            Scene.Remove(entity);
            foreach (var component in entity.components)
            {
                // destroy each component on this Entity
                component.SetForDeletion();
            }
        }


        public void print(object value)
        {
            Debug.WriteLine(value);
        }
    }
}
