using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Command
{
    public static class ColorCreator
    {
        public static Color CreateRandomColor()
        {
            // unity colors are 0 - 1, instead of 0 - 255
            float randomR = UnityEngine.Random.Range(0, 1f);
            float randomG = UnityEngine.Random.Range(0, 1f);
            float randomB = UnityEngine.Random.Range(0, 1f);
            // alpha default is 0, we need 1 to be opaque
            Color newColor = new Color(randomR, randomG, randomB, 1);

            return newColor;
        }
    }
}


