using Slate;
using UnityEngine;
using UnityEngine.SceneManagement;
[Category("Koala")]
public class LoadScene : DirectorActionClip
{
    public string sceneName;

    public override string info
    {
        get { return base.info + "\n" + sceneName; }
    }

    protected override void OnEnter()
    {
        if (!Application.isPlaying)
        {
            return;
        }
        GameManager.Instance.Player.transform.parent = GameManager.Instance.transform;
        SceneManager.LoadScene(sceneName);
    }

}

