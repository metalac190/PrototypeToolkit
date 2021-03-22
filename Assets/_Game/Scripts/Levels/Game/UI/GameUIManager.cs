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
            _gameMenu.Canvas.gameObject.SetActive(false);
            _pauseMenu.Canvas.gameObject.SetActive(false);
            _winMenu.Canvas.gameObject.SetActive(false);
            _loseMenu.Canvas.gameObject.SetActive(false);
        }

    }
}

