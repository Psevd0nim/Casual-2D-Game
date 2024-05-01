using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    private const string soundVolumeKey = "Sound";

    public static float GetSoundVolume() { return PlayerPrefs.GetFloat(soundVolumeKey, 1); }

    public static void SetSoundVolume(float soundVolume) { PlayerPrefs.SetFloat(soundVolumeKey, soundVolume); }
}