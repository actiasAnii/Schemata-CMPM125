using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManageSlider : MonoBehaviour
{
    [SerializeField] private GameObject slider, panel;
    [SerializeField] private Slider rotateX, rotateY, rotateZ;
    [SerializeField] private Slider scaleX, scaleY, scaleZ;
    public static GameObject activeObject;
    public static GameObject SelectedObject;
    void Start()
    {
        slider.SetActive(false);
    }

    void Update()
    {
        if (SelectedObject != null)
        {
            if(SelectedObject != activeObject){
                if(!panel.activeSelf){
                    panel.SetActive(true);
                }
                Debug.Log(SelectedObject.name);
                activeObject = SelectedObject;
                slider.SetActive(true);
                RotateObject rotateObjectInstance = SelectedObject.GetComponent<RotateObject>();
                if (rotateObjectInstance != null)
                {
                    rotateX.value = rotateObjectInstance.prevScaleX;
                    rotateY.value = rotateObjectInstance.prevScaleY;
                    rotateZ.value = rotateObjectInstance.prevScaleZ;

                }
                ScaleObject scaleObjectInstance = SelectedObject.GetComponent<ScaleObject>();
                if (scaleObjectInstance != null)
                {
                    scaleX.value = scaleObjectInstance.prevScaleX;
                    scaleY.value = scaleObjectInstance.prevScaleY;
                    scaleZ.value = scaleObjectInstance.prevScaleZ;
                    //set max value to double original scale
                    scaleX.maxValue = scaleObjectInstance.startScale.x * 2;
                    scaleY.maxValue = scaleObjectInstance.startScale.y * 2;
                    scaleZ.maxValue = scaleObjectInstance.startScale.z * 2;
                }
            }
        }
        else
        {
            slider.SetActive(false);
        }
    }
}
