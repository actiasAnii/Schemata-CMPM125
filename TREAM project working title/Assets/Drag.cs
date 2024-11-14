using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    void Update(){
        if(dragging){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown(){
        //move object based on mouse position
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp(){
        dragging = false;
    }
}