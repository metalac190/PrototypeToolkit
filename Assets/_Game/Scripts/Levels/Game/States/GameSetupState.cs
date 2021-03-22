using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameSetupState : State
    {
        GameSM _stateMachine;

        public GameSetupState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
            
        }

        public override void Enter()
        {
            Debug.Log("STATE: Setup");
            // load data
            // setup scene
            // spawn player
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
            // time to play
            _stateMachine.ChangeState(_stateMachine.PlayingState);
        }
    }
}

