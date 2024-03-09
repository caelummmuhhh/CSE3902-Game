Sprint 3 Documentation as it was written to help with implementation

# Collision
Link
Link has two hitboxes, an upper one and a lower one. They are both 16x8 (for now) and only have one difference: 
The upper hitbox does not interact with blocks. 
Everything else is the same as in interactions with walls/items/enemies.
We went into it a lot in the lectures but essentially if Link's hitbox intersects a wall/block the position is corrected. 
If he intersects with an item he grabs it (despawn item). And if he intersects with an enemy he takes damage and is pushed back.

Enemies
Enemies will have a separate hitbox from their sprite so an element will have to be added for enemies that is the hitbox size as a square centered at the sprite origin. 
The hitbox sizes are as follows:
Keese - 8x8
Gel - 8x8
Spike Cross - 8x8
Stalfos - 8x8
Goriya - 8x8
Wallmaster - 8x8
Old Man - 8x8
Aquamentus - 24x24
Enemies have a binding box that keeps them in the room. It's 192x112 and starts at (32, 32). However only Keese will ever try to leave the binding box, the rest just won't turn into it. 
More about the binding box:
If a Keese's hitbox leaves the binding box reverse its current direction. No position shifting should be needed as the reversed direction should cause it to fly back into the room
Wallmaster ignores walls, full functionality for Wallmaster will be written later
Other enemies treat the binding box the same as blocks
Enemies block collision is as follows:
Keese ignore blocks
When enemies (besides Keese) generate a random direction, spawn an 8x8 hitbox in that direction (relative to the enemy). 
If that hitbox intersects with a wall or block, generate a new direction and try again. Loop until a valid direction is chosen. 
It's possible instead of generating a new direction again you instead keep the old direction, but an enemy could possibly get stuck in a corner that way.
Also enemies do not interact with items or other enemies. 

Doors
Doors have the following hitboxes:
wallNormal - 32x32
wallDestructible - 32x32
destroyedWall - none
openDoor - none
keyDoor - 32x32
diamondDoor - 32x32
Extra hitbox properties include:
wallDestructible - if intersects with bomb explosion hitbox then wallDestructible -> destroyedWall
keyDoor - if intersects with Link and Link has > 0 keys then keyDoor -> openDoor

Projectiles and Sword
The Boomerang, Arrow, and Sword Beam hitboxes will be 8x8 centered at the sprite origin. 
The Bomb hitbox on explosion will be 32x32 around origin. 
The Sword will be a 16x16 hitbox in front of Link. 
The following is projectiles/sword and their interactions.
Wooden Boomerang - *Interaction causes boomerang to go immediately back toward Link
  Kills*: Keese, Gel
  Stuns*: Stalfos, Goriya Wallmaster
    Stunned enemies can't move for 3 seconds/180 frames. Should not interrupt movement pattern
  Bounces off*: Enemy Binding Box, Old Man, Aquamentus
    Bounce off Enemy Binding Box causes arrow hit particle to appear
  Goes through: Blocks, Spike Cross
  Collects: Items
Arrow - *Interaction causes arrow to disappear and make arrow hit particle appear
  Damages*: All enemies besides Spike Cross
  Hits*: Enemy Binding Box
  Goes through: Blocks, Spike Cross
Sword Beam - *Interaction causes beam to disappear and make beam hit particle appear
  Damages*: All enemies besides Spike Cross
  Hits*: Enemy Binding Box
  Goes through: Blocks, Spike Cross
Bomb
  Damages: All enemies besides Spike Cross
  if intersects with wallDestructible hitbox then wallDestructible -> destroyedWall
Sword
  Damages: All enemies besides Spike Cross
  Collects: Items 
  
Items
All items have an 8x8 hitbox centered at origin as well. If they are touched by Link/Sword or Boomerang they are collected. 
For now that just means the item object can be removed but in the future items will do things when collected.

Wall Hitboxes
Only Link interacts with these
dungeonNormal - 8 hitboxes
4 x roomWidthWall - 112x32
Locations:
  (8, 0)
  (144, 0) 
  (8, 144) 
  (144, 144) 
