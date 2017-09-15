using Slate;
using UnityEngine;

public abstract class InteractionHide : DirectorInteractionClip
{
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        InteractionObject.Hide();
    }

    protected override void OnExit()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        InteractionObject.OnCompleted.RemoveAllListeners();
    }
}
