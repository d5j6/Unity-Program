using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala/Interaction")]
[Description("Show ControlledInteractionObject")]
public class ShowInteractionObject : ActorActionClip<InteractionObject>
{
    public override string info { get { return "Show"; } }

    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.Show();
    }
}
