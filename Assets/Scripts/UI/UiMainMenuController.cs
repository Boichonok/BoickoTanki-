using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelConctollers;

namespace UiControllers
{
    public class UiMainMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainMenu = null;
        [SerializeField]
        private GameObject hangareMenu = null;

        public void StartNewButtle()
        {
            mainMenu.SetActive(false);
            hangareMenu.SetActive(true);
        }

        public void ExiteGame()
        {
            Application.Quit();
        }

        private void OnLevelWasLoaded(int level)
        {
            if (level == 0)
            {
                if (GameDataTransmiter.Instance.isBackToMainMenu)
                {
                    mainMenu.SetActive(true);
                    hangareMenu.SetActive(false);
                }
                else
                {
                    mainMenu.SetActive(false);
                    hangareMenu.SetActive(true);
                }
            }
        }
    }
}
