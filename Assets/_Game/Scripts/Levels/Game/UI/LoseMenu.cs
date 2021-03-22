using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.Game
{
    public class LoseMenu : Menu
    {
        [SerializeField] Button _retryButton;
        [SerializeField] Button _quitButton;

        public Button RetryButton => _retryButton;
        public Button QuitButton => _quitButton;
    }
}

