using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this state we just want to wait for a length of time, then transition back to idle
/// Because IState is not inheriting from MonoBehaviour, we don't have access to Coroutines
/// This means that we're going to have to implement our own simple timer system.
/// </summary>

namespace Examples.State
{
    public class SearchBotFoundState : IState
    {
        SearchBotSM _searchBotSM;

        Material _eyeMat;
        Color _startingEyeColor;
        Color _foundEyeColor = Color.green;

        AudioClip _foundSound;
        AudioSource _audioSource;

        // how long to wait for our 'Found' state
        float _foundDelayDuration = 1.5f;
        float _elapsedTime = 0;
        bool _timerActive = false;

        public SearchBotFoundState(SearchBotSM searchBotSM, Material eyeMat,
            AudioClip foundSound, AudioSource audioSource)
        {
            _searchBotSM = searchBotSM;
            _eyeMat = eyeMat;
            _foundSound = foundSound;
            _audioSource = audioSource;
        }

        public void Enter()
        {
            Debug.Log("STATE CHANGE - Found");

            // store starting eye color so we can return to it
            _startingEyeColor = _eyeMat.color;
            // show 'found' visual
            _eyeMat.color = _foundEyeColor;
            // play sound effect
            _audioSource.clip = _foundSound;
            _audioSource.Play();
            // start our delay to pause before going back to idle
            StartTimer();
        }

        public void Exit()
        {
            // stop 'found' visual
            _eyeMat.color = _startingEyeColor;
        }

        public void FixedTick()
        {
            //
        }

        public void Tick()
        {
            // if timer is active, increment time
            if (_timerActive)
            {
                _elapsedTime += Time.deltaTime;
            }

            // if our elapsed time has met our required duration, then go back to Idle
            if (_elapsedTime > _foundDelayDuration)
            {
                StopTimer();
                _searchBotSM.ChangeState(_searchBotSM.IdleState);
            }
        }

        void StartTimer()
        {
            _timerActive = true;
            _elapsedTime = 0;
        }

        void StopTimer()
        {
            _timerActive = false;
        }
    }
}

