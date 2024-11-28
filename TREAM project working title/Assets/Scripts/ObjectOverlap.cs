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
    private void Update()
    {
        // check position of either object
        //if object is within position range of x (-0.5, -1.5) and y(-2.5, -3.1) then make object glow
        if (object1.position.x < -0.5 && object1.position.x > -1.5 && object1.position.y < -2.5 && object1.position.y > -3.1)
        {
            Debug.Log("Object 1 is in position");
            //check x scale of object is within range of 1.4 and 1.6
            if (object1.localScale.x < 1.6 && object1.localScale.x > 1.4)
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

        if (object2.position.x < -0.5 && object2.position.x > -1.5 && object2.position.y < -2.5 && object2.position.y > -3.1)
        {
            if (object2.localScale.x < 1.6 && object2.localScale.x > 1.4)
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
