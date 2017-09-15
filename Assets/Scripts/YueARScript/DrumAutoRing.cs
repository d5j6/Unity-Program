
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum StickState
{
    autoStick, airMolecule//,waterWave
}
public class DrumAutoRing : MonoBehaviour
{
    [SerializeField]
    StickState stickModel;

    bool touchAutoWithDrum;
    bool isMove;

    [SerializeField]
    GameObject buttonController;
    [SerializeField]
    Transform startPlay;
    [SerializeField]
    Transform endPlay;
    [SerializeField]
    float stickDistance = 0.01F;
    [SerializeField]
    float speed = 0.02F;

    public void StartRing()
    {
        if (!isMove)
        {
            StartCoroutine(StickDown());
            isMove = true;
        }
    }
    IEnumerator StickDown()
    {
        Vector3 strickPos = startPlay.transform.position;
        var strick = gameObject.transform;
        while (Vector3.Distance(strickPos, strick.position) > stickDistance)
        {
            strick.position = Vector3.Lerp(strickPos, strick.position, speed);
            yield return new WaitForSeconds(0.05F);
            if (Vector3.Distance(strickPos, strick.position) < stickDistance)
            {
                strickPos = endPlay.transform.position;
            }
        }
        isMove = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "TopOfDrum")
        {
            col.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
