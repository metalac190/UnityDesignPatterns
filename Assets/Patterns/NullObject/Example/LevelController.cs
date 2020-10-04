using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the majority of the level functionality and input. This script allows us to test our
/// system and equipping functionality.
/// </summary>
namespace Examples.NullObject
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] CharacterStats _stats = null;
        [SerializeField] PlayerActions _playerActions = null;

        IEquippable _weaponToTest;
        IEquippable _helmetToTest;

        private void Awake()
        {
            // create the weapons we want to assign and test
            _weaponToTest = new SwordOfSwinging(_stats);
            _helmetToTest = new FeatheryHat(_stats);
        }

        void Update()
        {
            // BACKSPACE pressed
            if (Input.GetKey(KeyCode.Backspace))
            {
                _stats.UnequipAll();
            }
            // 1 pressed
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _stats.EquipWeapon(_weaponToTest);
            }
            // 2 pressed
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _stats.EquipHelmet(_helmetToTest);
            }
            // Q pressed
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Character Stats: " +
                    " Attack: " + _stats.Attack +
                    " Defense: " + _stats.Defense +
                    " MoveSpeed: " + _stats.MoveSpeed);
            }
            // SPACE pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerActions.Attack();
            }
        }
    }
}

