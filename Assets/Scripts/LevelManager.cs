using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Object[] levels;
    public void SelectLevel(int levelNumber)
    {
        Instantiate(levels[levelNumber - 1]);
        gameObject.SetActive(false);
    }
}