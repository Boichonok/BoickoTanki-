using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImple_Camera : MonoBehaviour
{
    private Vector3 offset;


    public void InitCamera(GameObject playerTankTower)
    {
        offset = transform.position - playerTankTower.transform.position;
        transform.position = playerTankTower.transform.position + offset;
    }


}
