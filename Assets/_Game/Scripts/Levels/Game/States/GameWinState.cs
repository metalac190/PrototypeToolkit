using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameWinState : State
    {
        GameSM _stateMachine;

        public GameWinState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            Debug.Log("STATE: Win");
        }

        public override void Exit()
        {

        }
    }
}

