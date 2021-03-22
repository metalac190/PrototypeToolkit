using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public abstract class SingletonMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed.
        private static bool _shuttingDown = false;
        private static object _lock = new object();

        private static T _instance;
        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_shuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                        "' already destroyed. Returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        // Search for existing instance.
                        _instance = (T)FindObjectOfType(typeof(T));
                        // Create new instance if one doesn't already exist.
                        if (_instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject(typeof(T).ToString() + " (Singleton)");
                            _instance = singletonObject.AddComponent<T>();

                            // Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            _shuttingDown = true;
        }

        private void OnDestroy()
        {
            _shuttingDown = true;
        }

    }
}

