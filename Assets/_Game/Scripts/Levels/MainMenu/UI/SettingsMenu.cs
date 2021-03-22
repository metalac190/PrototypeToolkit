using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.MainMenu
{
    public class SettingsMenu : Menu
    {
        [SerializeField] Slider _masterVolumeSlider;
        [SerializeField] Slider _musicVolumeSlider;
        [SerializeField] Slider _sfxVolumeSlider;
        [SerializeField] Button _backButton;

        public Button BackButton => _backButton;
    }
}

