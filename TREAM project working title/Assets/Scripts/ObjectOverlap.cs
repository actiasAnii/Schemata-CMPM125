using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectOverlap : MonoBehaviour
{
    [SerializeField] public Transform object1, object2;
    [SerializeField] public Material originalMaterial;
    [SerializeField] public Material objectGlow;
    [SerializeField] public Transform Goal;
    [SerializeField] public GameObject goalmarker1, goalmarker2;
    [SerializeField] public float goal1xlow, goal1xhigh;
    [SerializeField] public float goal1ylow, goal1yhigh;
    [SerializeField] public float goal2xlow, goal2xhigh;
    [SerializeField] public float goal2ylow, goal2yhigh;
    [SerializeField] public float goal1scalexlow, goal1scalexhigh;
    [SerializeField] public float goal2scalexlow, goal2scalexhigh;
    private void Update()
    {
        // check position of either object
        //if object is within position range of x (-0.5, -1.5) and y(-2.5, -3.1) then make object glow
        if (object1.position.x < goal1xhigh && object1.position.x > goal1xlow && object1.position.y < goal1yhigh && object1.position.y > goal1ylow)
        {
            Debug.Log("Object 1 is in position");
            //check x scale of object is within range of 1.4 and 1.6
            if (object1.localScale.x < goal1scalexhigh && object1.localScale.x > goal1scalexlow)
            {
                Debug.Log("Object 1 is in scale");
                //change object material
                object1.GetComponent<MeshRenderer>().material = objectGlow;
                goalmarker1.gameObject.SetActive(true);

            }
            else
            {
                object1.GetComponent<MeshRenderer>().material = originalMaterial;
                goalmarker1.gameObject.SetActive(false);
            }
        }
        else
        {
            object1.GetComponent<MeshRenderer>().material = originalMaterial;
            goalmarker1.gameObject.SetActive(false);
        }

        if (object2.position.x < goal2xhigh && object2.position.x > goal2xlow && object2.position.y < goal2yhigh && object2.position.y > goal2ylow)
        {
            if (object2.localScale.x < goal2scalexhigh && object2.localScale.x > goal2scalexlow)
            {
                object2.GetComponent<MeshRenderer>().material = objectGlow;
                goalmarker2.gameObject.SetActive(true);
            }
            else
            {
                object2.GetComponent<MeshRenderer>().material = originalMaterial;
                goalmarker2.gameObject.SetActive(false);
            }
        }
        else
        {
            object2.GetComponent<MeshRenderer>().material = originalMaterial;
            goalmarker2.gameObject.SetActive(false);
        }
        
    }
}
