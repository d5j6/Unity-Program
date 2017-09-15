using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala")]
[Description("Attach this object to player")]
public class AttachToPlayer : ActorActionClip
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
        actor.transform.SetParent(GameManager.Instance.Player.transform);
        actor.transform.localPosition = localPosition;
        actor.transform.localRotation = Quaternion.Euler(localRotation);
        actor.transform.localScale = localScale;
    }
}
