using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Singleton
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] Light _sun = null;

        private void Update()
        {
            // Space - Begin day
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TimeOfDay.Instance.BeginDay(12, _sun);
            }
            // 1 - 6am
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TimeOfDay.Instance.SetTime(6);
            }
            // 2 - noon
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TimeOfDay.Instance.SetTime(12);
            }
            // 3 - 6pm
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TimeOfDay.Instance.SetTime(18);
            }
        }
    }
}

