using UnityEngine;

namespace HttpUtility
{
    public interface IAsyncRequestCommand<TResult> : IAsyncCommand
    {
        string ResponseText { get; }
        IOutputHandler<TResult> OutputHandler { get; }
    }
}
