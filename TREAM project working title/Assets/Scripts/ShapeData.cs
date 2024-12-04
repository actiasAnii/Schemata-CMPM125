using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ShapeData", menuName = "Shapes/ShapeData")]
public class ShapeData : ScriptableObject
{
    public string shapeType;
    public bool active;

    // if theres going to be a given goal rotation/scale, maybe add here
    // but for right now im mostly using rotating/scaling as a way to navigate piece around eachother


    public List<string> canTouch;
    public List<string> cannotTouch;
}
