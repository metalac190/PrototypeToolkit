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
            _rootMenu.Open();

            _rootMenu.PlayButton.onClick.AddListener(OnPlayClicked);
            _rootMenu.SettingsButton.onClick.AddListener(OnSettingsClicked);
            _rootMenu.CreditsButton.onClick.AddListener(OnCreditsClicked);
            _rootMenu.QuitButton.onClick.AddListener(OnQuitClicked);
        }

        public override void Exit()
        {
            _rootMenu.Close();

            _rootMenu.PlayButton.onClick.RemoveListener(OnPlayClicked);
            _rootMenu.SettingsButton.onClick.RemoveListener(OnSettingsClicked);
            _rootMenu.CreditsButton.onClick.RemoveListener(OnCreditsClicked);
            _rootMenu.QuitButton.onClick.RemoveListener(OnQuitClicked);
        }

        void OnPlayClicked()
        {
            _stateMachine.ChangeState(_stateMachine.LevelSelectState);
        }

        void OnSettingsClicked()
        {
            _stateMachine.ChangeState(_stateMachine.SettingsState);
        }

        void OnCreditsClicked()
        {
            _stateMachine.ChangeState(_stateMachine.CreditsState);
        }

        void OnQuitClicked()
        {
            Application.Quit();
        }
    }
}

