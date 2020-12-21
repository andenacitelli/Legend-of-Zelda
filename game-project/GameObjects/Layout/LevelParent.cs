using game_project.ECS;

namespace game_project.GameObjects.Layout
{
    public class LevelParent : Entity
    {
        public LevelParent()
        {
            name = "LevelParent";
            AddComponent(new LevelParentBehavior());
        }

    }
}
