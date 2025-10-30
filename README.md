## CarGameChallenge

Right now, it doesn't really work. However, this is what I was going for:
 
#### Observer: 
- The player owns a stateTransitioner object that will listen to the actions on the player.
- these actions are OnTriggerAction, OnCollisionAction and OnUnTriggerAction.
- when an action is invoked, the stateTransitioner object will tell the player to transition states
- stateTransitioner is also the container for all of the states

#### States:
Different player car states...
- Normal, OnGrass, Crashed
- each state modifies the player's speed and gas consumption
