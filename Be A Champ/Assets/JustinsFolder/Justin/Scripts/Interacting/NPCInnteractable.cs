using UnityEngine;

public class NPCInnteractable : MonoBehaviour, IInteractble
{
    [SerializeField] private string interactText;

    public void Interact(Transform interactorTransform)
    {
        DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
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
