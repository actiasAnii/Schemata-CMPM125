using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ObjectIsActive : MonoBehaviour
{
    // keep track of which object has most recently been clicked on
    public static GameObject activeObject;
    public static GameObject previousObject;
    [SerializeField] public GameObject slider1, slider2;
    public GameObject cube1, cube2;
    [SerializeField] public GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (activeObject != null)
        {
            panel.SetActive(true);
            if(activeObject == cube1)
            {
                slider1.SetActive(true);
                slider2.SetActive(false);
            }
            else if(activeObject == cube2)
            {
                slider1.SetActive(false);
                slider2.SetActive(true);
            }
        }
    }
}
