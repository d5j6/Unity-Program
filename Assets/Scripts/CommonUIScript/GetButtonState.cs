using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum ButtonState
{
    Selected,UnSelected,Disenable,Enable
}
public class GetButtonState : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    bool decide;
    [SerializeField]
    ButtonState currentState = ButtonState.Disenable;

    public ButtonState CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }

    public bool Decide
    {
        get
        {
            return decide;
        }

        set
        {
            decide = value;
        }
    }

    void SetButtonState()
    {
        button.interactable = true;
        switch (currentState)
        {
            case ButtonState.Selected:
                button.gameObject.transform.localScale *= 1.25F;
                break;
            case ButtonState.UnSelected:
                if (decide)
                {
                    button.gameObject.transform.localScale *= 0.75F;
                }
                break;
            case ButtonState.Disenable:
                button.interactable = false;
                break;
            case ButtonState.Enable:
                button.interactable = true;
                break;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
    
    public void OnSubmit(BaseEventData eventData)
    {
        throw new NotImplementedException();
    }
}
