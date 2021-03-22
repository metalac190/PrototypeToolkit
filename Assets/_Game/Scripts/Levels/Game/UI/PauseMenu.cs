using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.Game
{
    public class PauseMenu : Menu
    {
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _quitButton;

        public Button ResumeButton => _resumeButton;
        public Button SettingsButton => _settingsButton;
        public Button QuitButton => _quitButton;
    }
}