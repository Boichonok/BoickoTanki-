using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Tank;
using Hangare;
using LevelConctollers;

namespace UiControllers
{
    public class UIHangareController : MonoBehaviour
    {
        [SerializeField]
        private PlayerHangare playerHangare = null;

        [SerializeField]
        private EnemyHangare enemyHangare = null;
        [SerializeField]
        private GameObject mainMenu = null;
        [SerializeField]
        private Button[] buttons = null;
        [SerializeField]
        private UIGunModuleInfo uIGunModuleInfo = null;


        private Tank.Tank playerTank;

        public void SelectGunModule(int gunModuleBtnID)
        {
            var gunModule = playerHangare.MakeGunModule(gunModuleBtnID);
            playerTank = playerHangare.MakeTank();

            uIGunModuleInfo.SetModuleName(gunModule.ModuleName);

            var shell_1 = gunModule.Shells[0].GetComponent<Shell>();
            uIGunModuleInfo.SetTextArmorPiercingDamageValue(shell_1.AttackValue);

            var shell_2 = gunModule.Shells[1].GetComponent<Shell>();
            uIGunModuleInfo.SetTextArmorPiercingSubciber(shell_2.AttackValue);

            var shell_3 = gunModule.Shells[2].GetComponent<Shell>();
            uIGunModuleInfo.SetTextHighExplosive(shell_3.AttackValue);



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
            GameDataTransmiter.Instance.playerTank = playerTank.GetComponent<PlayerTankController>();
            for (int i = 0; i < enemyHangare.CountEnemyTanks(); i++)
            {
                enemyHangare.SetTankNumber(i);
                enemyHangare.MakeGunModule(Random.Range(0, 2));
                GameDataTransmiter.Instance.enemyTank.Add(enemyHangare.MakeTank().GetComponent<AITank>());
            }
            Application.LoadLevel(1);
        }

        public void BackToMenu()
        {
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
