using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;

public class MainMenuUIManager : UIManager
{
    [SerializeField] private RootMenu _rootMenu;
    [SerializeField] private SettingsMenu _settingsMenu;
    [SerializeField] private CreditsMenu _creditsMenu;
    [SerializeField] private ModeSelectMenu _levelSelectMenu;

    public RootMenu RootMenu => _rootMenu;
    public SettingsMenu SettingsMenu => _settingsMenu;
    public CreditsMenu CreditsMenu => _creditsMenu;
    public ModeSelectMenu LevelSelectMenu => _levelSelectMenu;

    public override void CloseAllMenus()
    {
        _rootMenu.gameObject.SetActive(false);
        _settingsMenu.gameObject.SetActive(false);
        _creditsMenu.gameObject.SetActive(false);
        _levelSelectMenu.gameObject.SetActive(false);
    }
}

