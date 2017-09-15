//using Leap.Unity;
using UnityEngine;
using UnityEngine.VR;

public class PicoVRControllerBehavior : PlayerControllerBehavior
{
    public PicoVRControllerBehavior(MonoBehaviour player) : base(player)
    {
        //VRSettings.enabled = false;
        VRSettings.showDeviceView = false;
        //GameObject[] PicoArray = GameObject.FindGameObjectsWithTag("Pico");
        //for (int i = 0; i < PicoArray.Length; i++)
        //{
        //    PicoArray[i].SetActive(true);
        //}
        //Pvr_UnitySDKManager picoManager = GameManager.Instance.GetComponentInChildren<Pvr_UnitySDKManager>();
        //picoManager.ShowFPS = true;

        Camera[] cam = GameManager.Instance.GetComponentsInChildren<Camera>();
        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].stereoTargetEye = StereoTargetEyeMask.None;
        }
        //player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        //var leapVRCameraControl = camera.GetComponent<LeapVRCameraControl>();
        //leapVRCameraControl.OverrideEyePosition = false;
    }


    public override void UpdateBehavior()
    {

    }
}
