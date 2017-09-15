using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala/Interaction")]
[Description("Waiting action completed")]
public class WaitingActionClip : ActorActionClip<InteractionObject>
{
    public override string info { get { return "Wait"; } }

    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        actor.Enabled = true;
        var cutscene = (root as Cutscene);
        cutscene.Pause();

        actor.OnCompleted.AddListener(() =>
        {
            cutscene.Resume();
            actor.Enabled = false;
        });
    }

    protected override void OnAfterValidate()
    {
        if (Application.isPlaying)
        {
            (root as Cutscene).Resume();
        }
    }
}
