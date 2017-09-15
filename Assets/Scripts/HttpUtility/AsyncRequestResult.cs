using System;
using System.Collections;
using UnityEngine;

namespace HttpUtility
{

    public class AsyncRequestResult<TResult> : AsyncResult<TResult>
    {
        public AsyncRequestResult(IAsyncRequestCommand<TResult> command)
        {
            Command = command;
        }

        public override TResult HandleResult()
        {
            var requestCommand = Command as IAsyncRequestCommand<TResult>;
            return requestCommand.OutputHandler.ConvertOutput(requestCommand.ResponseText.Trim());
        }
    }
}
