using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateTransitioner
{
    public Player OwnerPlayer;
    
    StateInterface normalState;
    StateInterface grassState;
    StateInterface collisionState;
    
    public void Initialize(Player owner)
    {
        normalState = new NormalState();
        grassState = new GrassState();
        OwnerPlayer = owner;
        owner.OnCollisionAction += OnPlayerCollided;
        owner.OnTrigerAction += OnPlayerTriggered;
        owner.OnUnTriggerAction += OnPlayerNormal;
    }
    
    void OnPlayerCollided()
    {
        OwnerPlayer.TransitionToState(collisionState);
        Debug.Log("Player collided");
    }

    void OnPlayerTriggered()
    {
        OwnerPlayer.TransitionToState(grassState);
        Debug.Log("Player triggered");
    }

    void OnPlayerNormal()
    {
        OwnerPlayer.TransitionToState(normalState);
        Debug.Log("Player normal");
    }
}
