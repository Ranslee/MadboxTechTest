# MadboxTechTest
## Intro
Hello! My name is Charlie Frost and I hope you'll have a good time reviewing this technical test for a Senior Core Developer role.

## Time
The test took me 14 hours. I could have completed it in 8, but I had some extra time and was having a good time, so I decided to throw in some extra features.

## Features
### General
- I played fast and loose with nullchecks, avoiding them in most places. There are many approaches one can take here - I avoided them mostly so that if things break, they break fast and give a good callstack.
- I did not create documentation as this readme is meant to serve that purpose. I'd add some comments but I ran out of time :)

### Gameplay
- From the get go I knew I was going to focus primarily on tooling and especially the debug console, so gameplay is not super shiny.
- I did the input capturing with UGUI. This lets me be agnostic about input and makes input consumption simple.
- Hero movement is done with NavMesh. It's not great but it's good for simple cases.
- Our hero attacks enemies in range, but there is no health, hit effects, or enemy destruction. I focused on other parts of the test.
- Weapons did not need a 'animation timing' stat because I handled it by scaling animation speed and firing an animation event from the clip instead.

### Tooling
- Most game parameters are defined in ScriptableObjects: weapon stats, weapon probabilities, enemy prefab and their min-max count for the spawner.
- This allows them to be changed at runtime with persistence. Weapon stat changes are applied immediately, weapon randomization is done through the cheat menu. There is no way to respawn enemies (I ran out of time).
- I added a AssetBrowserWindow (check Tools in the top bar) for easier asset searching/editing.
- For enemy detection and animation events, I wrote nice 'relay' scripts (Trigger.cs and RelayAnimationEvent.cs) that lets us define some logic in prefabs.
- For programmer convenience, I added some extension methods as well.
- Known bug: enemy detection (attack range) will not update until the weapon is re-equipped.

### Debug Console
- From my chat with Jonathan, I learned that Madbox uses Unity packages so I decided that as part of the test, I would make one feature into a package. I decided it would be the debug console.
- You can turn it on by pressing F1 on a PC or tapping with 5 fingers at once on mobile (there is a note about it in the 'main menu').
- The debug console is based on buttons - typing in text commands with a phone is time-consuming and it's worse for discoverability of cheats.
- Its design is very rough, but would make for a rough prototype made in a few hours, good for getting some initial feedback :)
- It is shipped as a package and does not reference anything in the project.

## Difficult parts
Surprisingly, the most difficult part was setting up the gameplay code. There was some trouble with the NavMesh component. At the end, I encountered a build-only bug caused by default implementation of interface comparisons. I think I got a bit rusty from all the system and optimization work I've been doing. For everything else I had a clear vision.

## What I could do better
- I think I have spread myself a bit too thin, the Debug Console package might have been a bit too much to handle, but oh well - I get to show it :)
- Documentation is very important, some code and files would be the next thing to focus on
- I don't like how the cheat entries have to unpack the cheat type, I think it could be solved with some generics.
- While Trigger is a good component, I think it's overengineered for the job as it introduced a couple bugs i didnt have time to fix

## Potential additions
> First of all
- Documentation!

### Gameplay
- Add a circle to indicate attack range
- Add an outline to indicate targeted enemy
- Add a hit effect

### Tooling 
- Calculate and display percentage chances for rolling weapons in the WeaponSet asset
- Make sure the game runs from any scene even without the Bootstrapper prefab
- Reduce build size; right now there is some uber shader from URP with 2560 variants
- Use addressable handles instead of direct references for game assets (I used them for the Console package though)
- Load the scenes asynchronously and console but lets not go too crazy
- Fix the bug that prevents us from updating the attack range at runtime until the weapon is re-equipped.

### Debug Console
- The Console package would need to add itself to addressables in its setup (right now its manual)
- You'd parametrize the UI setup so it can handle many screen aspects, not just vertical
- Allow the console to handle adding new cheats while it's open
- There is no cleanup right now, if GameObjects go missing, we're screwed
- Add scroll rects to handle multiple debug categories/longer lists of buttons
- Allow for quickly making ScriptableObject fields into cheats through attributes
- UX for float values is not great, there is no confirmation if/when values are applied
