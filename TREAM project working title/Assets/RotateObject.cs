using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private Vector3 rotation;
    //if key down rotate object
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotation = Vector3.up;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rotation = Vector3.down;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            rotation = Vector3.left;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rotation = Vector3.right;
        }
        else{
            rotation = Vector3.zero;
        }
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);

    }
}
