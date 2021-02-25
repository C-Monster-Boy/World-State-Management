# World-State-Management
A system that defines the world state. This world state decides how the scenes are populated. Also, there may be events that change the world state. 

## Requirements
- Change in world state should persist across scenes
- Change in area state should affect given area
- World is divided into areas. Each scene is prescribed as an area
- World state flags are global and persist during gameplay (change of scene)
- Ease of use for a designer
  - Easily create world events in inspector
  - Easily create area events
  - Easily create world states using prefabs

## Satisfactory Demo Goals
- The triggering of a world event should 
  - show changes in a current area
  - show changes in current area and cause changes in other areas
- An area (scene) should load assets depending on current world and area states.
