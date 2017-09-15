//using Leap.Unity;
using System;
using UnityEngine;
using UnityEngine.VR;

public class MobileControllerBehavior : PlayerControllerBehavior
{
    public MobileControllerBehavior(MonoBehaviour player) : base(player)
    {
        Input.compass.enabled = true;
        VRSettings.enabled = false;
        var camera = player.GetComponentInChildren<Camera>();
        camera.stereoTargetEye = StereoTargetEyeMask.None;

        //var leapVRCameraControl = camera.GetComponent<LeapVRCameraControl>();
        //leapVRCameraControl.OverrideEyePosition = false;
    }

    public override void UpdateBehavior()
    {
        var rotation = Quaternion.FromToRotation(Vector3.right, Input.compass.rawVector);
        Player.transform.rotation = rotation;
    }
}
