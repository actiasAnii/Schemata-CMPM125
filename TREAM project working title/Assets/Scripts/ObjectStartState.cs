using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStartState : MonoBehaviour
{
    [SerializeField] public GameObject object1, object2;
    [SerializeField] public Transform object1Start, object2Start;
    [SerializeField] public GameObject slider1, slider2;


    public void ResetObjects()
    {
        //reset object position
        object1.transform.position = object1Start.position;
        object1.transform.rotation = object1Start.rotation;
        object1.transform.localScale = object1Start.localScale;
        object2.transform.position = object2Start.position;
        object2.transform.rotation = object2Start.rotation;
        object2.transform.localScale = object2Start.localScale;

        //reset slider values
        foreach(Slider child in slider1.GetComponentsInChildren<Slider>())
        {
            child.value = 1;
        }
    }
}
