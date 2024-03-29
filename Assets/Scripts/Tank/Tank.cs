﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public abstract class Tank : MonoBehaviour
    {
        public delegate void ShootAction(int currentShellType);
        public delegate void DeadAction();

        [SerializeField]
        private GunModule gunModules;
        public GunModule GunModule { get { return gunModules; } set { gunModules = value; } }

        [SerializeField]
        private Color tankColor;
        public Color TankColor { get { return tankColor; } private set { tankColor = value; } }

        [SerializeField]
        private float tankSpeed;
        public float TankSpeed { get { return tankSpeed; } private set { tankSpeed = value; } }

        [SerializeField]
        private int collisionAttack;
        public int CollisionAttack { get { return collisionAttack; } private set { collisionAttack = value; } }

        [SerializeField]
        protected TankParams tankParams;
        public TankParams TankParams { get { return tankParams; } private set { tankParams = value; } }

       
        [SerializeField]
        private Transform spawnPoint = null;
        public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

        [SerializeField]
        private Transform spawnModulePlace = null;
        public Transform SpawnModulePlace { get { return spawnModulePlace; } set { spawnModulePlace = value; } }

        [SerializeField]
        protected ShellType currentShellType = ShellType.ARMOR_PIERCING;
        public ShellType CurrentShellType { get { return currentShellType; } private set { currentShellType = value; }}


        #region Shooting
        protected void MakeShoot(int currentShell)
        {
            Shell shellComponent = GunModule.Shells[currentShell].GetComponent<Shell>();

            var shell = Instantiate(shellComponent.gameObject, GunModule.SpawnShell.position,GunModule.SpawnShell.rotation);
            
            shell.GetComponent<Rigidbody>().velocity = gunModules.GetComponent<Rigidbody>().velocity;
            shell.GetComponent<Rigidbody>().AddForce(gunModules.SpawnShell.transform.forward * GunModule.ShootPower * 500);

        }
        #endregion

       

        #region Spawn_Respawn_Tank
        protected void ReSpawnTank()
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            tankParams.ResetHp();
        }
        #endregion
    }
}
