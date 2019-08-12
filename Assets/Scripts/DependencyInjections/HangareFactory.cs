using UnityEngine;
using System.Collections;
using Tank;
namespace Hangare
{
    public abstract class HangareFactory : MonoBehaviour
    {
        public abstract GunModule MakeGunModule(int gunModuleNumber);
        public abstract Tank.Tank MakeTank();

        protected void MakeGunModuleWithoutShells(Tank.Tank tank, GunModule gunModule, Color color, float shootPower, int attackValue, string moduleName, int id)
        {
            gunModule.GunModuleID = id;
            gunModule.ModuleName = moduleName;
            gunModule.ShootPower = shootPower;
            gunModule.AttackValue = attackValue;
            var modulePrefub = Resources.Load("Tower") as GameObject;
            gunModule.Tower = modulePrefub;
            gunModule.ModuleColor = color;
           
        }

        protected Shell MakeShell(ShellType shellType, GunModule module)
        {
            Shell shell = null;

            switch (shellType)
            {
                case ShellType.ARMOR_PIERCING:
                    {
                        GameObject shellGo = Resources.Load("ARMOR_PIERCING") as GameObject;//
                        shell = shellGo.GetComponent<Shell>();
                        shell.ShellType = shellType;
                        shell.AttackValue = module.AttackValue;
                        shell.AttackValue += 50;
                        shell.shellColor = Color.red;
                    }
                    break;
                case ShellType.ARMOR_PIERCING_SUBCIBER:
                    {
                        GameObject shellGo = Resources.Load("ARMOR_PIERCING_SUBCIBER") as GameObject;//
                        shell = shellGo.GetComponent<Shell>();
                        shell.ShellType = shellType;
                        shell.AttackValue = module.AttackValue;
                        shell.AttackValue += 60;
                        shell.shellColor = Color.black;
                    }
                    break;
                case ShellType.HIGH_EXPLOSIVE:
                    {
                        GameObject shellGo = Resources.Load("HIGH_EXPLOSIVE") as GameObject;//
                        shell = shellGo.GetComponent<Shell>();
                        shell.ShellType = shellType;
                        shell.AttackValue = module.AttackValue;
                        shell.AttackValue += 70;
                        shell.shellColor = Color.yellow;
                    }
                    break;
            }

            return shell;
        }
    }
}
