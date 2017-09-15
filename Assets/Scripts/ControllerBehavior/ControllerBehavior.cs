using System;
using UnityEngine;

public abstract class PlayerControllerBehavior : IControllerBehavior
{
    protected MonoBehaviour Player { get; private set; }
    public PlayerControllerBehavior(MonoBehaviour player)
    {
        Player = player;
    }

    public abstract void UpdateBehavior();
}
