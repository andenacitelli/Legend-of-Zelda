using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game_project.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace game_project.Sounds
{
    class Sound
    {
        private static readonly Sound instance = new Sound();
        public static Sound Instance
        {
            get
            {
                return instance;
            }
        }

        static private Dictionary<string, SoundEffect> soundFX = new Dictionary<string, SoundEffect>();
        private Sound() { }

        // Makes what the third argument of Play_Sound represents much clearer when calling from elsewhere.
        public const bool SOUND_LOOPS = true;

        // Used to make sure sounds aren't playing every frame without needing to do frame control outside of this class

        // Make sure we don't play sound effects when they are already playing.
        // This is WILD, I know. The idea is to only have one SoundEffectInstance tied to each SoundEffect in our list
        static private Dictionary<Entity, Dictionary<SoundEffect, SoundEffectInstance>> entitySoundsPlaying = new Dictionary<Entity, Dictionary<SoundEffect, SoundEffectInstance>>(); // Entity-tied version
        static private Dictionary<SoundEffect, SoundEffectInstance> soundsPlaying = new Dictionary<SoundEffect, SoundEffectInstance>(); // Non-entity-tied version

        // Helps with mapping sound effects to their files. 
        // Makes it so you can search for effects without needing to memorize the names. You can intellisense the values of this        
        public enum SoundEffects
        {
            Arrow_Boomerang,
            Bomb_Blow,
            Bomb_Drop,
            Boss_Hit,
            Boss_Scream1,
            Boss_Scream2,
            Boss_Scream3,
            Candle,
            Door_Unlock,
            Enemy_Die,
            Enemy_Hit,
            Fanfare,
            Get_Heart,
            Get_Item,
            Get_Rupee,
            Key_Appear,
            Link_Die,
            Link_Hurt,
            LowHealth,
            MagicalRod,
            Recorder,
            Refill_Loop,
            Secret,
            Shield,
            Shore,
            Stairs,
            Sword_Combined,
            Sword_Shoot,
            Sword_Slash,
            Text,
            Text_Slow
        }

        // Called via LoadContent
        public void LoadAllSounds(ContentManager content)
        {
            foreach (string effect in Enum.GetNames(typeof(SoundEffects)))
            {
                soundFX.Add(effect, content.Load<SoundEffect>(effect));
            }
        }

        // Iterate through all sound effects currently playing.
        // If sound effects are done playing, remove them from our record of what's currently playing. That is then valid to be played again if PlaySound is called again.
        public static void Update(GameTime gameTime)
        {
            return;
            // Entity-linked
            // Iterate through each Entity-SoundEffectPair (need ToList() to avoid modifying dictionary mid-iteration)
            foreach (Entity e in entitySoundsPlaying.Keys.ToList())
            {
                // Iterate through each SoundEffectPair in that entity (need ToList() to avoid modifying dictionary mid-iteration)
                foreach (SoundEffect effect in entitySoundsPlaying[e].Keys.ToList())
                {
                    if (entitySoundsPlaying[e][effect].State == SoundState.Stopped)
                    {
                        // Remove the sound effect itself
                        entitySoundsPlaying[e].Remove(effect);
                    }
                }

                // If the overall entity doesn't have any sounds playing as a result of the removals processed this frame, get rid of it for the sake of my OCD
                if (entitySoundsPlaying[e].Count == 0)
                {
                    entitySoundsPlaying.Remove(e);
                }
            }

            // Non-entity-linked
            foreach (SoundEffect effect in soundsPlaying.Keys.ToList())
            {
                if (soundsPlaying[effect].State == SoundState.Stopped)
                {
                    soundsPlaying.Remove(effect);
                }
            }
        }

        /* We make sure we don't play duplicate sounds from here and not elsewhere because having to do frame control elsewhere is just annoying.
           However, there are cases where we'd want the same sound effect played on top of each other. To allow this, we optionally associate an entity with the sound. 
           If no entity is associated, we make it so that sound effect cannot be playing alongside another of the same sound effect that has also not been associated with an entity.
           If it is passed in with an entity, we check that that entity is not already emitting a sound. 
           This entity association is recommended rather than mandatory because there might be points in the code that do not work with this and it's not very consequential. */

        // To play a sound, simply do Sound.PlaySound(Sound.SoundEffects.<sound name>). It is highly recommended to associate an entity with it, but optional
        public static void PlaySound(SoundEffects effect, Entity e, bool isLooped)
        {
            return;
            // If that entity is already in our list, and that entity has an entry for this sound effect, and if the soundeffectinstance linked to the sound effect is playing, get out
            // Please note that short circuiting gets us out of any null references here.
            if (entitySoundsPlaying.ContainsKey(e) && entitySoundsPlaying[e].ContainsKey(soundFX[effect.ToString()]) && entitySoundsPlaying[e][soundFX[effect.ToString()]].State == SoundState.Playing)
            {
                return;
            }

            // Otherwise, start playing the entry.
            // Could do a bit of optimization and reuse an instance that's already there but adding that complexity isn't worth it for an absolutely miniscule performance boost.
            SoundEffectInstance instance = soundFX[effect.ToString()].CreateInstance();
            instance.IsLooped = isLooped;
            instance.Play();

            // Add and store to sound system (get a little complicated to avoid null references, basically):
            // If entity already exists
            if (entitySoundsPlaying.ContainsKey(e))
            {
                if (entitySoundsPlaying[e].ContainsKey(soundFX[effect.ToString()]))
                {
                    entitySoundsPlaying[e][soundFX[effect.ToString()]] = instance;
                }

                else
                {
                    entitySoundsPlaying[e].Add(soundFX[effect.ToString()], instance);
                }
            }

            // If entity doesn't already exist 
            else
            {
                Dictionary<SoundEffect, SoundEffectInstance> entityDict = new Dictionary<SoundEffect, SoundEffectInstance>();
                entityDict.Add(soundFX[effect.ToString()], instance);
                entitySoundsPlaying.Add(e, entityDict);
            }
        }

        public static void PlaySound(SoundEffects effect, bool isLooped)
        {
            return;
            if (soundsPlaying.ContainsKey(soundFX[effect.ToString()]) && soundsPlaying[soundFX[effect.ToString()]].State == SoundState.Playing)
            {
                return;
            }

            // Otherwise, start playing the entry.
            // Same note as above about reusing instance. 
            SoundEffectInstance instance = soundFX[effect.ToString()].CreateInstance();
            instance.IsLooped = isLooped;
            instance.Play();

            // Store the sound in our system. A little complicated to avoid null references.
            if (soundsPlaying.ContainsKey(soundFX[effect.ToString()]))
            {
                soundsPlaying[soundFX[effect.ToString()]] = instance;
            }

            else
            {
                soundsPlaying.Add(soundFX[effect.ToString()], instance);
            }
        }

        // Stops the given sound effect.
        // Theoretically this never gets called when the given sound effect isn't running, but performs as expected (aka does nothing) in that circumstance.
        // Our only use case is stopping a looping sound, but it should theoretically still work for non-looping sounds.
        public static void StopSound(SoundEffects effect)
        {
            // If it doesn't exist in our system, or is set to be purged via our update loop (as it has stopped), get out of here
            // Again, as with PlaySound, short circuiting gets us out of this logical before we run into null references
            if (!soundsPlaying.ContainsKey(soundFX[effect.ToString()]) || soundsPlaying[soundFX[effect.ToString()]].State != SoundState.Playing)
            {
                return;
            }

            // Otherwise, the sound exists and is playing, so stop it. Will be purged in the next update loop run.
            soundsPlaying[soundFX[effect.ToString()]].Stop();
        }

        // Entity-linked version of the above.
        public static void StopSound(SoundEffects effect, Entity e)
        {
            // If it doesn't exist in our system, or is set to be purged via our update loop (as it has stopped), get out of here
            // Again, as with PlaySound, short circuiting gets us out of this logical before we run into null references
            if (!entitySoundsPlaying.ContainsKey(e) || !entitySoundsPlaying[e].ContainsKey(soundFX[effect.ToString()]) || entitySoundsPlaying[e][soundFX[effect.ToString()]].State != SoundState.Playing)
            {
                return;
            }

            // Otherwise, the sound exists and is playing, so stop it. Will be purged in the next update loop run.
            entitySoundsPlaying[e][soundFX[effect.ToString()]].Stop();
        }

        // For convenience. When we end the game or switch screens, we might want to do this, for example.
        public static void StopAllSounds()
        {
            // Entity-linked
            // Iterate through each Entity-SoundEffectPair (need ToList() to avoid modifying dictionary mid-iteration)
            foreach (Entity e in entitySoundsPlaying.Keys.ToList())
            {
                // Iterate through each SoundEffectPair in that entity (need ToList() to avoid modifying dictionary mid-iteration)
                foreach (SoundEffect effect in entitySoundsPlaying[e].Keys.ToList())
                {
                    entitySoundsPlaying[e][effect].Stop();
                }

                // If the overall entity doesn't have any sounds playing as a result of the removals processed this frame, get rid of it for the sake of my OCD
                if (entitySoundsPlaying[e].Count == 0)
                {
                    entitySoundsPlaying.Remove(e);
                }
            }

            // Non-entity-linked
            foreach (SoundEffect effect in soundsPlaying.Keys.ToList())
            {
                soundsPlaying[effect].Stop();
            }

            /* Reset dictionaries just to be sure */
            soundsPlaying = new Dictionary<SoundEffect, SoundEffectInstance>();
            entitySoundsPlaying = new Dictionary<Entity, Dictionary<SoundEffect, SoundEffectInstance>>();
        }
    }
}
