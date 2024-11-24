using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    // rotate object with slider
    [SerializeField] public Slider _sliderX, _sliderY, _sliderZ;
    [SerializeField] private float rotateX, rotateY, rotateZ;
    private float prevScaleX, prevScaleY, prevScaleZ;
    private void Start()
    {
        prevScaleX = 1;
        prevScaleY = 1;
        prevScaleZ = 1;

        _sliderX.onValueChanged.AddListener((v) => {
            rotateX = v - prevScaleX;
            prevScaleX = v;
            
            //add to rotation x value
            transform.localRotation *= Quaternion.Euler(new Vector3(rotateX, 0, 0));

        });

        _sliderY.onValueChanged.AddListener((v) => {
            rotateY = v - prevScaleY;
            prevScaleY = v;
            transform.localRotation *= Quaternion.Euler(new Vector3(0, rotateY, 0));
        });

        _sliderZ.onValueChanged.AddListener((v) => {
            rotateZ = v - prevScaleZ;
            prevScaleZ = v;
            transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, rotateZ));
        });
    }

}
