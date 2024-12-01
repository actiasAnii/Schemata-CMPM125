using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStartState : MonoBehaviour
{
    [SerializeField] public GameObject objectList;
    [SerializeField] public GameObject slider1;


    public void Reset()
    {
        //reset slider values
        foreach(Slider child in slider1.GetComponentsInChildren<Slider>())
        {
            child.value = 1;
        }
        foreach(Transform child in objectList.transform)
        {
            if(child.GetComponent<Drag>() != null)
            {
                child.GetComponent<Drag>().ResetObject();
            }
            if(child.GetComponent<RotateObject>() != null)
            {
                child.GetComponent<RotateObject>().ResetRotation();
            }
            if(child.GetComponent<ScaleObject>() != null)
            {
                child.GetComponent<ScaleObject>().ResetScale();
            }
        }
    }
}
