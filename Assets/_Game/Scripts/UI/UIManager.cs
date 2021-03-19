using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public abstract class UIManager : MonoBehaviour
    {
        public abstract void CloseAllMenus();

        private void Start()
        {
            // all menus should start disabled, and activated as needed
            CloseAllMenus();
        }
    }
}

