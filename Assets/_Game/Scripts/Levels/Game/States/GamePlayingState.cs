using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GamePlayingState : State
    {
        GameSM _stateMachine;
        GameMenu _gameMenu;

        public GamePlayingState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
            _gameMenu = stateMachine.UI.GameMenu;
        }

        public override void Enter()
        {
            Debug.Log("STATE: Playing");
            _gameMenu.Open();
            _gameMenu.MenuButton.onClick.AddListener(OnMenuClicked);
        }

        public override void Exit()
        {
            _gameMenu.Close();
            _gameMenu.MenuButton.onClick.RemoveListener(OnMenuClicked);
        }

        public override void Update()
        {

        }

        public override void FixedUpdate()
        {
            
        }

        void OnMenuClicked()
        {
            _stateMachine.ChangeState(_stateMachine.PauseMenuState);
        }
    }
}

