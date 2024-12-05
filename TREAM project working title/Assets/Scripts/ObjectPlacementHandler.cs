using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPlacementHandler : MonoBehaviour
{
    public ClockPartData clockPartData;
    public Material glowMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    private Rigidbody rb;

    private bool isGlowing = false;

    private float moePosition = 1f;
    private float moeRotation = 5f;
    private float moeScale = 0.5f;

    [SerializeField] AudioSource correctPosition;
    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }

        CheckTransform();
        rb = GetComponent<Rigidbody>();

        PopulateValidTransforms();
    }

    private void PopulateValidTransforms()
    {
        clockPartData.validPositions.Clear();

        GameObject ex = GameObject.FindWithTag(clockPartData.partType);
        clockPartData.validScale = ex.transform.localScale;

        GameObject[] objects = GameObject.FindGameObjectsWithTag(clockPartData.partType);
        // add transform values to data
        foreach (GameObject obj in objects)
        {
            clockPartData.validPositions.Add(obj.transform.position);
            clockPartData.validRotations.Add(obj.transform.rotation);
        }

        Debug.Log($"Populated {clockPartData.validPositions.Count} valid positions for {gameObject.name}.");
    }

    // still kind of bugged. need to find a way for objects to not be able to occupy the same space
    public void CheckTransform()
    {
        for (int i = 0; i < clockPartData.validPositions.Count; i++)
        {
            //first check if position is valid
            if (IsNearValidPosition(transform.position))
            {
                // then check rotation and scale only if its valid
                if (IsNearValidRotation(transform.rotation, i) && IsNearValidScale(transform.localScale))
                {
                    if (!isGlowing)
                    {
                        correctPosition.Play();
                        ApplyGlow();
                        clockPartData.active = true;
                    }
                    return;
                }
            }
        }
        
        if (isGlowing)
        {
            RemoveGlow();
            clockPartData.active = false;
        }
    }

        private bool IsNearValidPosition(Vector3 position)
    {

        foreach (Vector3 validPosition in clockPartData.validPositions)
        {
            if (Vector3.Distance(position, validPosition) <= moePosition)
            {
                //Debug.Log($"Correct position reached for {gameObject.name}");
                return true;
            }
        }

        return false;
    }

    private bool IsNearValidScale(Vector3 scale)
    {
        if (Vector3.Distance(scale, clockPartData.validScale) <= moeScale)
        {
            Debug.Log($"Correct scale reached for {gameObject.name}");
            return true;
        }

        return false;
    }


    private bool IsNearValidRotation(Quaternion rotation, int index)
    {
        // Check if the rotation at the current index matches the valid rotation
        if (Quaternion.Angle(rotation, clockPartData.validRotations[index]) <= moeRotation)
        {
            Debug.Log($"Correct rotation reached for {gameObject.name}");
            return true;
        }

        return false;
    }

    // utilities copied from interaction handler. might be good to extract
    private void ApplyGlow()
    {
        if (objectRenderer != null && glowMaterial != null)
        {
            objectRenderer.material = glowMaterial;
        }
    }

    private void RemoveGlow()
    {
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }

    }
}
