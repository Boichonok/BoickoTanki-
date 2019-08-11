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

        private GameObject playerTankPrefab;

        private List<GameObject> aiTanksPrefabs = new List<GameObject>();

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
                playerTankPrefab = GameDataTransmiter.Instance.playerTank.gameObject;
                foreach (AITank aiTank in GameDataTransmiter.Instance.enemyTank)
                {
                    aiTanksPrefabs.Add(aiTank.gameObject);
                }
            }
        }

        private void Start()
        {
            playerTankController = Instantiate<GameObject>(playerTankPrefab, spawnPoints[0]).GetComponent<PlayerTankController>();
            playerTankController.EventDeadAction += CountingPlayerDeth;
            for (int i = 0; i < aiTanksPrefabs.Count; i++)
            {

                aiTanksPrefabs[i].GetComponent<AITank>().SpawnPoint = spawnPoints[Random.Range(1, spawnPoints.Length - 1)];
                var enemyTankGo = Instantiate(aiTanksPrefabs[i], aiTanksPrefabs[i].GetComponent<AITank>().SpawnPoint);
                enemyTankGo.GetComponent<AITank>().EventDeadAction += CountingEnemyDeath;
                aITanksControllers.Add(enemyTankGo.GetComponent<AITank>());
            }
        }


        public PlayerTankController GetPlayerTankController()
        {
            return playerTankController;
        }



        private void CountingPlayerDeth()
        {
            countPlayerDeth++;
            print("Death: " + countPlayerDeth);
        }

        private void CountingEnemyDeath()
        {
            countEnemyDeth++;
            print("Kill:" + countEnemyDeth);
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
