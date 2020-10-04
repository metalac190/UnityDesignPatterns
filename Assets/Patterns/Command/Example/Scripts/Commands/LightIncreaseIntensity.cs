using UnityEngine;

/// <summary>
/// Example of a Command for our Light. We increase the intensity, and on Undo, we revert our increase.
/// </summary>
namespace Examples.Command
{
    public class LightIncreaseIntensity : ICommand
    {
        float _increaseAmount = .1f;
        Light _light;

        public LightIncreaseIntensity(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            Debug.Log("Increase Intensity by: " + _increaseAmount);
            _light.intensity += _increaseAmount;
        }

        public void Undo()
        {
            Debug.Log("Undo: Increase Intensity by: " + _increaseAmount);
            _light.intensity -= _increaseAmount;
        }
    }
}

