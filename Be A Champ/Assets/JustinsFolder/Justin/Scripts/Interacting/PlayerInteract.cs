using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractble interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager dialogueManager = FindAnyObjectByType<DialogueManager>();
            dialogueManager.DisplayNextSentence();
        }
    }

    public IInteractble GetInteractableObject()
    {
        List<IInteractble> interactableList = new List<IInteractble>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractble interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractble closestInteractable = null;
        foreach(IInteractble interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}
