using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClockPartDataData", menuName = "Puzzle Objects/ClockObjectData")]
public class ClockPartData : ScriptableObject
{
    public string partType;
    public bool active;

    // vectors for appropriate size and rotation
    public Vector3 validScale;

    public List<Quaternion> validRotations;
    public List<Vector3> validPositions;

}