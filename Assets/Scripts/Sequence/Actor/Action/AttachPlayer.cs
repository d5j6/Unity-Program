using Slate;
using Slate.ActionClips;
using UnityEngine;


[Category("Koala")]
[Description("Attach player to this object")]
public class AttachPlayer : ActorActionClip
{
    public Vector3 localPosition = Vector3.zero;
    public Vector3 localRotation = Vector3.zero;
    public Vector3 localScale = Vector3.one;

    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        GameManager.Instance.Player.AttachToTarget(actor.transform, localPosition, Quaternion.Euler(localRotation), localScale);
    }
}
