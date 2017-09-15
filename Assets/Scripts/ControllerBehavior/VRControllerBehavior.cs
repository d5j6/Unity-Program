//using Hover.InputModules.LeapMotion;
//using Leap.Unity;
using UnityEngine;
using UnityEngine.VR;

public class VRControllerBehavior : PlayerControllerBehavior
{
    public VRControllerBehavior(MonoBehaviour player) : base(player)
    {

        //VRSettings.enabled = true;
        var camera = player.GetComponentInChildren<Camera>();
        camera.stereoTargetEye = StereoTargetEyeMask.Both;
        //var leapVRCameraControl = camera.GetComponent<LeapVRCameraControl>();
        //leapVRCameraControl.OverrideEyePosition = false;

        //if (player.gameObject.GetComponent<HoverInputLeapMotion>()!=null)
        //{
        //    player.gameObject.GetComponent<HoverInputLeapMotion>().enabled = true;
        //}

        //GameObject[] LeapMotionArray = GameObject.FindGameObjectsWithTag("LM");
        //for (int i = 0; i < LeapMotionArray.Length; i++)
        //{
        //    LeapMotionArray[i].SetActive(true);
        //}
    }

    public override void UpdateBehavior()
    {

    }
}
