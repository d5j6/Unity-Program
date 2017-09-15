using HttpUtility;
using System.Text;
using UnityEngine;

namespace KWS
{
    internal class KWSProxyObject : HttpProxyObject
    {
        [SerializeField]
        private string _url = @"http://localhost";
        public string Url { get { return _url; } }

        public string GetActionUrl(string controller, string method)
        {
            var sb = new StringBuilder();
            sb.Append(Url);
            if (Url[Url.Length - 1] != '/' && Url[Url.Length - 1] != '\\')
            {
                sb.Append("/");
            }
            sb.Append("api" + "/" + controller + "/" + method);
            return sb.ToString();
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("KWSProxyObject already exists, will be destroyed.");
                Destroy(gameObject);
            }
        }

        protected override void Start()
        {
            DontDestroyOnLoad(this);
            base.Start();
        }

        private static KWSProxyObject _instance;
        public static KWSProxyObject Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("HttpProxyObject not found.");
                }
                return _instance;
            }
            private set
            {
                if (_instance != null && value != null)
                {
                    Debug.LogWarning("HttpProxyObject already existed.");
                }
                else
                {
                    _instance = value;
                }
            }
        }
    }
}
