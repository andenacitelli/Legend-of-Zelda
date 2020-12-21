using System;
using System.Collections.Generic;

namespace game_project.ECS
{
    class Scene
    {
        public static List<Entity> entities = new List<Entity>();
        private static int nextID = 0;


        public static int Count { get { return entities.Count; } }

        public static void Add(Entity entity)
        {
            entities.Add(entity);
            entity.ID = nextID;
            nextID++;
        }

        public static void Remove(Entity entity)
        {
            entities.Remove(entity);
        }

        public static void Clear()
        {
            entities.Clear();
        }

        public static Entity Find(string name)
        {
            foreach (Entity e in entities)
            {
                if (e.name.ToLower() == name.ToLower())
                {
                    return e;
                }
            }
            return null;
        }

        public enum Layers
        {
            Projectile
        }


        private static Dictionary<Layers, List<Entity>> layers = new Dictionary<Layers, List<Entity>>();


        static Scene()
        {
            foreach (var layer in Enum.GetValues(typeof(Layers)))
            {
                layers.Add((Layers)layer, new List<Entity>());
            }
        }

        public static void AddToLayer(Layers layer, Entity entity)
        {
            layers[layer].Add(entity);
        }

        public static void ClearLayer(Layers layer)
        {
            foreach (var e in layers[layer])
            {
                Entity.Destroy(e);
            }
            layers[layer].Clear();
        }

    }
}
