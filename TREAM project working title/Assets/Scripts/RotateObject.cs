using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    // rotate object with slider
    [SerializeField] public Slider _sliderX, _sliderY, _sliderZ;
    [SerializeField] private float rotateX, rotateY, rotateZ;
    private Quaternion startRotation;
    public float prevScaleX, prevScaleY, prevScaleZ;
    private void Start()
    {
        prevScaleX = this.transform.localRotation.x;
        prevScaleY = this.transform.localRotation.y;
        prevScaleZ = this.transform.localRotation.z;
        startRotation = this.transform.rotation;

        _sliderX.onValueChanged.AddListener((v) => {
            if(ManageSlider.SelectedObject == this.gameObject){
                rotateX = v - prevScaleX;
                prevScaleX = v;
                transform.localRotation *= Quaternion.Euler(new Vector3(rotateX, 0, 0));
            }
        });

        _sliderY.onValueChanged.AddListener((v) => {
            if(ManageSlider.SelectedObject == this.gameObject){
                rotateY = v - prevScaleY;
                prevScaleY = v;
                transform.localRotation *= Quaternion.Euler(new Vector3(0, rotateY, 0));
            }
        });

        _sliderZ.onValueChanged.AddListener((v) => {
            if(ManageSlider.SelectedObject == this.gameObject){
                rotateZ = v - prevScaleZ;
                prevScaleZ = v;
                transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, rotateZ));
            }
        });
    }

    public void ResetRotation()
    {
        this.transform.localRotation = startRotation;
        prevScaleX = this.transform.localRotation.x;
        prevScaleY = this.transform.localRotation.y;
        prevScaleZ = this.transform.localRotation.z;
    }

}
