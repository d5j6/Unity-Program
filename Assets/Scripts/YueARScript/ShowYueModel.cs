using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShowYueModel : MonoBehaviour {
    [SerializeField]
    GameObject imageTarget;
    [SerializeField]
    GameObject imageChildImage;
    [SerializeField]
    GameObject otherImage;
	void Start ()
    {
		
	}
    float timer;
	void Update ()
    {
        //if (timer>3)
        //{
        //    print("imageTarget"+imageTarget.activeSelf);
        //    print("imageChildImage" + imageChildImage.activeSelf);
        //    print("otherImage" + otherImage.activeSelf);

        //    //Debug.Log(VuforiaRuntimeUtilities.IsPlayMode());
        //    timer = 0;
        //}
        //timer += Time.deltaTime;

    }
}
