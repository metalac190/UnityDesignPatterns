using UnityEngine;

/// <summary>
/// Example of a command for the light. We assign a new color to the light, and change
/// it back when we're done.
/// </summary>
namespace Examples.Command
{
    public class LightColorChange : ICommand
    {
        Light _light;
        Color _originalColor;
        Color _newColor;

        public LightColorChange(Light light, Color newColor)
        {
            _light = light;
            _originalColor = light.color;
            _newColor = newColor;
        }

        public void Execute()
        {
            Debug.Log("Assigned new color: " + _newColor);
            _light.color = _newColor;
        }

        public void Undo()
        {
            Debug.Log("Undo: Assigned back to original color: " + _originalColor);
            _light.color = _originalColor;
        }
    }
}

