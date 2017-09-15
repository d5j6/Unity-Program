using Slate.ActionClips;
using UnityEngine;
using Slate;
[Category("Koala/Interaction")]
public class Timing : ActorActionClip<Timer>
{

    [SerializeField]
    private float _length = 1;
    [SerializeField]
    private bool _reverseTime = false;

    public override float length
    {
        get { return _length; }
        set { _length = value; }
    }

    public override string info
    {
        get { return base.info + "\n" + length; }
    }

    protected override void OnUpdate(float time)
    {
        if (_reverseTime)
        {
            actor.Set(Easing.Ease(EaseType.Linear, _length, 0, time / length));
        }
        else
        {
            actor.Set(Easing.Ease(EaseType.Linear, 0, _length, time / length));
        }
    }
}
