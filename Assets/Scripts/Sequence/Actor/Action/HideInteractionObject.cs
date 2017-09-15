using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala/Interaction")]
[Description("Hide ControlledInteractionObject")]
public class HideInteractionObject : ActorActionClip<InteractionObject>
{
    public override string info { get { return "Hide"; } }
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.Hide();
        actor.OnCompleted.RemoveAllListeners();
    }
}
