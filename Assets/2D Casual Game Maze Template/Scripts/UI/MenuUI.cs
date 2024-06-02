using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MazeTemplate
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Image soundImage;
        [SerializeField] private TextMeshProUGUI soundText;
        [SerializeField] private GameObject levelsPanel;

        private void Start()
        {
            if (DataScript.GetSoundVolume() == 1)
                SetSoundOn();
            else
                SetSoundOff();
        }

        public void PlayButton()
        {
            levelsPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        public void SoundButton()
        {
            if (DataScript.GetSoundVolume() == 0)
            {
                SetSoundOn();
                DataScript.SetSoundVolume(1);
            }
            else
            {
                SetSoundOff();
                DataScript.SetSoundVolume(0);
            }
        }

        private void SetSoundOff()
        {
            soundImage.color = new Color(0, 0.5f, 0.09f);
            soundText.text = "Sound Off";
            AudioListener.volume = 0;
        }

        private void SetSoundOn()
        {
            soundImage.color = new Color(0, 0.95f, 0.09f);
            soundText.text = "Sound On";
            AudioListener.volume = 1;
        }

    }
}