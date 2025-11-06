## CarGameChallenge

Controls: move with WASD

#### Dirty Flag
- The dirty flag controls when the player's movement gets calculated.
- In the following peice of code, the dirty flag is labelled "isMoving"
- This way of handling movement is awesome because it uses a listener (the unity input system) to essentially toggle the update function. Its great.
```
actions.Player.Move.performed += context =>
{
    isMoving = true; 
    input = context.ReadValue<Vector2>();
};

actions.Player.Move.canceled += context =>
{
    isMoving = false;
};

private void Update()
{
    if (!isMoving) return;
    
    transform.position += input * (Time.deltaTime * speed);
}
```

#### Object Pool
- An object pool is used to spawn the other cars on the road. This is a no-brainer use case because there are always new cars coming through with short lifespans. Cars start at the top of the screen, move down, and thats it. An object pool allows me to recycle the cars.
- On start, it instantiates a predefined amount of cars and disables them.
```
for(int i = 0; i < qty; i++)
{
    // new car
    pool.Add(tmp);
}
```
- When a car is needed, the program checks for any disabled cars. If none are available, return null.
```
foreach (car)
{
    if (!car.activeInHierarchy)
    {
        // reset the car
        return car;
    }
}
return null;
```


#### Observer: 
- The player owns a stateTransitioner object that will listen to the actions on the player.
- these actions are OnTriggerAction, OnCollisionAction and OnUnTriggerAction.
- when an action is invoked, the stateTransitioner object will tell the player to transition states
- stateTransitioner is also the container for all of the states

#### States:
Different player car states...
- Normal, OnGrass, Crashed
- each state modifies the player's speed and gas consumption
