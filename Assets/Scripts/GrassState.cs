using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrassState : StateInterface
{
    public void Do(Player player)
    {
        player.speed = 1.0f;
        player.gasConsumption = 3.0f;
    }
};