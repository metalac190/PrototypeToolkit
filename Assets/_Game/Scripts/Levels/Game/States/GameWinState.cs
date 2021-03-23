using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameWinState : State
    {
        GameSM _stateMachine;
        WinMenu _winMenu;

        string _mainMenuLevelName = "MainMenu";

        public GameWinState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
            _winMenu = stateMachine.UI.WinMenu;
        }

        public override void Enter()
        {
            Debug.Log("STATE: Win");
            _winMenu.Open();
            _winMenu.ContinueButton.onClick.AddListener(OnContinueClicked);
            _winMenu.RetryButton.onClick.AddListener(OnRetryClicked);
            _winMenu.QuitButton.onClick.AddListener(OnQuitClicked);
        }

        public override void Exit()
        {
            _winMenu.Close();
            _winMenu.ContinueButton.onClick.RemoveListener(OnContinueClicked);
            _winMenu.RetryButton.onClick.RemoveListener(OnRetryClicked);
            _winMenu.QuitButton.onClick.RemoveListener(OnQuitClicked);
        }

        void OnContinueClicked()
        {
            // optional load next level here instead of returning to main menu
            LevelLoader.LoadLevel(_mainMenuLevelName);
        }

        void OnRetryClicked()
        {
            LevelLoader.ReloadLevel();
        }

        void OnQuitClicked()
        {
            LevelLoader.LoadLevel(_mainMenuLevelName);
        }
    }
}

