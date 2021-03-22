using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.MainMenu
{
    public class LevelSelectMenu : Menu
    {
        [SerializeField] Button _playButton;
        [SerializeField] Button _backButton;

        public Button PlayButton => _playButton;
        public Button BackButton => _backButton;
    }
}

