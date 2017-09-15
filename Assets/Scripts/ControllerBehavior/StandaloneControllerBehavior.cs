using System;
using UnityEngine;
using UnityEngine.VR;

public class StandaloneControllerBehavior : PlayerControllerBehavior
{
    //public PCUIController UIController { get; private set; }
    public StandaloneControllerBehavior(MonoBehaviour player) : 
        base(player)
    {
        VRSettings.enabled = false;
        var camera = player.GetComponentInChildren<Camera>();
        camera.stereoTargetEye = StereoTargetEyeMask.None;

        //var leapVRCameraControl = camera.GetComponent<LeapVRCameraControl>();
        //leapVRCameraControl.OverrideEyePosition = false;

        //_yaw = player.transform.localEulerAngles.y;
        //_pitch = player.transform.localEulerAngles.x;
    }

    private float _moveSpeed = 0.5f;

    private float _yaw = 0.0f;
    private float _pitch = 0.0f;
    public override void UpdateBehavior()
    {
        var transform = Player.transform;
        //var currentTransform = transform;
        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.position += transform.forward * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.position -= transform.forward * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.position -= transform.right * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.position += transform.right * _moveSpeed;
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            _moveSpeed = Mathf.Clamp(_moveSpeed / 2, 0.01f, _moveSpeed);
        }
        if (Input.GetKey(KeyCode.Plus))
        {
            _moveSpeed = Mathf.Clamp(_moveSpeed * 2, _moveSpeed, 2.0f);
        }

        Cursor.visible = !Input.GetMouseButton(1);
        if (Input.GetMouseButton(1))
        {
            _yaw += Input.GetAxis("Mouse X");
            _pitch -= Input.GetAxis("Mouse Y");
            transform.localEulerAngles = new Vector3(_pitch, _yaw, 0.0f);
        }

    }
}

