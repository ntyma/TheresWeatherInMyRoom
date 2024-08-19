using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldState
{
    public abstract void EnterState();

    public abstract void ExitState();

    public abstract void IdleState();
}
