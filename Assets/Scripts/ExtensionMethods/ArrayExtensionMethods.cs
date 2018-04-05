using System;
using UnityEngine;

public static class ArrayExtensionMethods
{
    public static void InvokeWithHandlerGameObject(this Delegate[] delegates, GameObject gameObject)
    {
        foreach (var del in delegates)
        {
            //del.(gameObject);
        }
    }
}
