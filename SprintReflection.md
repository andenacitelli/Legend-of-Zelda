# Sprint 5 Reflection
## General Comments
We are happy with how polished our game turned out. We noticed how close the final game is to our playthroughs of the emulator. Everyone found an extra feature to work on that interested them. We also fixed many bugs present in Sprint 4 (and before). The biggest bug we solved was that Collider Components would stay in the game world after their Entities had been killed. We fixed this bug during this sprint by writing a cleanup function to remove unused components from the update loop. 


## Added Features
- Ported version of codebase to Web. More information can be found in [WebPort.md](WebPort.md).
- Boss Rush feature where a player can play random levels of increasing difficulty. Levels continue practically forever.
- XP Bar that increases after killing a certain number of enemies. When full XP is reached, Link's health is restored.
- XBox controller support.


## Resolved Issues from Sprint 4
We fixed nearly all of the issues from Sprint 4. Any issues remaining in Sprint 5 do not affect gameplay. 
- Texture2D storage was combined in a `GameContent` class. This facilitates easy loading of all assets and provides for asynchonous content loading on the web platform.
- Stalfo key offset fixed to be at the center of the enemy.
- All remaining Link collision consequences implement.
- Enemies flash when damaged and bounce back.
- Enemy health constants corrected.
- You can now kill Aquamentus, as Link can place bombs in every room.
- Wallmaster fix to grab Link.
- Transition game state to prevent Link from getting stuck in Doors.
- Link no longer gets stuck in the block by the stairs.
- Link goes under Doors now for a much better effect.
- Inventory now can be opened after restart.
- Sword shooting improved.


## Issues of Sprint 5
Noted bugs include:
- enemies don't pause while "poofs" play
- cannot exit Boss Rush without reset
- Keese movement was updated to be more random. However, there is now a very confusing and annoying bug where the Keese animation is set to false randomly for random keese at random times, and is never set back to true. Sonja has looked at this for over three hours and cannot figure it out, so hopefully this documentation shows that this is not the intended point of the keese movement.
- music doesn't perfectly loop.

Organizationally, an issue we had is lagging behind on tasks with many estimated hours and finishing them late into the Sprint. This is the reason why there is such a steep cliff at the end of the burndown chart. To improve this, I think we need to split large tasks into smaller tasks.

## Burndown Sprint 5
![Sprint 5 Burndown](Burndown-Sprint5.png)
