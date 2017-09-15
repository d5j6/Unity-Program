using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOperationManager : MonoBehaviour
{
    [SerializeField]
    private bool isPlaying;
    [SerializeField]
    private UIInteractionInit currentPanel;
    [SerializeField]
    private UIInteractionInit mainUIPanel;
    public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
    public UIInteractionInit CurrentPanel { get { return currentPanel; } set { currentPanel = value; } }
    private List<UIInteractionInit> currentArray = new List<UIInteractionInit>();
    public UIInteractionInit MainUIPanel { get { return mainUIPanel; } set { mainUIPanel = value; } }
    private List<UIInteractionInit> mainUIArray = new List<UIInteractionInit>();
    public bool IsMainUIShow()
    {
		//print (MainUIPanel== null); //+ "MainUIPanel:null-->"+ MainUIPanel == null);
        return mainUIArray.Count==0 && MainUIPanel == null;
    }
    public void SetCurrentPanelState(UIInteractionInit uiInteraction)
    {
        //print("Get:"+ uiInteraction.gameObject.name);
        if (IsPlaying)
        {
            if (CurrentPanel!=null)
            {
                currentArray.Add(CurrentPanel);
            }
            CurrentPanel = uiInteraction;
        }
    }
    public void SetMainUIPanelState(UIInteractionInit uiInteraction)
    {
        //print("Lost"+ uiInteraction.gameObject.name);
        if (IsPlaying)
        {
            if (MainUIPanel != null)
            {
                mainUIArray.Add(MainUIPanel);
            }
            MainUIPanel = uiInteraction;
        }
    }

    void DecideOnePanel(List<UIInteractionInit> array, UIInteractionInit one)
    {
        if (array.Count > 0)
        {
            //print("currentArray-last:=============" + array[array.Count - 1].gameObject.name);
			//print("currentPanel-Remove:==============" + one.gameObject.name);
            one = array[array.Count - 1];
            array.Remove(array[array.Count - 1]);
			//print("currentPanel:==============" + one.gameObject.name);
        }
        else
        {
			//print("currentPanel:=========Null" + one.gameObject.name);
            one = null;
        }
    }
    
    public void AfterMainUIPanelUse(UIInteractionInit uiInteraction)
    {
        //print(uiInteraction.gameObject.name);
        if (uiInteraction == MainUIPanel)
        {
            //DecideOnePanel(mainUIArray, MainUIPanel);
			if (mainUIArray.Count > 0)
			{
				//print("currentArray-last:=============" + mainUIArray[mainUIArray.Count - 1].gameObject.name);
				//print("currentPanel-Remove:==============" + MainUIPanel.gameObject.name);
				MainUIPanel = mainUIArray[mainUIArray.Count - 1];
				mainUIArray.Remove(mainUIArray[mainUIArray.Count - 1]);
				//print("currentPanel:==============" + MainUIPanel.gameObject.name);
			}
			else
			{
				//print("currentPanel:=========Null" + MainUIPanel.gameObject.name);
				MainUIPanel = null;
			}
        }
    }

    public void AfterCurrentPanelUse(UIInteractionInit uiInteraction)
    {
        //print(uiInteraction.gameObject.name);
        if( uiInteraction == CurrentPanel)
        {
            //DecideOnePanel(currentArray, CurrentPanel);
			if (currentArray.Count > 0)
			{
				//print("currentArray-last:=============" + currentArray[currentArray.Count - 1].gameObject.name);
				//print("currentPanel-Remove:==============" + CurrentPanel.gameObject.name);
				CurrentPanel = currentArray[currentArray.Count - 1];
				currentArray.Remove(currentArray[currentArray.Count - 1]);
				//print("currentPanel:==============" + CurrentPanel.gameObject.name);
			}
			else
			{
				//print("currentPanel:=========Null" + CurrentPanel.gameObject.name);
				CurrentPanel = null;
			}
        }
    }

    void Start()
    {
        IsPlaying = true;
    }
    
}

//public void BeforeShow(GameObject current)
//{
//    if (IsPlaying)
//    {
//        if (current.GetComponent<UIInteractionInit>())
//        {
//            CurrentPanel = current.GetComponent<UIInteractionInit>();
//        }
//        else
//        {
//            Debug.Log(current.name + "Don't have Component with");
//        }
//    }
//}

//bool isInArray = false;
//int index = -1;
//for (int i = 0; i < currentArray.Count; i++)
//{
//    print("currentArray:" + currentArray[i].gameObject.name);
//    if(currentArray[i] == uiInteraction)
//    {
//        isInArray = true;
//        index = i;
//        break;
//    }
//}
//if (isInArray)
//{
//    if (index == currentArray.Count - 1)
//    {
//        CurrentPanel = currentArray[currentArray.Count - 1];
//        currentArray.Remove(currentArray[currentArray.Count - 1]);
//    }
//    else
//    {
//        Debug.Log("UIInteractionInit object index has error!!!");
//    }
//}
//else
//{
//    Debug.Log("UIInteractionInit not exit!!!");
//}