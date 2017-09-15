using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _handTransformRoot;

    public GameObject HandTransformRoot
    {
        get { return _handTransformRoot; } 
    }

    [SerializeField]
    private LessonData _currentLesson;
    public LessonData CurrentLesson
    {
        get { return _currentLesson; }
        set { _currentLesson = value; }
    }

    public IControllerBehavior PlayerControllerBehavior;

    void Start()
    {
        Application.runInBackground = false;
        switch (GameManager.Instance.PlayDevice)
        {
            case PlayDevice.Standalone:
                PlayerControllerBehavior = new StandaloneControllerBehavior(this);
                break;
            case PlayDevice.GearVR:
            case PlayDevice.Vive:
                PlayerControllerBehavior = new VRControllerBehavior(this);
                HandTransformRoot.SetActive(true);
                break;
            case PlayDevice.Pico:
                PlayerControllerBehavior = new PicoVRControllerBehavior(this);
                break;
        }
    }

    public void AttachToTarget(Transform target, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
    {
        transform.SetParent(target);
        if (GameManager.Instance.PlayDevice == PlayDevice.Standalone || GameManager.Instance.PlayDevice == PlayDevice.GearVR)
        {
            transform.localPosition = localPosition + Vector3.up * 1;
        }
        else
        {
            transform.localPosition = localPosition;
        }
        transform.localRotation = localRotation;
        transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerBehavior != null)
        {
            PlayerControllerBehavior.UpdateBehavior(); 
        }
    }
}
