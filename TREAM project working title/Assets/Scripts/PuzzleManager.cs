using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> puzzleObjects;

    public string puzzleObjectTag = "PuzzleObject";

    void Start()
    {
        //populate the list with objects tagged puzzleObjects
        PopulatePuzzleObjects();
        Debug.Log($"{puzzleObjects.Count} puzzle objects found.");

    }

    // method to check if the puzzle is complete
    public void CheckPuzzleCompletion()
    {
        bool isComplete = true;

        foreach (GameObject obj in puzzleObjects)
        {
            ObjectInteractionHandler handler = obj.GetComponent<ObjectInteractionHandler>();

            if (handler == null)
            {
                Debug.LogWarning($"Object {obj.name} does not have ObjectInteractionHandler attached.");
                isComplete = false;
                break;
            }

            ShapeData shapeData = handler.shapeData;

            // if shapeData is null or the object is not active, the puzzle is incomplete
            if (shapeData == null || !shapeData.active)
            {
                isComplete = false;
                break;
            }
        }

        if (isComplete)
        {
            Debug.Log("Puzzle Complete!");

            // add additional actions
        }
        else
        {
            // Debug.Log("Puzzle not yet Complete");
        }
    }

    private void PopulatePuzzleObjects()
    {
        GameObject[] puzzleObjectsArray = GameObject.FindGameObjectsWithTag(puzzleObjectTag);

        // clear the list before adding new elements
        puzzleObjects.Clear();

        foreach (GameObject obj in puzzleObjectsArray)
        {
            puzzleObjects.Add(obj);
        }
    }
}