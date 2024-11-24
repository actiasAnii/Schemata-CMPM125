using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectOverlap : MonoBehaviour
{
    [SerializeField] private Transform objectTransform;
    
    private void Update()
    {
        if(objectTransform.position.x < -2.4 && objectTransform.position.x > -2.1){
            if(objectTransform.position.y < -0.8 && objectTransform.position.y > -0.6){
                Debug.Log("within position range");
            }
        }
    }
}
