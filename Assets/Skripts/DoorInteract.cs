using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;

        if (GameManager.Instance.hasKey)
            UIManager.Instance.ShowInteraction("Press E to open the door");
        else
            UIManager.Instance.ShowInteraction("Door is locked. Find a key");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;
        UIManager.Instance.HideInteraction();
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
        if (!GameManager.Instance.hasKey)
        {
            UIManager.Instance.ShowInteraction("Door is locked. Find a key");
            Debug.Log("Door locked. Find a key");
            return;
        }

        UIManager.Instance.HideInteraction();

        Debug.Log("Door opened – going to next loop!");

        if (GameManager.Instance.currentLoop < 4)  // 0,1,2,3 → max 4 eri huonetta
        {
            GameManager.Instance.currentLoop++;
            UnityEngine.SceneManagement.SceneManager.LoadScene("RoomScene");
        }
        else
        {
            Debug.Log("FINAL LOOP REACHED — No more changes!");
        }
    }
}
