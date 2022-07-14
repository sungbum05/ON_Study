using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IsPauseObj : MonoBehaviour
{
    private RunGameManager RunGameManager;
    void Start()
    {
        RunGameManager = RunGameManager.Instance;
    }
    protected virtual void Update()
    {
        if (RunGameManager.isPause)
            return;
    }
}
