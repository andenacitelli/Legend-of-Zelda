using game_project.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace game_project.ECS.Systems
{
    class BaseSystem<T> where T : Component
    {

        protected static List<T> components = new List<T>();
        protected static List<Component> componentsForDeletion = new List<Component>();

        public static void Register(T component)
        {
            components.Add(component);
        }


        public static void Update(GameTime gameTime)
        {
            int i = 0;
            while (i < components.Count)
            {
                var component = components[i];

                // Only components that are attached to an entity should execute
                if (component.entity != null)
                {
                    if (component.setForDeletion)
                    {
                        componentsForDeletion.Add(component);
                    }
                    else if (component.entity.State == EntityStates.Playing)
                    {
                        component.Update(gameTime);
                    }
                }

                i++;
            }
            CleanUp();
        }

        public static void CleanUp()
        {
            // gather all components set for deletion this frame
            foreach (T component in components)
            {
                if (component.setForDeletion)
                {
                    componentsForDeletion.Add(component);
                }
            }
            // delete all unused components
            foreach (T component in componentsForDeletion)
            {
                components.Remove(component);
            }
            componentsForDeletion.Clear();
        }

        public static void Clear()
        {
            components.Clear();
        }
    }
}
