using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tank;

namespace LevelConctollers
{
    public class GameDataTransmiter
    {
        #region Singleton
        static GameDataTransmiter() { }
        private static readonly GameDataTransmiter _instance = new GameDataTransmiter();
        public static GameDataTransmiter Instance { get { return _instance; } }
        #endregion


        public NewPlayerHangare newPlayerHangare;
        public NewEnemyHangare newEnemyHangare;

        public bool isBackToMainMenu = true;
    }
}
