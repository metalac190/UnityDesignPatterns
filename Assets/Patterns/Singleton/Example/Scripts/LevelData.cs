using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Scriptable Object definitiation outlines the skeleton of a LevelData instance.
/// We can store all of our data in this asset as an instance, that way we don't need to rely on
/// Singletons just for data management.
/// </summary>
namespace Examples.Singleton
{
    [CreateAssetMenu(menuName = "Singleton/LevelData", fileName = "NewLevelData")]
    public class LevelData : ScriptableObject
    {
        public string LevelName { get; set; } = "...";
        public int LevelDifficulty { get; set; } = 0;
        public int Money { get; set; } = 0;
    }
}


