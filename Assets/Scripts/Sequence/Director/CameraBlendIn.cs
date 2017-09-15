using Slate;
using Slate.ActionClips;
using UnityEngine;

[Category("Koala")]
public class CameraBlendIn : DirectorActionClip
{
    [SerializeField]
    [HideInInspector]
    private float _length = 1;

    public EaseType interpolation = EaseType.QuadraticInOut;
    private CameraBlendInOut _blendComponent;

    public override bool isValid { get { return FindObjectOfType<CameraBlendInOut>() != null; } }
    public override string info { get { return isValid ? base.info : "Can not find CameraBlendInOut"; } }
    public override float length { get { return _length; } set { _length = value; } }

    public override float blendIn { get { return length; } }
    protected override void OnEnter()
    {
        _blendComponent = FindObjectOfType<CameraBlendInOut>();
    }
    protected override void OnUpdate(float deltaTime)
    {
        if (length == 0)
        {
            _blendComponent.BlendProgress = 0;
            return;
        }
        _blendComponent.BlendProgress = Easing.Ease(interpolation, 1, 0, deltaTime / length);
    }

    protected override void OnReverse()
    {
        _blendComponent.BlendProgress = 1;
    }

}

