# CSE 3902 Game Project
An implementation of [The Legend of Zelda](https://en.wikipedia.org/wiki/The_Legend_of_Zelda_(video_game)) (1986) in MonoGame for CSE 3902 at [The Ohio State University](https://www.osu.edu/).

## Team Members
- Anden Acitelli
- Sonja Linton
- Pranav Pitchala
- Aditya Singh
- Matt Hall

## Project Structure
- `game-project/` - our implementation of Legend of Zelda
- `game-project-web/` - a port to web using Bridge.Net, detailed [here](WebPort.md).
- `MonoGame.Framework` - modified version of the MonoGame framework used by `game-project-web`.

## Requirements
- Visual Studio 2019
- MonoGame 3.7.1 (installers [here](https://github.com/MonoGame/MonoGame/releases/tag/v3.7.1))

## Building
Instructions to build the core Windows implementation. For instructions on building the Web port, see [here](WebPort.md#building)
1. Clone the repo and open `game-project.sln` in Visual Studio.
2. Open the `game-project` project.
3. Change the [build configuration](https://docs.microsoft.com/en-us/visualstudio/ide/understanding-build-configurations?view=vs-2019) to *Debug* using the menu in the top toolbar.
4. Press <kbd>F5</kbd> or click the *Start* button in the top toolbar to run the game.
5. Enjoy!

## Program Controls
### Keyboard
* <kbd>🡐</kbd>, <kbd>🡒</kbd>, <kbd>🡑</kbd>, <kbd>🡓</kbd> and <kbd>W</kbd>, <kbd>A</kbd>, <kbd>S</kbd>, <kbd>D</kbd>
  * Move Link and change his direction
  * Select items in the Inventory view
* <kbd>Z</kbd> and <kbd>N</kbd>
  * Attack with Link's A selected weapon.
  * Confirm item selection in the Inventory view
* <kbd>B</kbd> uses the B selected item.
* <kbd>E</kbd> opens the inventory.
* <kbd>Shift</kbd> pauses the game.
* <kbd>U</kbd> begins *Boss Rush* mode.
* <kbd>Q</kbd> to quit the game.
* <kbd>R</kbd> restarts the game.
* <kbd>;</kbd> toggles drawing hitboxes for debugging colliders.
* <kdb>'</kbd> toggles a frame rate indicator.

### GamePad (XBox Controller)
* <kbd>Left joystick</kbd> moves Link and changes his facing direction.
* The <kbd>right trigger</kbd> causes Link to attack using his sword.
* ABXY keys are used to have Link use a different item.
  * <kbd>Y</kbd> uses a bomb.
  <!--- * <kbd>2</kbd> uses the boomerang. --->
* <kbd>left trigger</kbd> toggles between using the bomb and the boomerang. (B-selected Item)

### Other Controls
* Use <kbd>u</kbd> to start the Boss Rush sequence, which is an infinite sequence of randomly generated levels of increasing difficulty.
* Use <kbd>shift</kbd> to play/pause.
## About

### Entity-Component-System
Our game uses an entity-component system to track all entities in the game and give them different components. Entities are the class for any given "thing" in the scene. Your player, their weapon, the enemies, the walls, all are "entities" in this model. Components describe any behavior shared between many Entities. Examples include `Transform`, `Collider`, `Sprite`, `Script`, etc. We modelled our implemetation off of the [Unity](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html) style of ECS, as that's what many game programmers are used to.

The following are options for components.
* Transform - position, rotation and scale of the entity
* Sprite - the sprite used by the entity
* BehaviorScript - a component to house scripts that define the behavior of an entity
* Collider - defines the type of collision response for the entity
* Text - the text drawn on the screen during the NPC interaction and during various game state screens (e.g. "Game Over")



## Level Loading
We implemented level loading using CSV files and a large loading class that parses the strings from the CSV and determines which item, enemy, npc, or block to create. Enemies and NPCs are instatiated with the characteristic "poof". The CSV file is based on a grid system where (0,0) is the top left corner of the walls, and (2,2) is the top left corner of the floor. We also added the ability to offset entities upon load, so we can be more exact with placements of enemies and items.

## Boss Rush
As part of sprint 5, we added "Boss Rush", a gamemode that offers infinite levels of increasing difficulty with randomized enemies. Each level only lets you progress past it whenever all enemies are dead. In the code, each enemy is assigned a difficulty rating (most enemies are 1, aquamentus is 6) and each level from the beginning increases the total enemy point cap for the given level by 1. Thus, harder enemies result in less enemies being on the screen. 

## Known Bugs / Issues

### Keese Animation Randomly Stopping
Keese movement was updated to be more random. However, there is now a very confusing and annoying bug where the Keese animation is set to false randomly for random keese at random times, and is never set back to true. Sonja has looked at this for over three hours and cannot figure it out, so hopefully this documentation shows that this is not the intended point of the keese movement.


### Link can move when he attacks
We like this feature better, but it's still technically an issue.

### Link should collide with statues in the first room
No, he shouldn't. The video we watched shows no collision. See: https://www.youtube.com/watch?v=u6lb5gyCZ8s
