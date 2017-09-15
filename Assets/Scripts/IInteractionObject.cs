using UnityEngine.Events;

public interface IInteractionObject
{
    void Show();
    void Hide();
    bool Completed { get; }
    bool IsShown { get; }
    UnityEvent OnCompleted { get; }
    void Complete();
    bool Enabled { get; set; }
    void Reset();
}
