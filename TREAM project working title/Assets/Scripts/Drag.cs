using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    // get object start position
    [SerializeField] public Vector3 startPos;
    public GameObject panel;

    void Start()
    {
        startPos = this.transform.position;
    }

    public void ResetObject()
    {
        this.transform.position = startPos;
    }

    Vector3 mousePosition;
    private Vector3 GetMouseWorldPos(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown(){
        mousePosition = Input.mousePosition - GetMouseWorldPos();
        ManageSlider.SelectedObject = this.gameObject;
    }
    private void OnMouseDrag(){
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
