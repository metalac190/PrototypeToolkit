using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.MainMenu
{
    public class MainMenuCreditsState : State
    {
        MainMenuSM _stateMachine;
        CreditsMenu _creditsMenu;

        public MainMenuCreditsState(MainMenuSM stateMachine)
        {
            _stateMachine = stateMachine;
            _creditsMenu = stateMachine.UI.CreditsMenu;
        }

        public override void Enter()
        {
            _creditsMenu.Open();
            _creditsMenu.BackButton.onClick.AddListener(OnBackClicked);
        }

        public override void Exit()
        {
            _creditsMenu.Close();
            _creditsMenu.BackButton.onClick.RemoveListener(OnBackClicked);
        }

        void OnBackClicked()
        {
            _stateMachine.ChangeState(_stateMachine.RootState);
        }
    }
}

