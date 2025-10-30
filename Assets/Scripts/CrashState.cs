using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class CrashState : StateInterface
{
    public void Do(Player player)
    {
        player.speed = 0.0f;
        player.gasConsumption = 100.0f;
    }
};