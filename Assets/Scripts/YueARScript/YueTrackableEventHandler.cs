using Slate;
using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class YueTrackableEventHandler : MonoBehaviour
    {
        [SerializeField]
        GameObject cutsceneManager;
        [SerializeField]
        GameObject detectionModel;
        [SerializeField]
        GameObject yueModel;
        [SerializeField]
        Cutscene yueCutscene;
        bool isPlayModel;

        public Cutscene YueCutscene
        {
            get
            {
                return yueCutscene;
            }

            set
            {
                yueCutscene = value;
            }
        }

        public void SetPlayingAgain()
        {
            isPlayModel = false;
        }
        
        void Start()
        {
            isPlayModel = false;
            yueModel.SetActive(false);
        }

        private void Update()
        {
            if (detectionModel.GetComponent<Renderer>().enabled)
            {
                if (!isPlayModel)
                {
                    yueModel.SetActive(true);
                    cutsceneManager.GetComponent<GetCutsceneArrayManager>().SetCurrentCutscene(yueCutscene);
                    yueCutscene.Play(0);
                    isPlayModel = false;
                }
            }
        }
    }
}
