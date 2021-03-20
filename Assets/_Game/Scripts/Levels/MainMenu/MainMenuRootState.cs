using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Levels.MainMenu;

namespace Levels.MainMenu
{
    public class MainMenuRootState : State
    {
        MainMenuSM _stateMachine;
        RootMenu _rootMenu;

        public MainMenuRootState(MainMenuSM stateMachine)
        {
            _stateMachine = stateMachine;
            _rootMenu = stateMachine.UI.RootMenu;
        }

        public override void Enter()
        {
            _rootMenu.PlayButton.onClick.AddListener(OnPlayClicked);
            _rootMenu.Open();
        }

        public override void Exit()
        {
            _rootMenu.PlayButton.onClick.RemoveListener(OnPlayClicked);
            _rootMenu.Close();
        }

        void OnPlayClicked()
        {
            _stateMachine.ChangeState(_stateMachine.LevelSelectState);
        }
    }
}

