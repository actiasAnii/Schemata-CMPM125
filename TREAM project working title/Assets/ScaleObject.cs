using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 1f;
    [SerializeField] private Vector3 scale;
    //if key down scale object
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scale = Vector3.up;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            scale = Vector3.down;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            scale = Vector3.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            scale = Vector3.right;
        }
        else{
            scale = Vector3.zero;
        }
        transform.localScale += scale * scaleSpeed * Time.deltaTime;

    }
}
