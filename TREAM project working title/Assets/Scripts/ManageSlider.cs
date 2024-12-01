using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManageSlider : MonoBehaviour
{
    [SerializeField] private GameObject slider;
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
                }
            }
        }
        else
        {
            slider.SetActive(false);
        }
    }
}
