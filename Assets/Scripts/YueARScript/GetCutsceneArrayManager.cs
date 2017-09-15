using Slate;
using UnityEngine;

public class GetCutsceneArrayManager : MonoBehaviour
{
    [SerializeField]
    Cutscene[] cutsceneArray;
    public void SetCurrentCutscene(Cutscene current)
    {
        for (int i = 0; i < cutsceneArray.Length; i++)
        {
            if (current != cutsceneArray[i])
            {
                cutsceneArray[i].Stop();
            }
        }
    }
}
