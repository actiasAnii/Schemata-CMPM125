using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 GetMouseWorldPos(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown(){
        mousePosition = Input.mousePosition - GetMouseWorldPos();
    }
    private void OnMouseDrag(){
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }


    /*private bool dragging = false;
    private Vector3 offset;
    void Update(){
        if(dragging){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            Debug.Log("Dragging");
        }
    }

    private void OnMouseDown(){
        //move object based on mouse position
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
        ManageSlider.SelectedObject = gameObject;
    }

    private void OnMouseUp(){
        dragging = false;
    }*/
}
