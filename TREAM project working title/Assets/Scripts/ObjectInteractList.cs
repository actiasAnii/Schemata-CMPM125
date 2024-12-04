using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractList : MonoBehaviour
{
    // I had the idea but it turns out someone just randomly pasted all the code needed at https://discussions.unity.com/t/how-do-i-get-list-of-all-objects-touching-during-a-collision/130940
    // needless to say its kinda hard not to take it considering how simple it is
    private List<GameObject> AllInteractables = new List<GameObject>();
    public GameObject door;

    // if object collides with another object, add it to the list
    void OnTriggerEnter(Collider other)
    {
        AllInteractables.Add(other.gameObject);
        // Enable emission on material if touching
        other.gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        other.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.magenta);
        Debug.Log("Collision - Trigger");

        // if at least 8 objects are touching, make door glow. will probably have a very different condition
        if (AllInteractables.Count >= 8)
        {
            door.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            door.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.yellow);
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        AllInteractables.Remove(other.gameObject);
        other.gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
    }

    public List<GameObject> getObjectList()
    {
        return AllInteractables;
    }
}
