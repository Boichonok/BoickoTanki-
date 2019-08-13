using System;
using UnityEngine;
namespace Tank
{
    public enum ShellType
    {
        ARMOR_PIERCING = 0,
        ARMOR_PIERCING_SUBCIBER = 1,
        HIGH_EXPLOSIVE = 2
    }

    public class Shell : MonoBehaviour
    {

        public ShellType ShellType;//{ get; set; }

        public int AttackValue;// { get; set; }

        public Color shellColor;// { private get; set; }

        public float LifeTime { get; set; }

        private float age;
        private bool isLive = true;



        private void Start()
        {
            LifeTime = 5.0f;
            GetComponent<Renderer>().material.color = shellColor;
        }

        private void Update()
        {
            ShellController();
        }
        public void ShellController()
        {
            age += Time.deltaTime;
            if (age > LifeTime)
            {
                Destroy(this.gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (!isLive)
                return;
            isLive = false;
            Destroy(this.gameObject);
            Tank target;
            if (collision.gameObject.tag != "Tower")
                target = collision.gameObject.GetComponent<Tank>();
            else
                target = collision.gameObject.GetComponent<GunModule>().TankOwner;
            if (target != null)
            {
                target.TankParams.TakeDamage(AttackValue);
            }
        }
    }
}
