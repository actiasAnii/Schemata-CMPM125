using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //when r key is pressed, rotate object
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(new UnityEngine.Vector3(0, 0, 90));
        }
    }
}
