using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class changes and stores difficulty data on our LevelData instance
/// </summary>
namespace Examples.Singleton
{
    public class DifficultyIncreaser : MonoBehaviour
    {
        [SerializeField] LevelData _levelData = null;
        [SerializeField] Text _difficultyTextView = null;

        private void Awake()
        {
            _levelData.LevelDifficulty = 0;
            _difficultyTextView.text = _levelData.LevelDifficulty.ToString();
        }

        private void Update()
        {
            // Q - Increase Difficulty
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _levelData.LevelDifficulty += 1;
                // update UI with new Level Data
                _difficultyTextView.text = _levelData.LevelDifficulty.ToString();
            }
        }
    }
}

