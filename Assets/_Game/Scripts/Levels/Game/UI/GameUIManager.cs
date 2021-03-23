using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameUIManager : UIManager
    {
        [SerializeField] private GameMenu _gameMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private WinMenu _winMenu;
        [SerializeField] private LoseMenu _loseMenu;

        public GameMenu GameMenu => _gameMenu;
        public PauseMenu PauseMenu => _pauseMenu;
        public WinMenu WinMenu => _winMenu;
        public LoseMenu LoseMenu => _loseMenu;

        public override void InitializeMenus()
        {
            _gameMenu.CloseImmediate();
            _pauseMenu.CloseImmediate();
            _winMenu.CloseImmediate();
            _loseMenu.CloseImmediate();
        }
    }
}

