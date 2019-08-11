using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Tank;
using LevelConctollers;

namespace UiControllers
{
    public class UIPlayerController : MonoBehaviour
    {

        [SerializeField]
        private Scrollbar hpBar = null;

        [SerializeField]
        private Text shellName = null;

        [SerializeField]
        private Text shellAttackValue = null;

        [SerializeField]
        private Text enemyKillCount = null;

        [SerializeField]
        private Text playerDeathCount = null;

        [SerializeField]
        private GameObject menu = null;

        [SerializeField]
        private GameObject helper = null;

        [SerializeField]
        private BattleSceneController battleSceneController = null;


        // Update is called once per frame
        void Update()
        {
            var playerTank = battleSceneController.GetPlayerTankController();
            UpdateHpBar(playerTank);
            UpdateCurrentShellInfo(playerTank);
            CloseOpenMenu();
            UpdateEnemyKilledCount();
            UpdatePlayerDethCount();
        }

        private void UpdateHpBar(PlayerTankController playerTank)
        {
            hpBar.size = playerTank.TankParams.CurrentHPValue();
            hpBar.value = 0;
        }

        private void UpdateCurrentShellInfo(PlayerTankController playerTank)
        {
            var currentShell = playerTank.CurrentShellType;
            shellName.text = currentShell.ToString();
            shellAttackValue.text = playerTank.GunModule.Shells[(int)currentShell].GetComponent<Shell>().AttackValue.ToString();
        }

        private void UpdateEnemyKilledCount()
        {
            enemyKillCount.text = battleSceneController.CountEnemyDeth.ToString();
        }

        private void UpdatePlayerDethCount()
        {
            playerDeathCount.text = battleSceneController.CountPlayerDeth.ToString();
        }

        private void CloseOpenMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!menu.activeInHierarchy)
                {
                    menu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    menu.SetActive(false);
                    Time.timeScale = 1;
                }
            }

        }

        public void CloseHelper()
        {
            if (helper.activeInHierarchy)
                helper.SetActive(false);
        }

        public void BackToHangare()
        {
            GameDataTransmiter.Instance.isBackToMainMenu = false;
            Application.LoadLevel(0);
        }

        public void BackToMainMenu()
        {
            GameDataTransmiter.Instance.isBackToMainMenu = true;
            Application.LoadLevel(0);
        }
    }
}
