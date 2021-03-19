using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class GameUIManager : UIManager
    {
        [SerializeField] private GameMenu _gameMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private WinScreen _winMenu;

        public override void CloseAllMenus()
        {
            _gameMenu.gameObject.SetActive(false);
            _pauseMenu.gameObject.SetActive(false);
            _winMenu.gameObject.SetActive(false);
        }
    }
}

