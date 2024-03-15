using UnityEngine;
using System.Collections.Generic;


public static class BaseAI
{
    public static GameObject CalculateNextMove(List<GameObject> emptyPlaces)
    {
        int index = UnityEngine.Random.Range(0, emptyPlaces.Count);
        return emptyPlaces[index];
    }
}
