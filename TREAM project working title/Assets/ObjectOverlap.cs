using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectOverlap : MonoBehaviour
{
    [SerializeField] private Transform objectTransform;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object is within the collider bounds");
        //if other is within a range of the object
        if (UnityEngine.Vector3.Distance(objectTransform.position, other.transform.position) < 1)
        {
            Debug.Log("Object is within the range of the object");
        }
        
        //check if object is overlapping
        if (objectTransform.position == other.transform.position)
        {
            //check if rotation is the same
            if (objectTransform.rotation == other.transform.rotation)
            {
                Debug.Log("Object is overlapping");
            }
        }
    }
}
