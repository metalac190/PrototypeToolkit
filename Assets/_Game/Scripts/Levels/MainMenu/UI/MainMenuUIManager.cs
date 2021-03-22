using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Levels.MainMenu
{
    public class MainMenuUIManager : UIManager
    {
        [SerializeField] private RootMenu _rootMenu;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] private CreditsMenu _creditsMenu;
        [SerializeField] private LevelSelectMenu _levelSelectMenu;

        public RootMenu RootMenu => _rootMenu;
        public SettingsMenu SettingsMenu => _settingsMenu;
        public CreditsMenu CreditsMenu => _creditsMenu;
        public LevelSelectMenu LevelSelectMenu => _levelSelectMenu;

        public override void InitializeMenus()
        {
            _rootMenu.Canvas.gameObject.SetActive(false);
            _settingsMenu.Canvas.gameObject.SetActive(false);
            _creditsMenu.Canvas.gameObject.SetActive(false);
            _levelSelectMenu.Canvas.gameObject.SetActive(false);
        }
    }
}


