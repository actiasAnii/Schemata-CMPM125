using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObjectInteractionHandler : MonoBehaviour
{
    public ShapeData shapeData;
    public Material glowMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    private Rigidbody rb;
    private bool isGravityEnabled = false;
    [SerializeField] private AudioSource correctPosition, incorrectPosition;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
        else
        {
            Debug.LogWarning($"Renderer not found on {gameObject.name}");
        }

        if (rb != null)
        {
            rb.useGravity = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // check if the other object has ObjectInteractionHandler and ShapeData
        ObjectInteractionHandler otherHandler = other.GetComponent<ObjectInteractionHandler>();

        if (otherHandler != null && otherHandler.shapeData != null && shapeData != null)
        {
            string otherShapeType = otherHandler.shapeData.shapeType;

            // check if the other shape is in the canTouch list
            if (shapeData.canTouch.Contains(otherShapeType))
            {
                shapeData.active = true;
                ApplyGlow();
                FindObjectOfType<PuzzleManager>().CheckPuzzleCompletion();
            }
            else if (shapeData.cannotTouch.Contains(otherShapeType) && !isGravityEnabled)
            {
                Debug.Log($"{gameObject.name} cannot touch {other.gameObject.name}");
                incorrectPosition.Play();

                // object should fall
                StartCoroutine(FallDown());
            }
        }
    }

    // revert to original material when no longer colliding
    void OnTriggerExit(Collider other)
    {
        if (shapeData.active)
        {
            RemoveGlow();
            shapeData.active = false;
        }
    }

    // utilities 
    private void ApplyGlow()
    {
        if (objectRenderer != null && glowMaterial != null)
        {
            objectRenderer.material = glowMaterial;
            correctPosition.Play();
        }
    }

    private void RemoveGlow()
    {
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }

    // sometimes objects get floaty and wont settle. need to fix ?
    private IEnumerator FallDown()
    {
        if (rb != null)
        {
            rb.useGravity = true;

            rb.velocity = new Vector3(0, -5f, 0);

            yield return new WaitForSeconds(0.5f);

            rb.useGravity = false;

            yield return new WaitForSeconds(0.3f);


            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            isGravityEnabled = false;
        }
        else
        {
            Debug.LogWarning("Rigidbody is null, cannot apply fall down logic.");
        }
    }
}
