using UnityEngine.Networking;

namespace HttpUtility
{
    public class JsonCommandFactory : IAsyncRequestCommandFactory
    {
        private IInputHandler _inputHandler;
        public IInputHandler InputHandler
        {
            get
            {
                if (_inputHandler == null)
                {
                    _inputHandler = new JsonInputHandler();
                }
                return _inputHandler;
            }
        }

        public IAsyncRequestCommand<TResult> CreateCommand<TResult>(string url, params object[] parameters)
        {
            var rawData = InputHandler.HandleInputToRawData(parameters);
            var request = new UnityWebRequest()
            {
                url = url,
                uploadHandler = new UploadHandlerRaw(rawData) { contentType = "application/json" },
                downloadHandler = new DownloadHandlerBuffer(),
                method = "POST"
            };
            return new AsyncRequestCommand<TResult>(request, new JsonOutputHandler<TResult>());
        }
    }

}
