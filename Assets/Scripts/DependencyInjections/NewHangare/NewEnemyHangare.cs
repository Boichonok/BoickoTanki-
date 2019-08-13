using UnityEngine;
using System.Collections;
using Tank;

public class NewEnemyHangare : NewHangare
{

    [SerializeField]
    private Tank.Tank[] enemyTanksPrefabs = null;
    [SerializeField]
    private int tankNumber;

    public NewEnemyHangare SetTankNumber(int tankNamber)
    {
        this.tankNumber = tankNamber;
        return this;
    }

    public int CountEnemyTanks()
    {
        return enemyTanksPrefabs.Length;
    }


    public override Tank.Tank MakeTank(Transform spawnPosition)
    {


        var gunModulePrefab = Resources.Load("Tower") as GameObject;


        var gunModuleGO = Instantiate<GameObject>(gunModulePrefab);
        var gunModuleComponent = gunModuleGO.GetComponent<GunModule>();

        var enemyGo = Instantiate<GameObject>(enemyTanksPrefabs[tankNumber].gameObject, spawnPosition.position, spawnPosition.rotation);

        switch (Random.Range(0,2))
        {
            case 0:
                {
                    gunModuleComponent.InitGunModuleWithoutShells(enemyGo.GetComponent<Tank.Tank>(), Color.black, 100.0f, 20, "Module 1", 0);
                }
                break;
            case 1:
                {
                    gunModuleComponent.InitGunModuleWithoutShells(enemyGo.GetComponent<Tank.Tank>(), Color.green, 120.0f, 40, "Module 2", 1);

                }
                break;
            case 2:
                {
                    gunModuleComponent.InitGunModuleWithoutShells(enemyGo.GetComponent<Tank.Tank>(), Color.black, 155.0f, 35, "Module 3", 2);
                }
                break;
        }
        gunModuleComponent.Shells[0] = MakeShell(ShellType.ARMOR_PIERCING, gunModuleComponent).gameObject; 
        gunModuleComponent.Shells[1] = MakeShell(ShellType.ARMOR_PIERCING_SUBCIBER, gunModuleComponent).gameObject;
        gunModuleComponent.Shells[2] = MakeShell(ShellType.HIGH_EXPLOSIVE, gunModuleComponent).gameObject;
        enemyGo.GetComponent<Tank.Tank>().GunModule = gunModuleComponent;


        return enemyGo.GetComponent<Tank.Tank>();
    }


}
