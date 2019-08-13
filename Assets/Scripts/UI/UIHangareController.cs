using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Tank;
using UnityEngine.SceneManagement;

using LevelConctollers;

namespace UiControllers
{
    public class UIHangareController : MonoBehaviour
    {
        [SerializeField]
        private NewPlayerHangare playerHangare = null;

        [SerializeField]
        private NewEnemyHangare enemyHangare = null;
        [SerializeField]
        private GameObject mainMenu = null;
        [SerializeField]
        private Button[] buttons = null;
        [SerializeField]
        private UIGunModuleInfo uIGunModuleInfo = null;


        private Tank.Tank playerTank;

        public void SelectGunModule(int gunModuleBtnID)
        {
            var gunModule = playerHangare.GetGunModuleInfo(gunModuleBtnID);
           

            uIGunModuleInfo.SetModuleName(gunModule.ModuleName);

            uIGunModuleInfo.SetTextArmorPiercingDamageValue(gunModule.Shells[0].GetComponent<Shell>().AttackValue);

            uIGunModuleInfo.SetTextArmorPiercingSubciber(gunModule.Shells[1].GetComponent<Shell>().AttackValue);

            uIGunModuleInfo.SetTextHighExplosive(gunModule.Shells[2].GetComponent<Shell>().AttackValue);



        }

        private void DisableButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = false;
            }
        }

        public void StartBattle()
        {

            GameDataTransmiter.Instance.newPlayerHangare = playerHangare;
            GameDataTransmiter.Instance.newEnemyHangare = enemyHangare;
            SceneManager.LoadScene(1, LoadSceneMode.Single);

        }

        public void BackToMenu()
        {
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
