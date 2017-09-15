using Slate;
using Slate.ActionClips;
using UnityEngine;

[Category("Koala/Interaction")]
[Description("Announce ControlledInteractionObject")]
public class AnnounceInteractionObject : ActorActionClip<InteractionObject>
{
    public override string info { get { return "Announce"; } }
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.Announce();
    }
}
