using Slate;
using Slate.ActionClips;
using UnityEngine;

[Category("Koala/Interaction")]
[Description("Move ControlledInteractionObject")]
public class MoveInteractionObject : ActorActionClip<InteractionObject>
{
    [Required]
    public GameObject movingAim;
    
    public override string info { get { return "Moving"; } }
    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.MoveToPos(movingAim);
    }
}


