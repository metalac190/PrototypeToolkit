using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.MainMenu
{
    public class MainMenuCreditsState : State
    {
        MainMenuSM _stateMachine;

        public MainMenuCreditsState(MainMenuSM stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}
