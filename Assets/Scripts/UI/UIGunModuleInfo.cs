using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace UiControllers
{
    public class UIGunModuleInfo : MonoBehaviour
    {
        [SerializeField]
        private Text moduleNameView = null;
        [SerializeField]
        private Text ArmorPiercingDamageValue = null;
        [SerializeField]
        private Text ArmorPiercingSubciber = null;
        [SerializeField]
        private Text HighExplosive = null;


        public void SetModuleName(string name)
        {
            moduleNameView.text = name;
        }

        public void SetTextArmorPiercingDamageValue(int attackValue)
        {
            ArmorPiercingDamageValue.text = attackValue.ToString();
        }

        public void SetTextArmorPiercingSubciber(int attackValue)
        {
            ArmorPiercingSubciber.text = attackValue.ToString();
        }
        public void SetTextHighExplosive(int attackValue)
        {
            HighExplosive.text = attackValue.ToString();
        }
    }
}
