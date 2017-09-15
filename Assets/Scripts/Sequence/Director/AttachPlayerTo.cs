using Slate;
using UnityEngine;

[Category("Koala")]
[Description("Attach player to the target object")]
public class AttachPlayerTo : DirectorActionClip
{
    [Required]    public Transform _target;

    public Vector3 localPosition = Vector3.zero;
    public Vector3 localRotation = Vector3.zero;
    public Vector3 localScale = Vector3.one;

    //public override string info
    //{
    //    get { return "Attach Player To\n" + _target == null ? "(null)" : _target.name; }
    //}

    public override bool isValid 
    {
        get { return _target != null; }
    }

    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        GameManager.Instance.Player.AttachToTarget(_target, localPosition, Quaternion.Euler(localRotation), localScale);
    }
}

