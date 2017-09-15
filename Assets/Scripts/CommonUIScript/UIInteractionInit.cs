using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractionInit : InteractionObject
{
    private Vector3 panelSlant = new Vector3(0, 0, 0);
    public delegate void DelegateMethod();
    public delegate void DelegateMethodWithParameter(float defineData);
    private GameObject playerController;
    private PlayerOperationManager playManager;
    private Transform UICenterPos;
    private List<GameObject> itemButton = new List<GameObject>();
    private GameObject currentPanel;
    public Vector3 PanelSlant { get { return panelSlant; } set { panelSlant = value; } }

    public List<GameObject> ItemButton { get { return itemButton; } set { itemButton = value; } }

    public GameObject PlayerController { get { return playerController; } set { playerController = value; } }

    public Transform EyeCenterPos { get { return UICenterPos; } set { UICenterPos = value; } }

    public GameObject CurrentPanel { get { return currentPanel; } set { currentPanel = value; } }

    public PlayerOperationManager PlayManager { get { return playManager; } set { playManager = value; } }

    public void UIInit()
    {
        if (PlayerController == null)
        {
            PlayerController = GameManager.Instance.Player.gameObject;
            if (playManager == null)
            {
                playManager = PlayerController.GetComponent<PlayerOperationManager>();
            }
        }
        if (UICenterPos == null)
        {
            UICenterPos = PlayerController.GetComponent<PlayerUIPointManager>().UICenterTarget;
        }
    }
    public void UIInteractionShow()
    {
        StartCoroutine(WaitSeconds(() =>
        {
            PlayManager.SetCurrentPanelState(GetComponent<UIInteractionInit>());
            AxisKeyInit();
        }, 0.4F));
    }
    public void UIFinish()
    {
        PlayManager.AfterCurrentPanelUse(GetComponent<UIInteractionInit>());
        itemButton.Clear();
    }

    public void MainUIShow()
    {
        PlayManager.SetMainUIPanelState(GetComponent<UIInteractionInit>());
        AxisKeyInit();
    }
    public void MainUIFinish()
    {
        PlayManager.AfterMainUIPanelUse(GetComponent<UIInteractionInit>());
        itemButton.Clear();
    }
    public void UseCurrentUI(GameObject uiPanel)
    {
        var panel = uiPanel.GetComponent<UIInteractionInit>();
        if (uiPanel.activeSelf)
        {
            PlayManager.SetCurrentPanelState(panel);
        }
        else
        {
            PlayManager.AfterCurrentPanelUse(panel);
        }
    }


    public void InstallPlayerInit(GameObject UIPanel, Transform parentPos)
    {
        var panel = UIPanel.transform;
        panel.SetParent(parentPos);
        panel.localPosition = Vector3.zero;
        panel.localRotation = Quaternion.Euler(panelSlant);
    }

    public IEnumerator MovePanel(GameObject panel, Transform targetPos)
    {
        panel.transform.SetParent(targetPos);
        while (Vector3.Distance(panel.transform.position, targetPos.position) > 0.01F)
        {
            yield return new WaitForSeconds(0.03F);
            panel.transform.position = Vector3.Lerp(panel.transform.position, targetPos.position, 0.25F);
        }

        var start = panel.transform.localRotation;
        var end = targetPos.localRotation;

        while (panel.transform.localRotation.y != 0)
        {
            yield return new WaitForSeconds(0.03f);
            panel.transform.localRotation = Quaternion.Lerp(panel.transform.localRotation, Quaternion.Euler(Vector3.zero), 0.3F);
        }
    }

    public void InstallPanelInit(Transform panel, Transform parentPos)
    {
        panel.SetParent(parentPos);
        panel.localPosition = Vector3.zero;
        panel.localRotation = Quaternion.Euler(panelSlant);
    }

    public void SetChildEnable(GameObject parent, bool isActive)
    {
        for (int i = 0; i < parent.transform.childCount; ++i)
        {
            parent.transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }

    public void SetOneButtonEnable(GameObject itemButton, bool isActive)
    {
        if (itemButton.GetComponent<Button>() != null)
        {
            itemButton.GetComponent<Button>().interactable = isActive;
        }
    }

    public void SetButtonEnable(List<GameObject> itemButton, bool isActive)
    {
        for (int i = 0; i < itemButton.Count; ++i)
        {
            if (itemButton[i].GetComponent<Button>() != null)
            {
                itemButton[i].GetComponent<Button>().interactable = isActive;
            }
            else if (itemButton[i].GetComponent<Toggle>() != null)
            {
                itemButton[i].GetComponent<Toggle>().interactable = isActive;
            }
            else if (itemButton[i].GetComponent<Slider>() != null)
            {
                itemButton[i].GetComponent<Slider>().interactable = isActive;
            }
            else
            {
                Debug.Log("TGS --- Something of interaction type is worry!");
            }
        }
    }

    public void SetButtonInit(GameObject button, DelegateMethod action)
    {
        button.GetComponent<Button>().onClick.AddListener(() =>
        {
            action();
        });
        AddItemList(button);
    }

    public void SetCheckInit(GameObject button, DelegateMethod action)
    {
        button.GetComponent<Toggle>().onValueChanged.AddListener(obj =>
        {
            action();
        });
        AddItemList(button);
    }

    public void SetSliderInit(GameObject button, DelegateMethod action)
    {
        button.GetComponent<Slider>().onValueChanged.AddListener(obj =>
        {
            action();
        });
        AddItemList(button);
    }

    public IEnumerator WaitOneSecond(DelegateMethod action)
    {
        yield return new WaitForSeconds(1.2F);
        action();
    }

    public IEnumerator WaitSeconds(DelegateMethod action, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }

    public void AddItemList(GameObject button)
    {
        itemButton.Add(button);
    }

    //伪点击事件
    public void GetButtonInvoke()
    {
        for (int i = 0; i < ItemButton.Count; i++)
        {
            if (ItemButton[i].GetComponent<GetButtonState>().Decide)
            {
                if (itemButton[i].GetComponent<Button>() != null)
                {
                    itemButton[i].GetComponent<Button>().onClick.Invoke();
                }
                else
                {
                    Debug.Log("TGS --- Something of interaction type is worry!");
                }
            }
        }
    }
    public void GetButtonInvoke(Button button)
    {
        if (button.interactable)
        {
            button.onClick.Invoke();
        }
    }
    public bool IsMainUse()
    {
        return GetComponent<UIInteractionInit>() == PlayManager.MainUIPanel;
    }
    public bool IsMainUse(GameObject panel)
    {
        return panel.GetComponent<UIInteractionInit>() == PlayManager.MainUIPanel;
    }
    public bool IsHankUse()
    {
        return GetComponent<UIInteractionInit>() == PlayManager.CurrentPanel && PlayManager.IsMainUIShow();
    }
    public bool IsHankUse(GameObject panel)
    {
        return panel.GetComponent<UIInteractionInit>() == PlayManager.CurrentPanel && PlayManager.IsMainUIShow();
    }
    /// <summary>
    /// 手柄方向键
    /// </summary>
    /// <param name="index">0为水平，1为竖直</param>
    /// <returns></returns>
    public float GetAxisPanelKey(int index)
    {
        string name = "Vertical";
        if (index == 0)
        {
            name = "Horizontal";
        }
        return Input.GetAxis(name);
    }

    /// <summary>
    /// 按键事件添加
    /// </summary>
    /// <param name="x">按键名</param>
    /// <param name="keyState">监听模式</param>
    /// <param name="action">添加事件</param>
    public void GetPanelKeyState(KeyCode x, KeyState keyState, DelegateMethod action)
    {
        switch (keyState)
        {
            case KeyState.Down:
                if (Input.GetKeyDown(x)) action();
                break;
            case KeyState.Key:
                if (Input.GetKey(x)) action();
                break;
            case KeyState.Up:
                if (Input.GetKeyUp(x)) action();
                break;
            default:
                if (Input.GetKeyDown(x)) action();
                break;
        }
    }

    public void SwitchGetKey(List<KeyModelDetail> keyActionArray)
    {
        switch (GameManager.Instance.PlayDevice)
        {
            case PlayDevice.Standalone:
                for (int i = 0; i < keyActionArray.Count; i++)
                {
                    GetPanelKeyState(keyActionArray[i].Keyboard, keyActionArray[i].StateInput, keyActionArray[i].Action);
                }
                break;
            case PlayDevice.GearVR:
                break;
            case PlayDevice.Vive:
                break;
            case PlayDevice.Pico:
                for (int i = 0; i < keyActionArray.Count; i++)
                {
                    GetPanelKeyState(PicoKeySwitch(keyActionArray[i].Keyboard), keyActionArray[i].StateInput, keyActionArray[i].Action);
                }
                break;
        }
    }

    public KeyCode PicoKeySwitch(KeyCode keyboard)
    {
        switch (keyboard)
        {
            case KeyCode.K: return KeyCode.Joystick1Button0;
            case KeyCode.L: return KeyCode.Joystick1Button1;
            case KeyCode.J: return KeyCode.Joystick1Button2;
            case KeyCode.I: return KeyCode.Joystick1Button3;
            case KeyCode.Q: return KeyCode.Joystick1Button4;
            case KeyCode.O: return KeyCode.Joystick1Button5;
            case KeyCode.B: return KeyCode.Menu;
            case KeyCode.N: return KeyCode.Escape;
            default: return KeyCode.Joystick1Button1;
        }
    }
    // Pico对应按键               //手柄  //键盘
    //(KeyCode.Joystick1Button0) //A     //K
    //(KeyCode.Joystick1Button1) //B     //L
    //(KeyCode.Joystick1Button2) //X     //J
    //(KeyCode.Joystick1Button3) //Y     //I
    //(KeyCode.Joystick1Button4) //L     //Q
    //(KeyCode.Joystick1Button5) //R     //O
    //(KeyCode.Menu)             //菜单键 //B
    //(KeyCode.Escape)           //返回键 //N
    //float a = Input.GetAxis("Horizontal"); 获取手柄左边左右；
    //float b = Input.GetAxis("Vertical"); 获取手柄左边上下方向；

    //A D W S 按键
    public KeyValue A; //(KeyCode.Joystick1Button2))//X
    public KeyValue D; //(KeyCode.Joystick1Button1))//B
    public KeyValue S; //(KeyCode.Joystick1Button0))//A
    public KeyValue W; //(KeyCode.Joystick1Button3))//Y

    public void AxisKeyInit()
    {
        if (A == null)
        {
            A = new KeyValue(false);
            D = new KeyValue(false);
            S = new KeyValue(false);
            W = new KeyValue(false);
        }
        else
        {
            A.Value = false;
            D.Value = false;
            S.Value = false;
            W.Value = false;
        }
    }

    /// <summary>
    /// 上下左右控制
    /// </summary>
    /// <param name="key">按键</param>
    /// <param name="action">功能</param>
    public void GetAxisKeyDown(KeyValue key, DelegateMethod action)
    {
        bool symbol = false;

        string KeyAxisName = "Horizontal";
        if (key == A || key == S)
            symbol = true;
        if (key == W || key == S)
            KeyAxisName = "Vertical";
        if (!key.Value && (symbol ? (Input.GetAxis(KeyAxisName) < 0) : (Input.GetAxis(KeyAxisName) > 0)))
        {
            key.Value = !key.Value;
        }

        if (key.Value && Mathf.Abs(Input.GetAxis(KeyAxisName)) < 0.01F)
        {
            key.Value = !key.Value;
            action();
        }
    }

    /// <summary>
    /// 上下左右键带参控制
    /// </summary>
    /// <param name="key">按键</param>
    /// <param name="action">功能(带参数)</param>
    public void GetAxisKeyDown(KeyValue key, DelegateMethodWithParameter action)
    {
        bool symbol = false;

        string KeyAxisName = "Horizontal";
        if (key == A || key == S)
            symbol = true;
        if (key == W || key == S)
            KeyAxisName = "Vertical";
        if (!key.Value && (symbol ? (Input.GetAxis(KeyAxisName) < 0) : (Input.GetAxis(KeyAxisName) > 0)))
        {
            key.Value = !key.Value;
        }

        if (key.Value && Mathf.Abs(Input.GetAxis(KeyAxisName)) < 0.01F)
        {
            key.Value = !key.Value;
            action(Input.GetAxis(KeyAxisName));
        }
    }
}

public enum KeyState
{
    Down, Key, Up
}

/// <summary>
/// 方向键类型
/// </summary>
public class KeyValue
{
    private bool value;
    public KeyValue(bool value)
    {
        Value = value;
    }
    public bool Value { get { return value; } set { this.value = value; } }
}


public class KeyModelDetail
{
    KeyCode keyboard;
    KeyState stateInput;
    UIInteractionInit.DelegateMethod action;

    public KeyModelDetail(KeyCode keyboard, KeyState stateInput, UIInteractionInit.DelegateMethod action)
    {
        this.Keyboard = keyboard;
        this.StateInput = stateInput;
        this.Action = action;
    }
    public KeyCode Keyboard { get { return keyboard; } set { keyboard = value; } }
    public KeyState StateInput { get { return stateInput; } set { stateInput = value; } }
    public UIInteractionInit.DelegateMethod Action { get { return action; } set { action = value; } }
    
}
