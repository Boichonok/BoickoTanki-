using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;

namespace LevelConctollers
{
    public class BattleSceneController : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPoints = null;

        private NewPlayerHangare playerHangare;

        private NewEnemyHangare enemyHangare;

        private PlayerTankController playerTankController;

        private List<AITank> aITanksControllers = new List<AITank>();


        private int countPlayerDeth = 0;
        public int CountPlayerDeth { get { return countPlayerDeth; } private set { countPlayerDeth = value; } }


        private int countEnemyDeth = 0;
        public int CountEnemyDeth { get { return countEnemyDeth; } private set { countEnemyDeth = value; } }

        private void OnLevelWasLoaded(int level)
        {
            if (level == 1)
            {
                Time.timeScale = 1;
                playerHangare = GameDataTransmiter.Instance.newPlayerHangare;
                enemyHangare = GameDataTransmiter.Instance.newEnemyHangare;
             
            }
        }

        private void Start()
        {
            playerTankController = playerHangare.MakeTank(spawnPoints[0]) as PlayerTankController;
            playerTankController.SpawnPoint = spawnPoints[0];
            playerTankController.EventDeadAction += CountingPlayerDeth;

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if(i > 0)
                {
                    var enemyAi = enemyHangare.SetTankNumber(i-1).MakeTank(spawnPoints[i]) as AITank;
                    enemyAi.SpawnPoint = spawnPoints[i];
                    enemyAi.EventDeadAction += CountingEnemyDeath;
                    aITanksControllers.Add(enemyAi);
                }
            }

        
        }


        public PlayerTankController GetPlayerTankController()
        {
            return playerTankController;
        }



        private void CountingPlayerDeth()
        {
            countPlayerDeth++;

        }

        private void CountingEnemyDeath()
        {
            countEnemyDeth++;
        }


        private void OnDisable()
        {
            playerTankController.EventDeadAction -= CountingPlayerDeth;
            foreach (AITank enemyTank in aITanksControllers)
            {
                enemyTank.EventDeadAction -= CountingEnemyDeath;
            }
        }
    }
}
