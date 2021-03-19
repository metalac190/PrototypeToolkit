using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLevelSelectState : State
{
    MainMenuSM _statemachine;

    public MainMenuLevelSelectState(MainMenuSM statemachine)
    {
        _statemachine = statemachine;
    }
}
