using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SingleButtonClipController : UIInteractionInit
{
    [SerializeField]
    GameObject arCameraManager;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    Button exitButton;
    private void InstallPlayerInit()
    {
        exitButton.onClick.AddListener(() =>
        {
            //Application.Quit();
            arCameraManager.GetComponent<YueTrackableEventHandler>().YueCutscene.Stop();
        });
        canvas.SetActive(false);
    }
    void Start()
    {
        InstallPlayerInit();
    }

    protected override void OnShow()
    {
        canvas.SetActive(true);
    }

    protected override void OnHide()
    {
        canvas.SetActive(false);
        arCameraManager.GetComponent<YueTrackableEventHandler>().SetPlayingAgain();
    }
}