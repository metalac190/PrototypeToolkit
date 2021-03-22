using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.MainMenu
{
    public class MainMenuLevelSelectState : State
    {
        MainMenuSM _statemachine;
        LevelSelectMenu _levelSelectMenu;

        string _levelLoadName = "Game";

        public MainMenuLevelSelectState(MainMenuSM statemachine)
        {
            _statemachine = statemachine;
            _levelSelectMenu = statemachine.UI.LevelSelectMenu;
        }

        public override void Enter()
        {
            _levelSelectMenu.Open();
            _levelSelectMenu.PlayButton.onClick.AddListener(OnPlayClicked);
            _levelSelectMenu.BackButton.onClick.AddListener(OnBackClicked);
        }

        public override void Exit()
        {
            _levelSelectMenu.Close();
            _levelSelectMenu.PlayButton.onClick.RemoveListener(OnPlayClicked);
            _levelSelectMenu.BackButton.onClick.RemoveListener(OnBackClicked);
        }

        void OnPlayClicked()
        {
            //TODO determine level name later
            LevelLoader.LoadLevel(_levelLoadName);
        }

        void OnBackClicked()
        {
            _statemachine.ChangeState(_statemachine.RootState);
        }
    }
}

