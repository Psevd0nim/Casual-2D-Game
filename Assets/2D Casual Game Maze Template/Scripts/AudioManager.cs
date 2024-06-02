using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeTemplate
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip soundOne;

        private void Start()
        {
            instance = this;
            instance.audioSource = audioSource;
        }

        public void PlayFirstSound()
        {
            instance.audioSource.PlayOneShot(soundOne, 0.5f);
        }
    }
}