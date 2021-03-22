using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.MainMenu
{
    public class MainMenuSettingsState : State
    {
        MainMenuSM _stateMachine;
        SettingsMenu _settingsMenu;

        public MainMenuSettingsState(MainMenuSM stateMachine)
        {
            _stateMachine = stateMachine;
            _settingsMenu = stateMachine.UI.SettingsMenu;
        }


        public override void Enter()
        {
            _settingsMenu.Open();
            _settingsMenu.BackButton.onClick.AddListener(OnBackClicked);
        }

        public override void Exit()
        {
            _settingsMenu.Close();
            _settingsMenu.BackButton.onClick.RemoveListener(OnBackClicked);
        }

        void OnBackClicked()
        {
            _stateMachine.ChangeState(_stateMachine.RootState);
        }
    }
}

