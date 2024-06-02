using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeTemplate
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] GameObject menuPanel;

        public void BackButton()
        {
            menuPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}