using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// referencing this tutorial: https://vionixstudio.com/2022/09/19/unity-character-controller/

public class characterMove : MonoBehaviour
{
    // reference to character controller component
    CharacterController selfCtrl;
    // vector3 containing force/direction of movement
    Vector3 moveSpeed;
    // float representing gravity (downward force opposing upward movement)
    // 9.8 happens to be force of gravity on earth, modify for feel
    float gravity = 5f;
    // this is so you can only ""jump"" once
    bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        selfCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime is apparently the time between this frame and last
        moveSpeed = new Vector3(Input.GetAxis("Horizontal") * 0.1f, 0, Input.GetAxis("Vertical") * 0.1f);
        
        if (!selfCtrl.isGrounded && jumped)
        {
            moveSpeed.x = 0;
            moveSpeed.z = 0;
            moveSpeed.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveSpeed.y = 0;
            jumped = false;
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("jump");
            Debug.Log(moveSpeed);
            if (transform.position.y < 2 && !jumped)
            {
                moveSpeed += Vector3.up * 0.1f;
            }
            else
            {
                jumped = true;
            }
        }
        selfCtrl.Move(moveSpeed); 
    }
}
