using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCreditsState : State
{
    MainMenuSM _stateMachine;

    public MainMenuCreditsState(MainMenuSM stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
