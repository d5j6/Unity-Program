using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARDrumButtonClipController : UIInteractionInit
{
    [SerializeField]
    GameObject arCameraManager;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject stick;
    [SerializeField]
    Button button;
    [SerializeField]
    Button exitButton;
    private void InstallPlayerInit()
    {
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        button.onClick.AddListener(() =>
        {
            stick.GetComponent<DrumAutoRing>().StartRing();
        });
        button.interactable = false;
        canvas.SetActive(false);
    }
    void Start()
    {
        InstallPlayerInit();
    }

    protected override void OnShow()
    {
        stick.SetActive(true);
        button.interactable = true;
        canvas.SetActive(true);
    }

    protected override void OnHide()
    {
        canvas.SetActive(false);
        stick.SetActive(false);
        button.interactable = false;
        arCameraManager.GetComponent<YueTrackableEventHandler>().SetPlayingAgain();
    }
}
