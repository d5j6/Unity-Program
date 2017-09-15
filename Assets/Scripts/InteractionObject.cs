using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractionObject : MonoBehaviour, IInteractionObject
{
    private UnityEvent _onCompleted = new UnityEvent();

    public UnityEvent OnCompleted
    {
        get { return _onCompleted; }
        set { _onCompleted = value; }
    }

    private bool _completed = false;
    public bool Completed
    {
        get { return _completed; }
        protected set { _completed = value; }
    }

    public bool IsShown { get; private set; }

    public virtual bool Enabled { get; set; }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
    public void Show()
    {
        Enabled = false; Completed = false;
        IsShown = true; OnShow();
    }
    public void Hide()
    {
        IsShown = false; OnHide();
    }

    #region QuestionAction
    protected virtual void OnCooling() { }
    public void CoolDown()
    {
        OnCooling();
    }
    protected virtual void OnMoving(GameObject movingAim) { }
    public void MoveToPos(GameObject movingAim)
    {
        OnMoving(movingAim);
    }
    protected virtual void OnAnnounce() { }
    public void Announce()
    {
        OnAnnounce();
    }
    protected virtual void OnChoose() { }
    public void Choose()
    {
        OnChoose();
    }
    protected virtual void OnUIDestroy() { }
    public void DestroyObject()
    {
        OnUIDestroy();
    }
    #endregion

    public void Complete()
    {
        if (!Completed)
        {
            Completed = true;
            OnCompleted.Invoke();
        }
        else
        {
            Debug.LogWarning("The action already completed.");
        }
    }

    public virtual void Reset() { }
}
