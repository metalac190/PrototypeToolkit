using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.MainMenu
{
    public class CreditsMenu : Menu
    {
        [SerializeField] Button _backButton;

        public Button BackButton => _backButton;
    }
}
