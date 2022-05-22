using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancellableSignal
{
    public delegate bool BooleanFunction();
    BooleanFunction func;
    
    bool forceCancel = false;
    
    public CancellableSignal(BooleanFunction func = null)
    {
        this.func = func;
    }
    
    public static bool IsCanceled(CancellableSignal signal)
    {
        if (null == signal)
            return false;

        bool ret = false;
        if (signal.forceCancel)
            ret = true;
        else if (null != signal.func)
            ret = signal.func();
        
        return ret;
    }
    
    public static void Cancel(CancellableSignal signal)
    {
        if (null == signal)
            return;

        signal.forceCancel = true;
    }
}
