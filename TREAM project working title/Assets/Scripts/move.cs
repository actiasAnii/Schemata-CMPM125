using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] KeyCode buton = KeyCode.Mouse1;
    [SerializeField] KeyCode seconbuton = KeyCode.Mouse2;
    [SerializeField] Vector3 PointOfRotation = new Vector3(0,0,0);
    [SerializeField] float sensitivity = 1f;
    [SerializeField] float sensitivity2 = 1f;
    float prevframeX;
    float prevframeY;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buton))
        {
            this.transform.RotateAround(PointOfRotation, Vector3.up , (Input.mousePosition.x - prevframeX) * sensitivity);
            this.transform.RotateAround(PointOfRotation, Vector3.right , (Input.mousePosition.y - prevframeY) * sensitivity);
        }
        if (Input.GetKey(seconbuton))
        {
            this.transform.position += new Vector3(-1 * (Input.mousePosition.x - prevframeX) * sensitivity2,0,0);
            this.transform.position += new Vector3(0,-1 * (Input.mousePosition.y - prevframeY) * sensitivity2, 0);
        }
        prevframeX = Input.mousePosition.x;
        prevframeY = Input.mousePosition.y;
    }
}
