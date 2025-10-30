using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class NormalState : StateInterface
{
    public void Do(Player player)
    {
        player.speed = 5.0f;
        player.gasConsumption = 1.0f;
    }
};