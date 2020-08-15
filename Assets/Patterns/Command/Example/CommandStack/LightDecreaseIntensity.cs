using UnityEngine;

namespace Examples.Command 
{
    public class LightDecreaseIntensity : ICommand
    {
        float _decreaseAmount = .1f;
        Light _light;

        public LightDecreaseIntensity(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            Debug.Log("Decrease intensity by: " + _decreaseAmount);
            _light.intensity -= _decreaseAmount;
        }

        public void Undo()
        {
            Debug.Log("Undo: Decrease Intensity by: " + _decreaseAmount);
            _light.intensity += _decreaseAmount;
        }
    }
}

