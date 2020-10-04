using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An example Command for our light that turns on and off the light component.
/// </summary>
namespace Examples.Command
{
    public class LightActiveToggle : ICommand
    {
        Light _light = null;

        public LightActiveToggle(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            Debug.Log("Toggle on/off state");
            _light.enabled = !_light.enabled;
        }

        public void Undo()
        {
            Debug.Log("Undo: toggle back to other state");
            _light.enabled = !_light.enabled;
        }
    }
}

