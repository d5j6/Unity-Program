using UnityEngine;
namespace ResourceUtility
{
    public class AsyncResourceResult<TResult> : AsyncResult<TResult> where TResult : Object
    {
        private ResourceRequest _resourceCommand;
        public AsyncResourceResult(ResourceRequest resourceRequest)
        {
            _resourceCommand = resourceRequest;
            Command = new AsyncResourceCommand(resourceRequest);
        }
        public override TResult HandleResult()
        {
            return _resourceCommand.asset as TResult;
        }
    } 
}