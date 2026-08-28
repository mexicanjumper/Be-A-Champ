using UnityEngine;

public class NPCInnteractable : MonoBehaviour, IInteractble
{
    [SerializeField] private string interactText;

    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void Interact(Transform interactorTransform)
    {
        Debug.Log("Interact!");
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
