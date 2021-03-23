using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameLoseState : State
    {
        GameSM _stateMachine;
        LoseMenu _loseMenu;

        string _mainMenuLevelName = "MainMenu";

        public GameLoseState(GameSM stateMachine)
        {
            _stateMachine = stateMachine;
            _loseMenu = stateMachine.UI.LoseMenu;
        }

        public override void Enter()
        {
            Debug.Log("STATE: Lose");
            _loseMenu.Open();
            _loseMenu.RetryButton.onClick.AddListener(OnRetryClicked);
            _loseMenu.QuitButton.onClick.AddListener(OnQuitClicked);
        }

        public override void Exit()
        {
            _loseMenu.Close();
            _loseMenu.RetryButton.onClick.RemoveListener(OnRetryClicked);
            _loseMenu.QuitButton.onClick.RemoveListener(OnQuitClicked);
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

