using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public static ControllerCamera Instance;    //Singleton of Class

    //Declare variables,
    public Transform targetObject;

    private float yAxis = 8f;
    private float zAxis = 12f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(targetObject.position.x, targetObject.position.y + yAxis, targetObject.position.z - zAxis);
    }

    //Functions,

    //Kameranın hedefe (Charactere) yakınlaşma/uzaklaşma durumlarında, y ve z eksenlerinin ayarlanabildiği fonksiyon.
    public void functionSetTarget()
    {
        yAxis = 4.5f;
        zAxis = 18f;
    }

    //END LINE.
}