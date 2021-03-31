using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        // each source will correspond to a layer, and we'll control them together
        AudioSource[] _layerSources;
        int numOfLayers = 5;

        private void Awake()
        {
            CreateLayerSources();
        }

        void CreateLayerSources()
        {
            for (int i = 0; i < numOfLayers; i++)
            {
                _layerSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }
    }
}

