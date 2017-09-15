namespace HttpUtility
{
    public interface IOutputHandler<TResult>
    {
        TResult ConvertOutput(string responseText);
    }
}