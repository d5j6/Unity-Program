using System.Collections;

public interface IPreloadableData
{
    bool Preloaded { get; }
    float Progress { get; }
    void Preload();
}

