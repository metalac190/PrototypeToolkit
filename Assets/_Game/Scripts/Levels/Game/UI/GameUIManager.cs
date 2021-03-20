using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.Game
{
    public class GameUIManager : UIManager
    {
        [SerializeField] private GameMenu _gameMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private WinScreen _winMenu;

        public override void InitializeMenus()
        {
            _gameMenu.Canvas.gameObject.SetActive(false);
            _pauseMenu.Canvas.gameObject.SetActive(false);
            _winMenu.Canvas.gameObject.SetActive(false);
        }

    }
}

