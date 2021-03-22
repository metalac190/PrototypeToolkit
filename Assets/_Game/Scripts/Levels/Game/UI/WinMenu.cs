using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.Game
{
    public class WinMenu : Menu
    {
        [SerializeField] Button _continueButton;
        [SerializeField] Button _quitButton;

        public Button ContinueButton => _continueButton;
        public Button QuitButton => _quitButton;
    }
}

