# Game Engines 2 2019-2020

[![Video](http://img.youtube.com/vi/NMDupdv85FE/0.jpg)](http://www.youtube.com/watch?NMDupdv85FE)

## Resources
- [Class Facebook page](https://www.facebook.com/groups/407619519952058/)
- [Assignment](ca.md)
- [A build of Infinite Forms](https://drive.google.com/file/d/1w24BcMAi6P1XmPc9D9ss6Lkro4KBvsMS/view?usp=sharing)
- [All about Infinite Forms](http://bryanduggan.org/forms)
- [A spotify playlist of music to listen to while coding](https://open.spotify.com/user/1155805407/playlist/5NYFsIFTgNOI93hONLbqNI)

## Contact me
* Email: bryan.duggan@dit.ie
* Twitter: [@skooter500](http://twitter.com/skooter500)
* [My website & other ways to contact me](http://bryanduggan.org)

## Last years course
- [2018-2019](https://github.com/skooter500/GE2-2018-2019)
	
## Assessment Schedule	
- Week 5 - CA proposal & Git repo
- Week 11 - Lab Test - 20%
- Week 13 - CA Submission & Demo - 50%

## Previous Lab Tests
- https://github.com/skooter500/GE2-Lab-Test-2019
- https://github.com/skooter500/GE2-LabTest2-2017
- https://github.com/skooter500/GE2-2017-Lab-Test
- https://github.com/skooter500/GE2-Labtest1-2018

## Week 7 - More wandering + obstacle avoidance

## Lab
I added a new behaviour to the repo called ObstacleAvoidance. 

Create a new scene and create a boid that has Wander and ObstacleAvoidance behaviours enabled. Create an environment from primitives such as cubes and spheres that the your boid can explore. You might have to experiment with the parameters on ObstacleAvoidance to get the boid to explore without colliding. Check this video out for an example of how it might look:

[![YouTube](http://img.youtube.com/vi/qmtxqCU1X5Q/0.jpg)](https://www.youtube.com/watch?v=qmtxqCU1X5Q)

Want an interesting challenge ;-) Place the exploring boids in a this procedural environment:

[![YouTube](http://img.youtube.com/vi/M3iI2l0ltbE/0.jpg)](https://www.youtube.com/watch?v=M3iI2l0ltbE)


## Week 6 - Wandering
## Lab

Try [this lab test](https://github.com/skooter500/GE2-Labtest1-2018) from a couple of years ago

## Week 5
### Learning Outcomes 
- Refactor the code we have been writing to use components

### Lab
- Learn how to refactor a big class that does many things into lots of smaller classes that do one thing each

### Task 1
- Find some 3D models & art assets for your assignment & get them loaded into a scene in Unity
- Set up a git repo for your assignment

### Task 2

Out Boid class is getting big so now it's time to refactor the code so that each behaviour is a seperate MonoBehaviour.

Clone/pull the repo for the course

- Make an abstract base class called SteeringBehaviour that extends MonoBehavior
- Add one abstract method ```public abstract Vector3 Calculate()```
- Add a public field for *weight* of type float and also add a field for the Boid (the owner of the behaviour)
- Take each of the behaviours we wrote (seek, arrive, flee, path following, PlayerSteering) and make each of them extend SteeringBehaviour. Do the calculation of the force in Calculate
- Remove the boolean flags for the behaviours. They are not needed any more. Instead each boid will use whatever behaviours are attached to it.
- Give the Boid a field of type ```SteeringBehaviour[]```
- In the setup method of the Boid class, call GetComponents to get all the attached SteeringBehaviours
- Assign the boid field of each attached behaviour
- In the Boid Update method, iterate over the activated behaviours and sum the generated forces * the weights
- This will become more useful when we combine the behaviours together

### Task 3

Try [this lab test from last year](https://github.com/skooter500/GE2-Lab-Test-2019)


## Week 4

### Lab

Update your fork of the course repo to get the Pursue code we wrote in the class on Friday.

Create a new scene and make this predator prey simulation. The prey will follow a path until the predator comes into range. When the predator is is range the prey will attack the predator by shooting at it. It only shoots at the predator if it is inside the field of view. The predator will get close to the prey, but will flee from the prey if the prey attacks it. You can use colliders and then disable and enable certain behaviours to implement the simulation.

[![YouTube](http://img.youtube.com/vi/SqThPN_ogJE/0.jpg)](https://www.youtube.com/watch?v=SqThPN_ogJE)

To draw the "Lazers" you can use Debug.DrawLine from Update 

## Week 3
- Pursue
- Offset

### Lab

### Part 1 - Path following

Update your fork of the repo with the latest code from the master branch of my repo. To do this, cd to the folder where you have your fork cloned and type:

```
git checkout master
git pull upstream master
```

This will get the code we wrote last week. Open the Seek scene and you will see a boid that implements seek, arrive and player steering behaviours in the BigBoid.cs class. Today you can implement a path following behaviour for the boid.

Check out this video:

[![Video](http://img.youtube.com/vi/eAfpnWI5jEI/0.jpg)](http://www.youtube.com/watch?v=eAfpnWI5jEI)

The scene contains a game object object with a script called ```Path``` attached. The path script implements the method ```OnDrawGizmos``` to draw lines between the waypoints on the path and to draw a sphere at each of the waypoints. The blue box is following the path. Today you can try and program this behaviour. 

- Implement the ```Path``` script that contains a ```public List<Vector3> waypoints``` containing the waypoints. The 0th waypoint should be the position of the path gameobject itself and the positions of the attached children should be used to set the subsequent waypoints. You can populate this list in ```Awake```. 
- Add a bool flag on the ```Path``` class called ```IsLooped``` to indicate whether the path should loop back to the 0th waypoint when the Boid reaches the last waypoint. If this flag is set to be false, then don't draw a line gizmo back to the 0th waypoint.
- In the scene, create a path using the ```Path``` script you made.
- Add a a public field to the BigBoid class for the Path and drag the Path you made onto this in the Unity editor. 
- Now write code for a behaviour in BigBoid called ```FollowPath``` to get the Boid to move from waypoint to waypoint on the path using Seek and Arrive. If the ```IsLooped``` flag is true on the path, then the Boid should Seek the 0th waypoint again when it reaches the last waypoint. If this flag is set to be false, then the Boid should Arrive at the last waypoint. You will need to add a method called FollowPath and a boolean flag to indicate that the FollowPath behaviour is enabled. 

### Part 2 - Flee

- Implement a behaviour called ```Flee``` that causes the BigBoid to flee from a target when the target comes in range. To do this, add a method called ```Flee``` and a bool flag called ```FleeEnabled``` on the BigBoid class. You will also have to update the ```CalculateForces``` method. Set up your scene with a target game object and move the target around the scene and make sure the Flee force gets activated when the target comes in range.

## Week 2 
- Boid integration
- Seek
- Arrive
- PlayerSteering
- Banking

## Lab
- No lab because of the strike

## Week 1 - Introduction to the course. Introduction to steering behaviours
- [Craig Reynolds original paper](https://www.red3d.com/cwr/papers/1999/gdc99steer.pdf)
- [Steering behaviours in Java](https://www.red3d.com/cwr/steer/)

