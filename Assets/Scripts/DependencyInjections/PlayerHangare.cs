using UnityEngine;
using System.Collections;
using Tank;

namespace Hangare
{
    public class PlayerHangare : HangareFactory
    {
        [SerializeField]
        private Tank.Tank playerTank = null;


        public override Tank.Tank MakeTank()
        {
            if (playerTank.GunModule == null)
            {
                playerTank.GunModule = playerTank.GetComponent<GunModule>();
            }
            return playerTank;
        }

        public override GunModule MakeGunModule(int gunModuleNumber)
        {
            if (playerTank.GetComponent<GunModule>() == null)
                playerTank.gameObject.AddComponent<GunModule>();

            var gunModule = playerTank.GetComponent<GunModule>();

            switch (gunModuleNumber)
            {
                case 0:
                    {

                        MakeGunModuleWithoutShells(playerTank, gunModule, Color.black, 100.0f, 20, "Module 1", gunModuleNumber);

                    }
                    break;
                case 1:
                    {

                        MakeGunModuleWithoutShells(playerTank, gunModule, Color.green, 120.0f, 40, "Module 2", gunModuleNumber);

                    }
                    break;
                case 2:
                    {
                        MakeGunModuleWithoutShells(playerTank, gunModule, Color.red, 155.0f, 35, "Module 3", gunModuleNumber);
                    }
                    break;
            }

            var shell_1 = MakeShell(ShellType.ARMOR_PIERCING, gunModule);
            var shell_2 = MakeShell(ShellType.ARMOR_PIERCING_SUBCIBER, gunModule);
            var shell_3 = MakeShell(ShellType.HIGH_EXPLOSIVE, gunModule);


            gunModule.Shells[0] = shell_1.gameObject;
            gunModule.Shells[1] = shell_2.gameObject;
            gunModule.Shells[2] = shell_3.gameObject;
            return playerTank.GunModule;
        }






    }
}
