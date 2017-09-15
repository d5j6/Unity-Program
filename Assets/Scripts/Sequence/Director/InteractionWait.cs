using Slate;
using UnityEngine;

public abstract class InteractionWait : DirectorInteractionClip
{
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        InteractionObject.Enabled = true;
        InteractionObject.OnCompleted.AddListener(() => InteractionObject.Enabled = false);
        (root as Cutscene).Pause();
    }
    protected override void OnAfterValidate()
    {
        if (Application.isPlaying)
        {
            (root as Cutscene).Resume();
        }
    }
}
