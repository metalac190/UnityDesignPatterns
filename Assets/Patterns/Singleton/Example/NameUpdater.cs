using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class access the Level Data to change and display the name
/// </summary>
namespace Examples.Singleton
{
    public class NameUpdater : MonoBehaviour
    {
        [SerializeField] LevelData _levelData = null;
        [SerializeField] string _levelName = "Boggy Swamp";
        [SerializeField] Text _levelNameView = null;

        private void Awake()
        {
            _levelData.LevelName = _levelName;
            // pull level name from the level data
            _levelNameView.text = _levelData.LevelName;
        }
    }
}

