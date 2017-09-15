
using System;
using UnityEngine;
using UnityEngine.UI;
public class Timer :UIInteractionInit,ITimer
{
    float addLengthInit = 0;
    [SerializeField]
    Transform creatPos;
    [SerializeField]
    Text FigureText;
    [SerializeField]
    GameObject timerPanel;
    private void Start()
    {
        if (creatPos == null)
        {
            creatPos = EyeCenterPos;
        }
        InstallPanelInit(transform , creatPos);
        FigureText.text = "0:00 s";
        timerPanel.SetActive(false);
    }
    public void SetInit(float addLength)
    {
        addLengthInit = addLength;
    }
    public void Set(float seconds)
    {
        seconds += addLengthInit;
        if (seconds > 0)
        {
            FigureText.text =  ((int)seconds).ToString() + ":" + (((seconds * 100) % 100) < 10 ? "0" : "") + ((int)((seconds * 100) % 100)).ToString() + " s";

        }
        else
        {
            FigureText.text = "0:00 s" ;
        }
    }
    protected override void OnHide()
    {
        timerPanel.SetActive(false);
        FigureText.text = "0:00 s";
    }

    protected override void OnShow()
    {
        timerPanel.SetActive(true);
    }
    protected override void OnUIDestroy()
    {
        Destroy(timerPanel);
    }
    protected override void OnMoving(GameObject movingAim)
    {
        StartCoroutine(MovePanel(gameObject, movingAim.transform));
    }
}


