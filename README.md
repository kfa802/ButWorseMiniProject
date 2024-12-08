# Pi3D Mini-Project

**Link to Video**: [https://youtu.be/1VHHHDejI3M](https://youtu.be/1VHHHDejI3M)

## Overview of the Game: Resident Evil 4 (but worse)

The project is an open-world third-person shooter set in a horror-themed environment, inspired by the game Resident Evil 4. The objective is to shoot as many zombies as possible while avoiding dying. Players lose a life if they are hit by a zombie or Mr. X, who is relentlessly chasing the player throughout the entire game. Extra ammunition can be collected from ammo boxes spread out across the map, and health can be restored by picking up glowing herbs. As the game progresses, more zombies spawn, making it increasingly difficult to stay alive. After dying, players have the opportunity to restart the game and aim for a higher kill count.

## Running The Game

1. Download Unity >= 2022.3.20f1
2. Clone or download the project
3. The game requires a computer with a mouse and keyboard

## Main Gameplay Elements

### Player Controls:
- **Movement**: WASD or arrow keys. 
- **Run**: Hold the Left Shift key. 
- **Crouch**: Press the C key.
- **Camera Orientation**: Use the mouse to control walking direction. 
- **Shoulder Switch**: Press the Alt key
- **Flashlight**: Toggle on/off by pressing the F key.
- **Aim**: Hold/press the right mouse button.
- **Shoot**: Click/tab the left mouse button.
- **Reload**: Press the R key

### Ammunition System:
- **Ammo Boxes**: Ammunition is limited. Collect ammo boxes to restock.  
- **Interaction**: Press E when prompted to pick up ammo boxes.

### Enemies:
1. **Killable Enemies**: Zombies
   - **Behavior**: Patrol, chase, and attack the player.
   - **Spawning**: Zombies spawn at specific spawn points across the map.
   
2. **Non-Killable Enemy**: Mr. X
   - **Behavior**: Continuously chases the player across the map, regardless of distance.

### Health System:
- **Damage**: A life is lost when the player is hit by a zombie or Mr. X.
- **Health Recovery**: Lives are regained by collecting glowing herbs.

## Game Features

### UI Elements:
- **Player health**: Displayed as three hearts (1 for each life). When the player takes damage a blood splatter is displayed on the screen ([source](https://bit.ly/bloodSplatter)).
- **Ammunition tracker**: Displayed at the top right of the screen. Tracks the ammo currently in the clip and extra ammo.
- **Kill count**: Displayed at the bottom of the screen and resets after restart.
- **Game Over Screen**: Displayed when the player dies. Can restart the game or return to “Main Menu”.

### Immersion:
- **Visual Effects**: Rain, fog and glow particle systems are added to enhance immersion.
- **Sound Effects**: Ambient sounds and sound effects are used to amplify the horror-themed atmosphere. Downloaded from:
  - Storm/Rain: [source](https://bit.ly/StormSound)
  - Thunder: [source](https://bit.ly/thunderSound)
  - Horror Ambience: [source](https://bit.ly/HorrorAmbient)
  - Resident Evil Ambience: [source](https://bit.ly/3D7ydtS)
  - Healing sound: [source](https://bit.ly/3ZMgxwQ)
  - Grunt: [source](https://bit.ly/4ineqGT)
  - Zombie sounds: [source](https://bit.ly/3BmGsS9)
  - Gun sounds: [source](https://drive.google.com/file/d/1Tm7oFrICnoZPj225xu8il9tyP9q-FrHy/view).
  
- **Open World**: Players have the opportunity to explore an open world created with terrain tools and prefabs downloaded from Unity Asset Store:
  - Skybox: [source](https://bit.ly/3D6l1oY)
  - StampIt!: [source](https://bit.ly/3ZGELZb)
  - Terrain Painter: [source](https://bit.ly/3Vq07aL)
  - Tree: [source](https://bit.ly/41nw8DY)
  - Pine Tree: [source](https://tinyurl.com/pinneTree).

## Project Parts

### Important Scripts:

#### NMovementStateManager:
Uses a Finite State Machine to control player movement:
- It manages the different movement states: NIdleState, NRunState, NWalkState, NCrouchState. 
- The NMovementBaseState is an abstract class that defines shared methods, which the derived classes can override and use to transition between states and update the animator.

#### NAimStateManager:
Uses a Finite State Machine to control aiming:
- It controls aiming and camera movement based on mouse input and manages states between default (NHipfireState) and the NAimstate.
- It controls the field of view (FOV) and camera position. For example, when aiming, the camera zooms in, and when crouching, the camera goes down.
- It uses Raycasting to detect objects the player is pointing at.

#### NWeaponManager:
Controls shooting mechanics:
- It manages gun sound effects, triggers the muzzle flash particle system, and instantiates a bullet prefab whenever the player fires a shot.
- The NBullet script controls the actual bullet behavior, like collision detection, applying damage and a kickback force to enemies when hit, and destroying itself.

### Enemy Scripts:
- **EnemyAI**: Controls enemy AI states – patrol/chase/attack – based on the distance to the player. It uses a NavMeshAgent for pathfinding, which allows the enemies to move smoothly on the terrain. When the player is not close to the enemy, it patrols between waypoints. The EnemyChase script also uses a NavMeshAgent for pathfinding, but it only controls the chase state, meaning this enemy (Mr. X) is always chasing the player.  
- **EnemyHealth**: Manages enemy health. The enemies take damage when hit by a bullet, and when the enemy dies (health <= 0), the RagdollManager is triggered to activate a ragdoll effect by disabling the kinematic mode on all the enemies rigidbodies.

### PlayerHealth:
This script controls the player’s health system and updates UI elements accordingly. When the player takes damage, a heart icon is removed, and a blood splatter sprite is displayed for a short duration of time. When the player heals, a heart icon is restored. When the player dies, a “Game Over” screen is displayed.

### HealingGlow:
This script controls the glowing effect of the herb GameObject (healing object) based on how close the player is to it. The herb will glow more intensely the closer the player is to it. It references a glow material on the herb that is used to create the glowing effect.

### Models, Prefabs, and Animations:
- **3D Models Downloads**:
  - Leon S. Kennedy: [source](https://bit.ly/3B8sIKV)
  - Mr. X: [source](https://bit.ly/4g9XT7F)
  - Ammo Box: [source](https://bit.ly/ResidentAmmoBox)
  - Shotgun: [source](https://bit.ly/RShotGun)
  - Herb: [source](https://bit.ly/RGHerb)
  - Bullet: [source](https://bit.ly/49uBwqR)
  - Zombie: [source](https://bit.ly/MixamoZombie)
  
- **All animations are downloaded from Mixamo**.

## Task Time It Took (in hours)

| Task | Time it Took (in hours) |
|------|-------------------------|
| Setting up Unity, making a Project in GitHub | 0.5 |
| Terrain Building and Searching for Assets | 1.5 |
| Third Person Player Movement/Aiming/Shooting/Camera behavior | 3 |
| Player Animations | 1.5 |
| Weapon and Ammo system | 2.5 |
| Damage/Health System (player health, enemy health, damage) | 3 |
| Enemy NavMesh logic (Patrol/Chase/attack) | 2.5 |
| Ragdoll setup | 1 |
| Enemy Spawner | 0.5 |
| Collision and bugfixing (when shooting) | 1.5 |
| Audio (sound effects and ambient sounds) | 1 |
| UI Elements | 2 |
| Playtesting and bugfixing | 1.5 |
| Lighting/Post-Processing/Particle Systems/Materials/Textures | 3 |
| Cleaning Unity Project and Code Documentation | 0.5 |
| **Total** | **25.5** |

## Video Tutorial References
- **Third Person Shooter (Unity Tutorial) – Gadd Games (Ep 1-14)**: [https://www.youtube.com/watch?v=KCYr5pFC6Sw&list=PLX_yguE0Oa8QmfmFiMM9_heLBeSA6sNKx](https://www.youtube.com/watch?v=KCYr5pFC6Sw&list=PLX_yguE0Oa8QmfmFiMM9_heLBeSA6sNKx)
- [https://www.youtube.com/watch?v=X5QEh9DmD7o&ab_channel=AqsaNadeem](https://www.youtube.com/watch?v=X5QEh9DmD7o&ab_channel=AqsaNadeem)
- [https://www.youtube.com/watch?v=dfgKx5B4Jfk&ab_channel=AqsaNadeem](https://www.youtube.com/watch?v=dfgKx5B4Jfk&ab_channel=AqsaNadeem)
- [https://www.youtube.com/watch?v=g1e-fftV1gE&t=74s&ab_channel=Seta-LevelDesign](https://www.youtube.com/watch?v=g1e-fftV1gE&t=74s&ab_channel=Seta-LevelDesign)
