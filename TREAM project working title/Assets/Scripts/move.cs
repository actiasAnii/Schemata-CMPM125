using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Camera movement code from youtube tutorial -- https://www.youtube.com/watch?v=zVX9-c_aZVg&t=123s
    [SerializeField] private float mouseSensitivity = 1f;
    private float rotationY, rotationX;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget = 2f;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;
    [SerializeField] private float smoothTime = 1f;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = currentRotation;
        transform.position = target.position - transform.forward * distanceFromTarget;

        // move camera with arrow keys
        if (Input.GetKey(KeyCode.W))
        {
            target.transform.position += target.transform.forward * 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            target.transform.position -= target.transform.forward * 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target.transform.position -= target.transform.right * 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            target.transform.position += target.transform.right * 0.1f;
        }
    }


    /*
    commented out while testing other camera logic

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
    }*/
}
