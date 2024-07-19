using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// first demo
// ¨Ï¥ÎUnity Remote 5
// https://www.youtube.com/watch?v=V_fJnhw8p3g

public class GyroTest : MonoBehaviour
{
    Vector3 defaultRot = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled  = true;
        defaultRot          = Input.gyro.attitude.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.updateInterval = Time.deltaTime;

        //Vector3 rot = new Vector3(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.z, Input.gyro.rotationRateUnbiased.y);
        //Vector3 rot = new Vector3(-Input.gyro.rotationRateUnbiased.x, 0, -Input.gyro.rotationRateUnbiased.y);
        //Vector3 rot = new Vector3(-Input.gyro.rotationRateUnbiased.x / 2f, 0, 0);
        //Debug.Log(rot);        
        //transform.Rotate(rot);

        Vector3 calibratioAngles    = Input.gyro.attitude.eulerAngles - defaultRot;
        calibratioAngles.y          = 0f;

        Debug.Log("Default Rot is " + defaultRot);
        Debug.Log("GYRO is " + Input.gyro.attitude.eulerAngles);
        Debug.Log("Calibration Result is " + calibratioAngles);

        transform.rotation = Quaternion.Euler(calibratioAngles);
    }
}
