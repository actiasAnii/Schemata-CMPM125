using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScaleObject : MonoBehaviour
{
    // scale object with slider
    [SerializeField] public Slider _sliderX, _sliderY, _sliderZ;
    [SerializeField] private float scaleX, scaleY, scaleZ;
    public float prevScaleX, prevScaleY, prevScaleZ;
    private void Start()
    {
        prevScaleX = this.transform.localScale.x;
        prevScaleY = this.transform.localScale.y;
        prevScaleZ = this.transform.localScale.z;

        _sliderX.onValueChanged.AddListener((v) => {
            if(ManageSlider.SelectedObject == this.gameObject){
                scaleX = v - prevScaleX;
                prevScaleX = v;
                transform.localScale += new Vector3(scaleX, 0, 0);
            }
        });

        _sliderY.onValueChanged.AddListener((v) => {
            if(ManageSlider.SelectedObject == this.gameObject){
                scaleY = v - prevScaleY;
                prevScaleY = v;
                transform.localScale += new Vector3(0, scaleY, 0);
            }
        });

        _sliderZ.onValueChanged.AddListener((v) => {
            if(ManageSlider.SelectedObject == this.gameObject){
                scaleZ = v - prevScaleZ;
                prevScaleZ = v;
                transform.localScale += new Vector3(0, 0, scaleZ);
            }
        });
    }

    /*
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

    }*/
}
