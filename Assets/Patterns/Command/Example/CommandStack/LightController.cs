using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to test our Command Stack functionality.
/// You can use key inputs to execute commands through the Command Stack
/// Command Stack tracks history, so Undo button will undo our last command
/// </summary>
namespace Examples.Command
{
    public class LightController : MonoBehaviour
    {
        // light in the scene to send commands to
        [SerializeField] Light _light = null;

        [Header("Inputs")]
        [SerializeField] KeyCode _toggleKey = KeyCode.Alpha1;
        [SerializeField] KeyCode _increaseIntensityKey = KeyCode.Alpha2;
        [SerializeField] KeyCode _decreaseIntensityKey = KeyCode.Alpha3;
        [SerializeField] KeyCode _randomColorKey = KeyCode.Alpha4;
        [SerializeField] KeyCode _undoCommandKey = KeyCode.Z;

        CommandStack _commandStack = new CommandStack();

        private void Update()
        {
            DetectToggleInput();
            DetectIncreaseIntensityInput();
            DetectDecreaseIntensityInput();
            DetectRandomColorInput();

            DetectUndoInput();
        }

        private void DetectToggleInput()
        {
            if (Input.GetKeyDown(_toggleKey))
            {
                _commandStack.ExecuteCommand
                    (new LightActiveToggle(_light));
            }
        }

        private void DetectIncreaseIntensityInput()
        {
            if (Input.GetKeyDown(_increaseIntensityKey))
            {
                _commandStack.ExecuteCommand
                    (new LightIncreaseIntensity(_light));
            }
        }

        private void DetectDecreaseIntensityInput()
        {
            if (Input.GetKeyDown(_decreaseIntensityKey))
            {
                _commandStack.ExecuteCommand
                    (new LightDecreaseIntensity(_light));
            }
        }

        private void DetectRandomColorInput()
        {
            if (Input.GetKeyDown(_randomColorKey))
            {
                Color randomColor = ColorCreator.CreateRandomColor();
                _commandStack.ExecuteCommand
                    (new LightColorChange(_light, randomColor));
            }
        }

        private void DetectUndoInput()
        {
            if (Input.GetKeyDown(_undoCommandKey))
            {
                // undo previous action
                _commandStack.UndoLastCommand();
            }
        }
    }
}

