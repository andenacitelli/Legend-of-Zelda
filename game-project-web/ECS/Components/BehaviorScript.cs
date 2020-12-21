using game_project.ECS.Systems;

namespace game_project.ECS.Components
{
    // A Component for implementing custom behavior
    public class BehaviorScript : Component
    {
        public BehaviorScript()
        {
            BehaviorScriptSystem.Register(this);
        }
    }
}
