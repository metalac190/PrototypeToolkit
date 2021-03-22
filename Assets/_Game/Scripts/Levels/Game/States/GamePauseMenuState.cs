using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GamePauseMenuState : State
    {
        GameSM _stateMachine;
        PauseMenu _pauseMenu;

        bool _shouldPauseTime = true;
        const string _mainMenuLevelName = "MainMenu";

        public GamePauseMenuState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
            _pauseMenu = stateMachine.UI.PauseMenu;
        }

        public override void Enter()
        {
            Debug.Log("STATE: Pause Menu");
            _pauseMenu.Open();

            _pauseMenu.ResumeButton.onClick.AddListener(OnResumeClicked);
            _pauseMenu.SettingsButton.onClick.AddListener(OnSettingsClicked);
            _pauseMenu.QuitButton.onClick.AddListener(OnQuitClicked);

            if (_shouldPauseTime)
            {
                Time.timeScale = 0;
            }
        }

        public override void Exit()
        {
            _pauseMenu.Close();

            _pauseMenu.ResumeButton.onClick.RemoveListener(OnResumeClicked);
            _pauseMenu.SettingsButton.onClick.RemoveListener(OnSettingsClicked);
            _pauseMenu.QuitButton.onClick.RemoveListener(OnQuitClicked);

            if (_shouldPauseTime)
            {
                Time.timeScale = 1;
            }
        }

        void OnResumeClicked()
        {
            _stateMachine.ChangeStateToPrevious();
        }

        void OnSettingsClicked()
        {
            // settings state
        }

        void OnQuitClicked()
        {
            LevelLoader.LoadLevel(_mainMenuLevelName);
        }
    }
}

