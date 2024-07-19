using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// second demo
// 使用Unity Remote 5
// https://www.youtube.com/watch?v=P5JxTfCAOXo

public class GyroController2 : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private bool bGyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        bGyroEnabled = EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        if (bGyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;

            // Debugging visuals
            Debug.DrawRay(transform.position, transform.forward * 500, Color.black);
            Debug.DrawRay(transform.position, (targetObject.transform.position - transform.position).normalized * 500, Color.green);
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            bGyroEnabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);

            // Calculate direction to the target
            Vector3 direction = targetObject.transform.position - transform.position;
            direction.Normalize(); // Normalize to get only the direction

            // Calculate the desired rotation to look at the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Set rot to align with the targetObject
            rot = targetRotation * Quaternion.Inverse(cameraContainer.transform.rotation);

            return true;
        }

        return false;
    }

    private void OnGUI()
	{
        // 定义按钮的位置和大小
        Rect buttonRect = new Rect(10, 10, 100, 50);

        // 创建一个按钮，按钮上的文字是 "Click Me"
        if (GUI.Button(buttonRect, "Click Me"))
        {
            // 当按钮被点击时执行的代码
            Debug.Log("Button Clicked!");

            if(targetObject != null)
			{
                Vector3 direction   = targetObject.transform.position - transform.position;
                Vector3 lookAt      = transform.forward;

                
                Debug.DrawRay(transform.position, direction, Color.green, 5f);
                Debug.Log("Camera rotated to look at target object");
            }
        }
    }

    Quaternion CalculateQuaternionFromAtoB(Vector3 a, Vector3 b)
    {
        // 归一化向量A和B
        a.Normalize();
        b.Normalize();

        // 计算旋转轴
        Vector3 axis    = Vector3.Cross(a, b);
        float angle     = Vector3.Angle(a, b);

        // 生成旋转四元数
        Quaternion rotation = Quaternion.AngleAxis(angle, axis);

        return rotation;
    }
}
