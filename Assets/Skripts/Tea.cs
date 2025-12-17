using UnityEngine;

public class TeaInteract : MonoBehaviour, IInteractable
{
    private bool playerInRange = false;
    private bool usedThisVisit = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;
        usedThisVisit = false;

        UIManager.Instance.ShowInteraction("Press E to drink the tea");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;
        usedThisVisit = false;

        UIManager.Instance.HideInteraction();
    }

    public void Interact()
    {
        if (!playerInRange) return;
        if (usedThisVisit) return;

        usedThisVisit = true;

        UIManager.Instance.HideInteraction();
        UIManager.Instance.ShowInteraction("You drink the tea. It tastes familiar.");

        gameObject.SetActive(false);

        // HALUTESSA:
        // GameManager.Instance.AdvanceLoop();
    }
}

