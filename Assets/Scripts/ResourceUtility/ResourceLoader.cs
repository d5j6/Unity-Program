using System;
using System.Collections;
using UnityEngine;
namespace ResourceUtility
{

    public class ResourceLoader : MonoBehaviour
    {
        public static ResourceLoader Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("ResourceLoader already exists, will be destroyed.");
                Destroy(gameObject);
            }
        }
        public AsyncResult<T> AsyncLoadTo<T>(string path, T target) where T : UnityEngine.Object
        {
            return AsyncLoad<T>(path, res => target = res);
        }
        public AsyncResult<T> AsyncLoad<T>(string path, Action<T> onCompleted) where T : UnityEngine.Object
        {
            var result = AsyncLoad<T>(path);
            StartCoroutine(AsyncLoadCore(AsyncLoad<T>(path), onCompleted));
            return result;
        }

        public AsyncResult<T> AsyncLoad<T>(string path) where T : UnityEngine.Object
        {
            return new AsyncResourceResult<T>(Resources.LoadAsync<T>(path));
        }

        IEnumerator AsyncLoadCore<T>(AsyncResult<T> result, Action<T> onCompleted)
        {
            yield return result.WaitForCompleted();
            if (onCompleted != null)
            {
                onCompleted(result.Result); 
            }
        }
    }
}

