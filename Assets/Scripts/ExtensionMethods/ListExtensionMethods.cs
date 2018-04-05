using System.Collections.Generic;
using UnityEngine;

public static class ListExtensionMethods
{
    public static GameObject GetClosestGameObject(this List<GameObject> list, GameObject comparedObject)
    {
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = comparedObject.transform.position;
        foreach (var go in list)
        {
            float dist = (go.transform.position - currentPos).sqrMagnitude;
            if (dist < minDist)
            {
                closest = go;
                minDist = dist;
            }
        }
        return closest;
    }

    public static void RemoveGameObject(this List<GameObject> list, GameObject objectToRemove)
    {
        var count = list.Count;
        var idToRemove = objectToRemove.GetInstanceID();

        if (count == 0)
            return;

        for (int i = 0; i < count; i++)
        {
            if (list[i].GetInstanceID() == idToRemove)
            {
                list.RemoveAt(i);
                break;
            }
        }
    }
}
