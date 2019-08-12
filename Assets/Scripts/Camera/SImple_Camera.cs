using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;

public class SImple_Camera : MonoBehaviour
{
    private Transform target;
    private Transform newTarget;
    public Vector3 offset;
    public float sensitivity; // чувствительность мышки
    public float limit = 30; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 8; // мин. увеличение
    private float X, Y;

    void Start()
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        target = FindObjectOfType<PlayerTankController>().transform.Find("SpawnModule");
        transform.position = target.position + offset;
    }

    void Update()
    {
       
        if (newTarget != null)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
            offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

            X = newTarget.transform.eulerAngles.y;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, 0);
            transform.eulerAngles = new Vector3(-Y, X, 0);
            transform.position = transform.rotation * offset + newTarget.position;
        }
        else
        {
            newTarget = target.Find("Tower(Clone)");
        }
    }


}
