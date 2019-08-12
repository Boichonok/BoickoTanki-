using UnityEngine;
using System.Collections;

namespace Tank
{
    public class TankParams : MonoBehaviour
    {
        [SerializeField]
        private float hp;
        [SerializeField]
        private float armor;

        [SerializeField]
        private float maxHp = 500f;
        [SerializeField]
        private float maxArmor = 500f;

        public float CurrentHPValue()
        {
            return hp / maxHp;
        }

        public void ResetHp()
        {
            hp = maxHp;
        }

        public void TakeDamage(int amount)
        {
            if (hp > maxHp || armor > maxArmor)
            {
                hp = maxHp;
                armor = maxArmor;
            }

            hp -= amount * (1 - armor / maxArmor);

        }
    }
}
