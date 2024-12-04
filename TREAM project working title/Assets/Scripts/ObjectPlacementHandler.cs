using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementHandler : MonoBehaviour
{
    public ShapeData shapeData;
    public Material glowMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    private Rigidbody rb;
}
