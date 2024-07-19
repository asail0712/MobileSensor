using UnityEngine;

public class GravityWithGyro : MonoBehaviour
{
    private Vector3 gravity;

    void Start()
    {
        Input.gyro.enabled  = true; // 启用陀螺仪
        gravity             = new Vector3(0f, 0f, -1f); // 初始假设重力方向
    }

    void Update()
    {
		// 获取陀螺儀数据
		Vector3 gyroEulerAngles = Input.gyro.attitude.eulerAngles;
		Debug.Log("Gyro Sensor EulerAngles:           " + gyroEulerAngles);

		// 獲取重力在手機坐標系上的分量
		Vector3 gravityComponent = Quaternion.Inverse(Quaternion.Euler(gyroEulerAngles)) * gravity;
		Debug.Log("Gravity In Mobile Local Transform: " + gravityComponent);

		// 获取加速度数据
		Vector3 acceleration = Input.acceleration;
		Debug.Log("Acceleration Sensor:               " + acceleration);

		// 透過加速器與陀螺儀，算出當前的重力(理應為0, 0, -1)
		Vector3 gravityByGyro = Quaternion.Euler(gyroEulerAngles) * acceleration;
		Debug.Log("Gravity by Acceleration:           " + gravityByGyro);

		// 將加速器的數值減去重力的分量，即為單純運動的加速度分量
		Vector3 moveAcceleration = acceleration - gravityComponent;
		Debug.Log("Move Acceleration:                 " + moveAcceleration);
	}
}