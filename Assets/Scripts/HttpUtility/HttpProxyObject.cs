using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HttpUtility
{

    public abstract class HttpProxyObject : MonoBehaviour
    {

        Queue<IAsyncCommand> _commands = new Queue<IAsyncCommand>();

        // Use this for initialization
        protected virtual void Start()
        {
            StartCoroutine(LoopQueue());
        }
        public AsyncRequestResult<TResult> Request<TResult>(IAsyncRequestCommand<TResult> operation)
        {
            _commands.Enqueue(operation);
            return new AsyncRequestResult<TResult>(operation);
        }


        IEnumerator LoopQueue()
        {
            while (true)
            {
                if (_commands.Count > 0)
                {
                    var command = _commands.Dequeue();
                    yield return command.CommandIterator;
                }
                else
                {
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }
}