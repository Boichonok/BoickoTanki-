using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImple_Camera : MonoBehaviour {
    public GameObject playerTankTower;


    private Vector3 offset;


    public void InitCamera()
    {
        offset = transform.position - playerTankTower.transform.position;
        transform.position = playerTankTower.transform.position + offset;
    }


}
