using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement;

namespace Levels.MainMenu
{
    public class SettingsMenu : Menu
    {
        [SerializeField] Slider _masterVolumeSlider;
        [SerializeField] Slider _musicVolumeSlider;
        [SerializeField] Slider _sfxVolumeSlider;
        [SerializeField] Button _backButton;

        public Button BackButton => _backButton;

        private void OnEnable()
        {
            LoadData();
        }

        private void OnDisable()
        {
            SaveData();
        }

        void LoadData()
        {

        }

        void SaveData()
        {

        }
    }
}

