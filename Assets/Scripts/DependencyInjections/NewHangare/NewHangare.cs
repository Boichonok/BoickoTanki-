using UnityEngine;
using System.Collections;
using Tank;
public abstract class NewHangare : MonoBehaviour
{
   
    public abstract Tank.Tank MakeTank(Transform spawnPosition);


   

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
