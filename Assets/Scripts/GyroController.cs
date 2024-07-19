using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// second demo
// ¨Ï¥ÎUnity Remote 5
// https://www.youtube.com/watch?v=P5JxTfCAOXo

public class GyroController : MonoBehaviour
{
    private bool bGyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        cameraContainer                     = new GameObject("Camera Container");
        cameraContainer.transform.position  = transform.position;
        transform.SetParent(cameraContainer.transform);

        bGyroEnabled = EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        if(bGyroEnabled)
		{
            transform.localRotation = gyro.attitude * rot;

            Debug.Log($"gyro.attitude is {gyro.attitude}");
            Debug.Log($"rot is {rot.ToString()}");
        }
    }

    private bool EnableGyro()
	{
        if(SystemInfo.supportsGyroscope)
		{
            gyro            = Input.gyro;
            bGyroEnabled    = true;

            cameraContainer.transform.rotation  = Quaternion.Euler(90f, 90f, 0f);
            rot                                 = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }
}
