using UnityEngine;

public class KeyInteract : MonoBehaviour, IInteractable
{
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UIManager.Instance.ShowInteraction("Press E to pick up key");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            UIManager.Instance.HideInteraction();
        }
    }

    private void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        GameManager.Instance.hasKey = true;
        UIManager.Instance.HideInteraction();

        Debug.Log("You picked up a key!");
        gameObject.SetActive(false);   // avain katoaa
    }
}
