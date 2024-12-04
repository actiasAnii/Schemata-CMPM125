using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueWinCondition : MonoBehaviour
{
    private Queue<GameObject> ToBeExplored = new Queue<GameObject>();
    private List<GameObject> Explored = new List<GameObject>();
    [SerializeField] private GameObject StartingPoint;
    [SerializeField] private GameObject EndingPoint;

    // Start is called before the first frame update
    public bool CheckIfBridged()
    {
        GameObject Iter = StartingPoint;
        List<GameObject> connections = Iter.GetComponent<ObjectInteractList>().getObjectList();
        foreach (GameObject connection in connections)
        {
            if (!Explored.Contains(connection))
            {
                Explored.Add(connection);
                ToBeExplored.Enqueue(connection);
            }
        }
        Iter = ToBeExplored.Dequeue();
        while(Iter != EndingPoint){
            connections = Iter.GetComponent<ObjectInteractList>().getObjectList();
            foreach (GameObject connection in connections)
            {
                if (!Explored.Contains(connection))
                {
                    Explored.Add(connection);
                    ToBeExplored.Enqueue(connection);
                }
            }
            if (ToBeExplored.Count == 0)
            {
                return false;
            }
            else { Iter = ToBeExplored.Dequeue(); }
        }
        return true;
    }
}
