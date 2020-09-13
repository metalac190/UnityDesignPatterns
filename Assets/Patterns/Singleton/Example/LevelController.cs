using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class performs actions on the level for testing.
/// In this case we're telling the MusicPlayer to play different tracks
/// </summary>
namespace Examples.Singleton
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] AudioClip _explorationMusic = null;
        [SerializeField] AudioClip _combatMusic = null;

        private void Update()
        {
            // 1 - Begin playing music track
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                MusicPlayer.Instance.PlayNewSong(_explorationMusic);
            }
            // 2 - Play Combat music track
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                MusicPlayer.Instance.PlayNewSong(_combatMusic);
            }
        }
    }
}

