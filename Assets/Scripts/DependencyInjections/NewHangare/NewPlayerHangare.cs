using UnityEngine;
using System.Collections;
using Tank;

public class NewPlayerHangare : NewHangare
{
    [SerializeField]
    private Tank.Tank playerTankPrefab = null;

    private GameObject gunModulePrefab;


    public GunModule GetGunModuleInfo(int gunModuleNumber)
    {
        if (gunModulePrefab == null)
            gunModulePrefab = Resources.Load("PlayerTower") as GameObject;
        GunModule gunModule = gunModulePrefab.GetComponent<GunModule>();

       

        switch (gunModuleNumber)
        {
            case 0:
                {
                    gunModule.InitGunModuleWithoutShells(playerTankPrefab, Color.black, 100.0f, 20, "Module 1", gunModuleNumber);
                }
                break;
            case 1:
                {
                    gunModule.InitGunModuleWithoutShells(playerTankPrefab, Color.green, 120.0f, 40, "Module 2", gunModuleNumber);
                }
                break;
            case 2:
                {
                    gunModule.InitGunModuleWithoutShells(playerTankPrefab, Color.red, 155.0f, 35, "Module 3", gunModuleNumber);
                }
                break;
        }
        var shell_1 = MakeShell(ShellType.ARMOR_PIERCING, gunModule).gameObject;
        var shell_2 = MakeShell(ShellType.ARMOR_PIERCING_SUBCIBER, gunModule).gameObject;
        var shell_3 = MakeShell(ShellType.HIGH_EXPLOSIVE, gunModule).gameObject;

        gunModule.Shells[0] = shell_1;
        gunModule.Shells[1] = shell_2;
        gunModule.Shells[2] = shell_3;
        return gunModule;
    }

    public override Tank.Tank MakeTank(Transform spawnPosition)
    {
        var gunModuleGO = Instantiate<GameObject>(gunModulePrefab);
        var gunModuleComponent = gunModuleGO.GetComponent<GunModule>();
        var playerTankGo = Instantiate<GameObject>(playerTankPrefab.gameObject, spawnPosition.position, spawnPosition.rotation);

        gunModuleComponent.InitGunModuleWithoutShells(playerTankGo.GetComponent<Tank.Tank>(), gunModuleComponent.ModuleColor, gunModuleComponent.ShootPower, gunModuleComponent.AttackValue, gunModuleComponent.ModuleName, gunModuleComponent.GunModuleID);
        playerTankGo.GetComponent<Tank.Tank>().GunModule = gunModuleComponent;
        return playerTankGo.GetComponent<Tank.Tank>();
    }


}
