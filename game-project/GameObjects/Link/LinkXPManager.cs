using System;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using game_project.ECS;
using game_project.Sounds;

namespace game_project.GameObjects.Link
{
    class LinkXPManager : BehaviorScript
    {
        public int linkXp;
        public bool didMaxAction;

        public LinkXPManager()
        {
            linkXp = Constants.STARTING_XP;
            didMaxAction = false;
        }

        public void EnemyKill_XPIncrease()
        {
            if (!IsXPMax())
            {
                linkXp++;
            }

            if (!didMaxAction && IsXPMax())
            {
                whenMax();
            }
        }

        public void LinkDamaged_XPDecrease()
        {
            linkXp = Constants.STARTING_XP;
            didMaxAction = false;
        }

        public Boolean IsXPMax()
        {
            return linkXp == Constants.MAX_XP;
        }
        
        public void whenMax()
        {
            // sound effect 
            Sound.PlaySound(Sound.SoundEffects.Get_Item, entity, !Sound.SOUND_LOOPS);

            // give link full health
            entity.GetComponent<LinkHealthManagement>().health = Constants.LINK_STARTING_HEALTH;
            didMaxAction = true;

            Sound.StopSound(Sound.SoundEffects.Enemy_Hit);
        }
    }
}
