using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClockPartDataData", menuName = "Puzzle Objects/ClockObjectData")]
public class ClockPartData : ScriptableObject
{
    public string partType;
    public bool active;

    // vectors for appropriate size and rotation
    // honestly i know this has to be a factor for this puzzle but idk how to handle it
    public float minScale;
    public float maxScale;
    public float minRotation;
    public float maxRotation;

    public List<Transform> validPositions;

}