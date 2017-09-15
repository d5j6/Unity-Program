using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "StarData", menuName = "Data/Star")]
public class StarData : ScriptableObject
{
    public GameObject starName;
    public List<OneOfStarData> StarsDataArray;
}

[Serializable]
public class OneOfStarData
{
    public string namePlanet;

    public Vector3 rotation;

    public float speedOfLocalRotation;

    public float speedOfGlobalRotation;

    public float starScale;
    
    public float radius;

    public string title;

    public string content;

}