4 x roomHeightWall - 32x48
Locations:
  (0, 32) 
  (0, 96) 
  (224, 32) 
  (224, 96) 

dungeonOldMan  - 5 hitboxes
2 x roomWidthWall - 112x32
Locations:
  (8, 144) 
  (144, 144) 
2 x roomHeightWallShort - 32x48
Locations:
  (0, 96) 
  (224, 96) 
1 x oldManWall - 256x80
Locations:
  (0, 0) 

undergroundRoom - 9 hitboxes
4 x roomHeightWallLong - 48x128
Locations:
  (0, 0) 
  (64, 0) 
  (-16, 48) - I'm pretty sure negative numbers work here 
  (224, 96) 
5 x roomWidthWall - 112x32
Locations:
  (112, 48)
  (64, 96) 
  (32, 144) 
  (144, 144)

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Non-collision sprint 3 things
Particle Animations:
Given the particle sprite sheet:
1 : Death Animation 16x16
  As an enemy dies (after it has disappeared) it plays the following animation:
    6 frames first -> 6 frames second -> 6 frames first -> end
2 : Sword Beam Particles 8x16 (THESE ARE SMALLER SPRITES)
  As soon as a sword beam hits something (as it disappears) the following happens:
    At the origin of the sword beam, four of these particles are spawned facing each diagonal
    The animation of the particles are 1 frame of each color (1->2->3->4->repeat)
    The movement of the particles are +1 (+3 with scale) in both x and y for 24 frames
      * +/-1 xy towards the diagonal it's facing of course
3 : Spawn Particles 16x16
  As an enemy spawns (before the enemy does anything) it plays the following animation:
    3 frames first -> 6 frames second -> 6 frames third -> end/enemy spawns
None of these particles interact with anything

Item Drop Function:
When an enemy is killed it can drop an item. Need an item spawn function for when an enemy is defeated that works as follows:
On Enemy Defeat call Item Drop Function:
Generate random number 0-63
Depending on number the following will happen:
  0-14 : Spawn Heart (not Heart Piece just Heart) 
  15-29 : Spawn Rupee (single Rupee) 
  30-31 : Spawn Five Rupee 
  32-33 : Spawn Clock 
  34-36 : Spawn Fairy
  37-39 : Spawn Bomb (item) 
  40-63  : Spawn Nothing

Documentation about CSV files, room loading, and doors:
The room CSV files will be laid out as follows:
First row: Room type
   dungeonNormal - normal dungeon with tiles in center
   dungeonOldMan - dungeon border with black tiles in center
   undergroundRoom - underground room with bow and keese
Second row: The 4 Doors
   wallNormal
   wallDestructible
   destroyedWall
   openDoor
   keyDoor
   diamondDoor
Third to Ninth row: The playable room
   All blocks, items, and enemies
The doors go North -> South -> West -> East in the CSV files
Each room has three sprites which may need to be drawn at difference layers (hence why they are separate):
dungeonNormal
  SpriteFactory.CreateRoomOuterBorderSprite(),
  SpriteFactory.CreateRoomInnerBorderSprite(),
  SpriteFactory.CreateDungeonTilesSprite(),
dungeonOldMan 
  SpriteFactory.CreateRoomOuterBorderSprite(),
  SpriteFactory.CreateRoomInnerBorderSprite(),
  SpriteFactory.CreateEmptyRoomSprite(),
undergroundRoom
  SpriteFactory.CreateEmptyRoomSprite(),
  SpriteFactory.CreateEmptyRoomSprite(),
  SpriteFactory.CreateUndergroundRoomSprite(),
Note about door loading:
The "top" of the door must be layered over everything, whereas the "bottom" of the door must be layered under everything.
For example, for the north doors, the top 32x16 must be a separate sprite and layered above everything whereas the bottom 32x16 must again be separate and layered below everything.
So for another example, for the east doors, the right 16x32 must be a separate sprite and layered above everything else whereas the left 16x32 must again be separate and layered below everything.
