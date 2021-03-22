using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.Game
{
    public class GameMenu : Menu
    {
        [SerializeField] Button _menuButton;

        public Button MenuButton => _menuButton;
    }
}

