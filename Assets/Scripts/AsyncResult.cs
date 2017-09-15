using System.Collections;
using UnityEngine;
public interface IWaitable
{
    float Progress { get; }
    IEnumerator WaitForCompleted();
}
public abstract class AsyncResult<TResult> : IWaitable
{
    public IAsyncCommand Command { get; protected set; }

    private bool _isCompleted = false;
    public bool IsCompleted
    {
        get { return _isCompleted; }
        protected set { _isCompleted = value; }
    }

    private TResult _result = default(TResult);
    public TResult Result
    {
        get { return _result; }
        protected set { _result = value; }
    }

    private bool _isError = false;
    public bool IsError
    {
        get { return _isError; }
        protected set { _isError = value; }
    }
    private string _errorInfo = null;
    public string ErrorInfo
    {
        get { return _errorInfo; }
        protected set { _errorInfo = value; }
    }

    public float Progress
    {
        get { return Command.CommandIterator.progress; }
    }

    public IEnumerator WaitForCompleted()
    {
        if (Command != null)
        {
            while (!Command.CommandIterator.isDone)
            {
                yield return new WaitForSeconds(0.1f);
            }
            if (IsError = (Command != null))
            {
                Debug.LogError(Command.Error);
                ErrorInfo = Command.Error;
            }
            else
            {
                try
                {
                    Result = HandleResult();
                }
                catch (System.Exception ex)
                {
                    ErrorInfo = ex.ToString();
                    Debug.LogError(ErrorInfo);
                }
            }
        }
        else
        {
            IsError = true;
            ErrorInfo = "Command not initialized.";
            Debug.LogError(ErrorInfo);
        }
        IsCompleted = true;
    }

    public abstract TResult HandleResult();
}

