using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractList : MonoBehaviour
{
    // I had the idea but it turns out someone just randomly pasted all the code needed at https://discussions.unity.com/t/how-do-i-get-list-of-all-objects-touching-during-a-collision/130940
    // needless to say its kinda hard not to take it considering how simple it is
    private List<GameObject> AllInteractables = new List<GameObject>();
    private void OnCollisionEnter(Collision collision)
    {
        AllInteractables.Add(collision.gameObject);
    }

    // Update is called once per frame
    private void OnCollisionExit(Collision collision)
    {
        AllInteractables.Remove(collision.gameObject);
    }

    public List<GameObject> getObjectList()
    {
        return AllInteractables;
    }
}
