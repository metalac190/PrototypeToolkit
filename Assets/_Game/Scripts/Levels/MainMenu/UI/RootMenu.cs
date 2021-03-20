using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.MainMenu
{
    public class RootMenu : Menu
    {
        [SerializeField] Button _playButton;
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _creditsButton;
        [SerializeField] Button _quitButton;

        public Button PlayButton => _playButton;
        public Button SettingsButton => _settingsButton;
        public Button CreditsButton => _creditsButton;
        public Button QuitButton => _quitButton;
    }
}

