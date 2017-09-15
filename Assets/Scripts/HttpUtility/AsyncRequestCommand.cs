using UnityEngine;
using UnityEngine.Networking;

namespace HttpUtility
{
    public class AsyncRequestCommand<TResult> : IAsyncRequestCommand<TResult>
    {
        UnityWebRequest _request;
        public AsyncRequestCommand(UnityWebRequest request, IOutputHandler<TResult> outputHandler)
        {
            _request = request;
            OutputHandler = outputHandler;
        }
        private AsyncOperation _commandIterator;
        public AsyncOperation CommandIterator
        {
            get
            {
                if (_commandIterator == null)
                {
                    _commandIterator = _request.Send();
                }
                return _commandIterator;
            }
        }

        public string Error
        {
            get { return _request.isError ? _request.error : null; }
        }

        public string ResponseText
        {
            get { return _request.downloadHandler.text; }
        }

        public IOutputHandler<TResult> OutputHandler { get; private set; }
    }
}
