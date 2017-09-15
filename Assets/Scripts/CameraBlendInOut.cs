using UnityEngine;
[ExecuteInEditMode]
public class CameraBlendInOut : MonoBehaviour
{
    [SerializeField]
    private float _blendProgress;
    public float BlendProgress
    {
        get { return _blendProgress; }
        set { _blendProgress = value; }
    }
    private Material _blendMaterial;

    private void Awake()
    {
        _blendMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
    }

    void OnPostRender()
    {
        if (_blendProgress == 0)
        {            
            return;
        }

        _blendMaterial.SetPass(0);
        _blendMaterial.color = new Color(0.0f, 0.0f, 0.0f, _blendProgress);
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Color(_blendMaterial.color);
        GL.Begin(GL.QUADS);
        GL.Vertex3(0f, 0f, -12f);
        GL.Vertex3(0f, 1f, -12f);
        GL.Vertex3(1f, 1f, -12f);
        GL.Vertex3(1f, 0f, -12f);
        GL.End();
        GL.PopMatrix();
    }

    //private void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //    if (_blendProgress == 0)
    //    {
    //        Graphics.Blit(source, destination);
    //        return;
    //    }

    //    _blendMaterial.SetFloat("_blendProgress", Mathf.Clamp01(_blendProgress));
    //    Graphics.Blit(source, destination, _blendMaterial);
    //}
}
