using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala/Interaction")]
[Description("Destroy ControlledInteractionObject")]
public class DestroyInteractionObject : ActorActionClip<InteractionObject>
{
    public override string info { get { return "Destroy"; } }
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.DestroyObject();
    }
}