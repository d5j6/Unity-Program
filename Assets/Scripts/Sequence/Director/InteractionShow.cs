using Slate;
using UnityEngine;

public abstract class InteractionShow : DirectorInteractionClip
{
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        InteractionObject.OnCompleted.AddListener(() => (root as Cutscene).Resume());
        InteractionObject.Show();
    }
}
