using game_project.ECS.Components;
using game_project.Sounds;
using Microsoft.Xna.Framework;
using System;

namespace game_project.GameObjects
{
    class HealthManagement : BehaviorScript
    {
        public int health;
        public bool damaged;
        public bool immune;
        protected int damage_frame = 0;
        protected int step = 5;
        protected Sound.SoundEffects HurtSound = Sound.SoundEffects.Enemy_Hit;

        public void IncreaseHealth(int healthToIncrease)
        {
            health += healthToIncrease;
            if (health > Constants.LINK_STARTING_HEALTH)
            {
                health = Constants.LINK_STARTING_HEALTH;
            }
        }

        public void DeductHealth(int healthToDeduct)
        {
            if (!immune)
            {
                health -= healthToDeduct;
            }
        }

        public void Damage(int damage)
        {
            DeductHealth(damage);
            Sound.PlaySound(HurtSound, entity, !Sound.SOUND_LOOPS);
            
            damaged = true;
            immune = true;
        }

        protected void DamageIndication()
        {
            Sprite sprite = entity.GetComponent<Sprite>();
            if (damaged)
            {
                switch ((damage_frame / step) % 4)
                {
                    case 0:
                        sprite.tint = Color.Blue;
                        break;
                    case 1:
                        sprite.tint = Color.White;
                        break;
                    case 2:
                        sprite.tint = Color.DarkGray;
                        break;
                    case 3:
                        sprite.tint = Color.Red;
                        break;
                    default:
                        //Console.Write("WAHT");
                        break;
                }
                if (++damage_frame == Constants.LINK_DAMAGE_FRAMES)
                {
                    damage_frame = 0;
                    damaged = false;
                    immune = false;
                    Console.WriteLine("Done");
                }
            }
        }
    }
}
