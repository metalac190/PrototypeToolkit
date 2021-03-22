using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameSM : StateMachineMB
    {
        [SerializeField] GameUIManager _gameUIManager;

        public GameUIManager UI => _gameUIManager;

        public GameSetupState SetupState { get; private set; }
        public GamePlayingState PlayingState { get; private set; }
        public GamePauseMenuState PauseMenuState { get; private set; }
        public GameWinState WinState { get; private set; }
        public GameLoseState LoseState { get; private set; }

        private void Awake()
        {
            // states
            SetupState = new GameSetupState(this);
            PlayingState = new GamePlayingState(this);
            PauseMenuState = new GamePauseMenuState(this);
            WinState = new GameWinState(this);
            LoseState = new GameLoseState(this);
        }

        private void Start()
        {
            ChangeState(SetupState);
        }
    }
}

