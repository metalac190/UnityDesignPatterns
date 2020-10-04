using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class shows how you can easily inherit from our reusable SingletonMB class to
/// add Singleton behavior, but extend its functionality as needed. Very few lines of code!
/// </summary>
namespace Examples.Singleton
{
    public class MusicPlayer : SingletonMB<MusicPlayer>
    {
        AudioSource _audioSource;

        void Awake()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.loop = true;
        }

        public void PlayNewSong(AudioClip newSong)
        {
            if (newSong == null) return;    //guard clause

            _audioSource.clip = newSong;
            _audioSource.Play();
        }
    }
}

