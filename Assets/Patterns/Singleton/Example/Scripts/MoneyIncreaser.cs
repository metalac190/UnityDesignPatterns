using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class accesses the Level Data Scriptable Object instance to change and store money
/// </summary>
namespace Examples.Singleton
{
    public class MoneyIncreaser : MonoBehaviour
    {
        [SerializeField] LevelData _levelData = null;
        [SerializeField] int _increaseAmount = 150;
        [SerializeField] Text _moneyTextView = null;

        private void Awake()
        {
            _levelData.Money = 0;
            // load level data money into UI
            _moneyTextView.text = _levelData.Money.ToString();
        }

        private void Update()
        {
            // W - Add money
            if (Input.GetKeyDown(KeyCode.W))
            {
                _levelData.Money += _increaseAmount;
                // put level data into the UI
                _moneyTextView.text = _levelData.Money.ToString();
            }
        }
    }
}

