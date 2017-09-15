namespace HttpUtility
{
    public interface IAsyncRequestCommandFactory
    {
        IInputHandler InputHandler { get; }
        IAsyncRequestCommand<TResult> CreateCommand<TResult>(string url, params object[] parameters);
    }
}
