using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UIPosTarget
{
    Center, Head, Forward, Below, Menu, Left, Right
}
public class PlayerUIPointManager : MonoBehaviour
{
    [SerializeField]
    Transform uiCenterTarget;
    [SerializeField]
    Transform uiHeadTarget;
    [SerializeField]
    Transform uiForwardTarget;
    [SerializeField]
    Transform uiBelowTarget;
    [SerializeField]
    Transform uiMenuTarget;
    [SerializeField]
    Transform uiLeftTarget;
    [SerializeField]
    Transform uiRightTarget;

    public Transform UICenterTarget { get { return uiCenterTarget; } }
    public Transform UIHeadTarget { get { return uiHeadTarget; } }
    public Transform UIForwardTarget { get { return uiForwardTarget; } }
    public Transform UIBelowTarget { get { return uiBelowTarget; } }
    public Transform UIMenuTarget { get { return uiMenuTarget; } }
    public Transform UILeftTarget { get { return uiLeftTarget; } }
    public Transform UIRightTarget { get { return uiRightTarget; } }

    public Transform ChangeUIPosTarget(UIPosTarget uiTarget)
    {
        switch (uiTarget)
        {
            case UIPosTarget.Center:
                return UICenterTarget;
            case UIPosTarget.Head:
                return UIHeadTarget;
            case UIPosTarget.Forward:
                return UIForwardTarget;
            case UIPosTarget.Below:
                return UIBelowTarget;
            case UIPosTarget.Menu:
                return UIMenuTarget;
            case UIPosTarget.Left:
                return UILeftTarget;
            case UIPosTarget.Right:
                return UIRightTarget;
            default:
                return UICenterTarget;
        }
    }
}
