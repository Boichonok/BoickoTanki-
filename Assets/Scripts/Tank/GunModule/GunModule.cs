using System;
using UnityEngine;
namespace Tank
{
  
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

        [SerializeField]
        private Transform spawnShell;
        public Transform SpawnShell { get { return spawnShell; } private set { spawnShell = value; }}

        [SerializeField]
        private GameObject tower;
        public GameObject Tower { get { return tower; } set { tower = value; } }

        [SerializeField]
        private GameObject gun;
        public GameObject Gun { get { return gun; } private set { gun = value; }}

        [SerializeField]
        private float shootPower;
        public float ShootPower { get { return shootPower; } set { shootPower = value; } }
        [SerializeField]
        private Color moduleColor;
        public Color ModuleColor { get { return moduleColor; } set { moduleColor = value; }}

        [SerializeField]
        private Transform spawnModulePlace;
        public Transform SpawnModulePlace { get { return spawnModulePlace; } private set { spawnModulePlace = value; } }

        private void Start()
        {
            var towerGo = Instantiate(Tower, spawnModulePlace);
            towerGo.transform.localPosition = Vector3.zero;
            tower = towerGo;
            spawnShell = towerGo.transform.Find("SpawnShell");
            gun = towerGo.transform.Find("Gun").gameObject;
            gun.GetComponent<Renderer>().material.color = moduleColor;
            towerGo.GetComponent<Renderer>().material.color = moduleColor;

        }

    }
}
