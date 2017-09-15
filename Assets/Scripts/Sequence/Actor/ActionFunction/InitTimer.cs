using Slate;
using Slate.ActionClips;
using UnityEngine;
[Category("Koala/Interaction")]
public class InitTimer : ActorActionClip<Timer>
{
    [SerializeField]
    private float _addLength = 0;
    [SerializeField]
    private float _initTime = 0f;

    public override string info
    {
        get { return base.info + ":" + _initTime ; }
    }

    protected override void OnEnter()
    {
        //actor.Set( _initTime);
        actor.SetInit(_addLength);
    }
}

