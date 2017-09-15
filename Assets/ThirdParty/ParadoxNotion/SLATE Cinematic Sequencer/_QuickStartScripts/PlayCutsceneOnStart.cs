using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Slate{

	[AddComponentMenu("SLATE/Play Cutscene On Start")]
	public class PlayCutsceneOnStart : MonoBehaviour {

		public Cutscene cutscene;
		public UnityEvent onFinish;

        public float startTime;

        void Start(){
			
			if (cutscene == null){
				Debug.LogError("Cutscene is not provided", gameObject);
				return;
			}

            cutscene.Play(startTime, () => { onFinish.Invoke(); });
            //cutscene.Play( ()=>{onFinish.Invoke();} );
        }

		public static GameObject Create(){
			return new GameObject("Cutscene Starter").AddComponent<PlayCutsceneOnStart>().gameObject;
		}
	}
}