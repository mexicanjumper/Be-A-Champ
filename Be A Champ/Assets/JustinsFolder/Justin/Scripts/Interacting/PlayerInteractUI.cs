using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractble interactible)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactible.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
