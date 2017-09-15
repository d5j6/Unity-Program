using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala/Interaction")]
[Description("CoolDown ControlledInteractionObject")]
public class CoolDownInteractionObject : ActorActionClip<InteractionObject>
{
    public override string info { get { return "CoolDown"; } }
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.CoolDown();
    }
}