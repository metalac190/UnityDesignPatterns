using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class will show how we can use a Lazy Singleton pattern on a MonoBehavior
/// to implement a Time of Day. We wouldn't really want Time of Day to exist more than
/// once in a scene, so it makes sense to make this a Singleton if several other things
/// need access.
/// </summary>
namespace Examples.Singleton
{
    public class TimeOfDay : MBSingleton<TimeOfDay>
    {
        // when this value is reached it loops back around to 0
        const float HOURS_PER_DAY = 24;
        // this offsets rotation to allow noon to be facing directly downwards
        float startOffsetRotationAmount = -90;

        public bool IsTimeActive { get; private set; }
        // time will be tracked with 1 unit for each hour
        private float _currentHour = 0;
        public float CurrentHour
        {
            get => _currentHour;
            private set
            {
                value = Mathf.Clamp(value, 0, HOURS_PER_DAY);
                _currentHour = value;
            }
        }

        Light _sun = null;

        private void Update()
        {
            if (IsTimeActive)
            {
                PassTime();
                UpdateSunRotation();
            }
        }

        public void BeginDay(float startTime, Light sun)
        {
            CurrentHour = startTime;
            SetTimeActive(true);
            _sun = sun;
        }

        public void SetTimeActive(bool isActive)
        {
            IsTimeActive = isActive;
        }

        public void SetTime(float newTime)
        {
            CurrentHour = newTime;
        }

        void UpdateSunRotation()
        {
            // new rotation increment
            //float dayDuration = HOUR_LENGTH_IN_SECONDS * HOURS_PER_DAY;
            //float newSunRotation = (CurrentHour / HOURS_PER_DAY) * 360.0f;
            float rotateAmount = startOffsetRotationAmount + ((CurrentHour / HOURS_PER_DAY) * 360.0f);
            Vector3 newSunRotation = new Vector3(rotateAmount, 0, 0);
            _sun.transform.rotation = Quaternion.Euler(newSunRotation);
        }

        void PassTime()
        {
            _currentHour += Time.deltaTime;
            // loop back around if we hit the end of the day
            if(_currentHour >= HOURS_PER_DAY)
            {
                _currentHour = 0;
            }
            Debug.Log("Current Time: " + _currentHour);
        }
    }
}

