using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameLoseState : State
    {
        GameSM _stateMachine;

        public GameLoseState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            Debug.Log("STATE: Lose");
        }

        public override void Exit()
        {

        }
    }
}

