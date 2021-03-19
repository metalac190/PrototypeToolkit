using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettingsState : State
{
    MainMenuSM _stateMachine;

    public MainMenuSettingsState(MainMenuSM stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
