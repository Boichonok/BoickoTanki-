using System;
using UnityEngine;
namespace Tank
{

    public class GunModule : MonoBehaviour
    {
        [SerializeField]
        private int gunModuleId;
        public int GunModuleID { get { return gunModuleId; } private set { gunModuleId = value; } }

        [SerializeField]
        private string gunModuleName;
        public string ModuleName { get { return gunModuleName; } private set { gunModuleName = value; } }

        [SerializeField]
        private int attackValue;
        public int AttackValue { get { return attackValue; } private set { attackValue = value; } }

        [SerializeField]
        private GameObject[] shells = new GameObject[3];
        public GameObject[] Shells { get { return shells; } set { shells = value; } }

        [SerializeField]
        private Transform spawnShell;
        public Transform SpawnShell { get { return spawnShell; } private set { spawnShell = value; } }

        [SerializeField]
        private GameObject gun;
        public GameObject Gun { get { return gun; } private set { gun = value; } }

        [SerializeField]
        private float shootPower;
        public float ShootPower { get { return shootPower; } private set { shootPower = value; } }
        [SerializeField]
        private Color moduleColor;
        public Color ModuleColor { get { return moduleColor; } private set { moduleColor = value; } }

        [SerializeField]
        private Transform spawnModulePlace;

        [SerializeField]
        private Tank tankOwner;
        public Tank TankOwner { get { return tankOwner; } set { tankOwner = value; } }

        public void InitGunModuleWithoutShells(Tank tank,Color color, float shootPower, int attackValue, string moduleName, int id)
        {
            this.gunModuleId = id;
            this.gunModuleName = moduleName;
            this.ShootPower = shootPower;
            this.attackValue = attackValue;
            this.moduleColor = color;
            this.tankOwner = tank;
            this.spawnModulePlace = tank.SpawnModulePlace;
        }

        private void Start()
        {
            GetComponent<Renderer>().material.color = moduleColor;
            gun.GetComponent<Renderer>().material.color = moduleColor;
        }

        private void Update()
        {
            ConectingWithTankBody();
        }

        private void ConectingWithTankBody()
        {

            transform.position = new Vector3(spawnModulePlace.position.x, spawnModulePlace.position.y, spawnModulePlace.position.z);
        }

    }
}
