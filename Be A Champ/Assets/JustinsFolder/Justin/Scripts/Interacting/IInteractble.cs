using UnityEngine;

public interface IInteractble
{
    void Interact(Transform interactorTransform);
    string GetInteractText();
    Transform GetTransform();
}
