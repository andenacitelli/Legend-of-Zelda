using System;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.ECS.Systems;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using Microsoft.Xna.Framework;

namespace game_project.Commands
{
    class CommandDebugColliders : ICommand
    {
        public void Execute()
        {
            ColliderSystem.DrawDebug = !ColliderSystem.DrawDebug;
        }
    }
}
