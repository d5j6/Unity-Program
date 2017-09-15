using Slate;
using Slate.ActionClips;
using UnityEngine;

[Category("Koala/Interaction")]
[Description("Choose ControlledInteractionObject")]
public class ChooseInteractionObject : ActorActionClip<InteractionObject>
{
    public override string info { get { return "Choose"; } }
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.Choose();
    }
}