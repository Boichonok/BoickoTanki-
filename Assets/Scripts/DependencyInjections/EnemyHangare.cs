using UnityEngine;
using System.Collections;
using Tank;

namespace Hangare
{
    public class EnemyHangare : HangareFactory
    {
        [SerializeField]
        private Tank.Tank[] enemyTank = null;

        private int tankNumber;

        public EnemyHangare SetTankNumber(int tankNamber)
        {
            this.tankNumber = tankNamber;
            return this;
        }

        public int CountEnemyTanks()
        {
            return enemyTank.Length;
        }

        public override GunModule MakeGunModule(int gunModuleNumber)
        {
            if (enemyTank[tankNumber].GetComponent<GunModule>() == null)
                enemyTank[tankNumber].gameObject.AddComponent<GunModule>();

            var gunModule = enemyTank[tankNumber].GetComponent<GunModule>();
            switch (gunModuleNumber)
            {
                case 0:
                    {

                        MakeGunModuleWithoutShells(enemyTank[tankNumber], gunModule, Color.black, 50.0f, 20, "Module 1", gunModuleNumber);

                    }
                    break;
                case 1:
                    {

                        MakeGunModuleWithoutShells(enemyTank[tankNumber], gunModule, Color.green, 60.0f, 40, "Module 2", gunModuleNumber);

                    }
                    break;
                case 2:
                    {
                        MakeGunModuleWithoutShells(enemyTank[tankNumber], gunModule, Color.red, 55.0f, 35, "Module 3", gunModuleNumber);
                    }
                    break;
            }

            var shell_1 = MakeShell(ShellType.ARMOR_PIERCING, gunModule);
            var shell_2 = MakeShell(ShellType.ARMOR_PIERCING_SUBCIBER, gunModule);
            var shell_3 = MakeShell(ShellType.HIGH_EXPLOSIVE, gunModule);


            gunModule.Shells[0] = shell_1.gameObject;
            gunModule.Shells[1] = shell_2.gameObject;
            gunModule.Shells[2] = shell_3.gameObject;
            return enemyTank[tankNumber].GunModule;
        }

        public override Tank.Tank MakeTank()
        {
            if (enemyTank[tankNumber].GunModule == null)
            {
                enemyTank[tankNumber].GunModule = enemyTank[tankNumber].GetComponent<GunModule>();
            }
            return enemyTank[tankNumber];
        }
    }
}
