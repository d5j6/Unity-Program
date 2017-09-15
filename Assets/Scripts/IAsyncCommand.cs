using UnityEngine;

public interface IAsyncCommand
{
    string Error { get; }
    AsyncOperation CommandIterator { get; }
}

