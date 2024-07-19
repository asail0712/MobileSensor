using UnityEngine;

public class MobileMoveCompnent : MonoBehaviour
{
	// Movement
	[SerializeField] private float speedRatio = 5f;

	private Vector3 gravity;	
	private Quaternion rot1, rot2;

	private Vector3 currAcceleration;
	private Vector3 velocity;
	private float smooth = 0.8f;

	void Start()
    {
        Input.gyro.enabled  = true; // 启用陀螺仪
        gravity             = new Vector3(0f, 0f, -1f); // 初始假设重力方向
		rot1 = Quaternion.Euler(90f, 90f, 0f);
		rot2 = Quaternion.Euler(0f, 0f, 180f);

		currAcceleration	= Vector3.zero;
		velocity			= Vector3.zero;
	}

    void Update()
    {
		transform.localRotation = rot1 * Input.gyro.attitude * rot2;

		// 获取陀螺儀数据
		Vector3 gyroEulerAngles = Input.gyro.attitude.eulerAngles;
		//Debug.Log("Gyro Sensor EulerAngles:           " + gyroEulerAngles);

		// 獲取重力在手機坐標系上的分量
		Vector3 gravityComponent = Quaternion.Inverse(Quaternion.Euler(gyroEulerAngles)) * gravity;
		//Debug.Log("Gravity In Mobile Local Transform: " + gravityComponent);

		// 获取加速度数据
		Vector3 acceleration = Input.acceleration;
		//Debug.Log("Acceleration Sensor:               " + acceleration);

		// 將加速器的數值減去重力的分量，即為單純運動的加速度分量
		Vector3 moveAcceleration = acceleration - gravityComponent;
		Debug.Log("Move Acceleration:                 " + moveAcceleration);

		// movement
		currAcceleration = new Vector3(-moveAcceleration.x, -moveAcceleration.y, -moveAcceleration.z);// currAcceleration * smooth + moveAcceleration * (1 - smooth);
		Debug.Log("Current Acceleration:                " + currAcceleration);
		
		if(currAcceleration.magnitude > 0.015f)
		{
			velocity += currAcceleration * Time.deltaTime;
			Debug.Log("Current velocity:					" + velocity);
			transform.Translate(velocity * Time.deltaTime * speedRatio);
		}
		else
		{
			velocity = Vector3.zero;
		}
	}
}