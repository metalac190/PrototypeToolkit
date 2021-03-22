using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels.MainMenu
{
    public class MainMenuSM : StateMachineMB
    {
        [SerializeField] MainMenuUIManager _uIManager;
        // input
        // audio
        // data

        public MainMenuUIManager UI => _uIManager;

        // states
        public MainMenuRootState RootState { get; private set; }
        public MainMenuCreditsState CreditsState { get; private set; }
        public MainMenuSettingsState SettingsState { get; private set; }
        public MainMenuLevelSelectState LevelSelectState { get; private set; }

        private void Awake()
        {
            // initialize states
            RootState = new MainMenuRootState(this);
            CreditsState = new MainMenuCreditsState(this);
            SettingsState = new MainMenuSettingsState(this);
            LevelSelectState = new MainMenuLevelSelectState(this);
        }

        private void Start()
        {
            ChangeState(RootState);
        }
    }

}
