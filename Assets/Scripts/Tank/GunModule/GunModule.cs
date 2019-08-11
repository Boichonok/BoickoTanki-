using System;
using UnityEngine;
namespace Tank
{
    [System.Serializable]
    public class GunModule: MonoBehaviour
    {
        [SerializeField]
        private int gunModuleId;
        public int GunModuleID { get { return gunModuleId;} set { gunModuleId = value; }}

        [SerializeField]
        private string gunModuleName;
        public string ModuleName { get { return gunModuleName; } set { gunModuleName = value; }}

        [SerializeField]
        private int attackValue;
        public int AttackValue { get { return attackValue; } set { attackValue = value; } }

        [SerializeField]
        private GameObject[] shells = new GameObject[3]; 
        public GameObject[] Shells { get { return shells; }  set { shells = value; } }


        private Transform spawnShell;
        public Transform SpawnShell { get { return spawnShell; } private set { spawnShell = value; }}

        [SerializeField]
        private GameObject tower;
        public GameObject Tower { get { return tower; } set { tower = value; } }

        private GameObject gun;
        public GameObject Gun { get { return gun; } private set { gun = value; }}

        [SerializeField]
        private float shootPower;
        public float ShootPower { get { return shootPower; } set { shootPower = value; } }

        private Color moduleColor;
        public Color ModuleColor { get { return moduleColor; } set { moduleColor = value; }}
        [SerializeField]
        private Transform spawnModulePlace;
        public Transform SpawnModulePlace { get { return spawnModulePlace; } set { spawnModulePlace = value; } }

        private void Start()
        {
            var towerGo = Instantiate(Tower, spawnModulePlace);
            towerGo.GetComponent<Renderer>().material.color = moduleColor;
            gun = towerGo.transform.Find("Gun").gameObject;
           
            gun.GetComponent<Renderer>().material.color = moduleColor;
            spawnShell = towerGo.transform.Find("SpawnShell");
        }

    }
}
