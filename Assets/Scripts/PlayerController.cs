using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 資料來源
// https://www.youtube.com/watch?v=jvwX5WthM2o

public class PlayerController : MonoBehaviour
{
    // Movement
    [SerializeField] private float speed = 3.3f;
    [SerializeField] private CharacterController controller;

    private float rotSpeed          = 90f;
    private Vector3 moveDirection   = Vector3.zero;

    // Rotation
    private float _initialYAngle        = 0f;
    private float _appliedGyroYAngle    = 0f;
    private float _calibrationYAngle    = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    // Setting
    private float _smoothing = 0.1f;

    private Vector3 WorldToDevice(Vector3 worldVector)
    {
        Quaternion deviceRotation = Quaternion.Euler(90, 180, 0); // 根据设备方向调整
        return deviceRotation * worldVector;
    }

    // Update is called once per frame
    void Update()
    {

		// movement
	   Vector3 move = new Vector3(Input.acceleration.x, 0, Input.acceleration.z);
		if (move.magnitude > 0.2f)
		{
			Debug.Log(Input.acceleration);

			move = move * speed * Time.deltaTime;
			Vector3 rotMovement = transform.TransformDirection(move);
			controller.Move(rotMovement);
		}

		// rotation

		ApplyGyroRotation();
		ApplyCalibration();

		transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
	}

    private IEnumerator Start()
	{
        Input.gyro.enabled          = true;
        Application.targetFrameRate = 60;
        _initialYAngle              = transform.eulerAngles.y;

        _rawGyroRotation            = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position   = transform.position;
        _rawGyroRotation.rotation   = transform.rotation;

        yield return new WaitForSeconds(1);

        StartCoroutine(CalibrationYAngle());
    }

    private IEnumerator CalibrationYAngle()
	{
        _tempSmoothing      = _smoothing;
        _smoothing          = 1;
        _calibrationYAngle  = _appliedGyroYAngle - _initialYAngle;
        yield return null;
        _smoothing          = _tempSmoothing;
	}

    private void ApplyGyroRotation()
	{
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self);
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y;
    }

    private void ApplyCalibration()
	{
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World);
    }

    public void SetEnabled(bool b)
	{
        enabled = b;
        StartCoroutine(CalibrationYAngle());
	}
}
