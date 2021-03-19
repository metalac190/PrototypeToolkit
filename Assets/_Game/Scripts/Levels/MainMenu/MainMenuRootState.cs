using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRootState : State
{
    MainMenuSM _stateMachine;

    public MainMenuRootState(MainMenuSM stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
