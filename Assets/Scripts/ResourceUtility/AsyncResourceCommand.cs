using UnityEngine;

namespace ResourceUtility
{
    public class AsyncResourceCommand : IAsyncCommand
    {
        private ResourceRequest _resourceRequest;
        public AsyncResourceCommand(ResourceRequest resourceRequest)
        {
            CommandIterator = resourceRequest;
            _resourceRequest = resourceRequest;
        }
        public AsyncOperation CommandIterator { get; private set; }

        public string Error
        {
            get { return (_resourceRequest.isDone && _resourceRequest.asset == null) ? "Resource load failed." : null; }
        }
    } 
}
