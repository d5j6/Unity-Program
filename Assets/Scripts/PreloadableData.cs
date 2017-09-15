using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public abstract class PreloadableData : DataObject, IPreloadableData, IWaitable
{
    public PreloadableData()
    {
        Preload();
    }
    public List<IWaitable> PreloadActions { get; protected set; }
    public bool Preloaded { get { return Progress >= 1; } }

    public float Progress
    {
        get { return PreloadActions.Sum(act => act.Progress) / PreloadActions.Count; }
    }

    public abstract void Preload();

    public IEnumerator WaitForCompleted()
    {
        if (!Preloaded)
        {
            yield return new WaitForSeconds(0.2f);
        }
    }
}

