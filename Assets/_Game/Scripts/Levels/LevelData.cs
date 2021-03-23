using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/LevelData", fileName = "LevelData_")]
public class LevelData : ScriptableObject
{
    [SerializeField] int _buildIndex = 1;

    public int BuildIndex => _buildIndex;
}
