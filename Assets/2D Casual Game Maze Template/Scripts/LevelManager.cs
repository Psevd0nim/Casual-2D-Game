using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeTemplate
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;
        [SerializeField] private GameObject levelsMenu;
        [SerializeField] private GameObject gameplayPanel;
        private GameObject currentLevelPrefab;
        private int currentLevelNumber;

        public void SelectLevel(int levelNumber)
        {
            if (levelNumber - 1 > levels.Length)
            {
                Debug.Log("You are trying out of bounds array of current exist levels");
                return;
            }
            currentLevelNumber = levelNumber - 1;
            currentLevelPrefab = Instantiate(levels[currentLevelNumber]);
            levelsMenu.SetActive(false);
            gameplayPanel.SetActive(true);
        }

        public void NextLevel()
        {
            Destroy(currentLevelPrefab);
            currentLevelNumber++;
            if (currentLevelNumber >= levels.Length)
            {
                currentLevelNumber = 0;
            }
            currentLevelPrefab = Instantiate(levels[currentLevelNumber]);
            gameplayPanel.GetComponent<GameplayUI>().HideWinPanel();
        }
    }
}