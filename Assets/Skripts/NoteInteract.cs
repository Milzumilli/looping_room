using UnityEngine;

public class NoteInteract : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UIManager.Instance.ShowInteraction("Press E to read the note");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            UIManager.Instance.HideInteraction();

            UIManager.Instance.HideNote();
        }
    }

    private void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.hasReadNote = true;

            UIManager.Instance.HideInteraction();

            UIManager.Instance.ShowNote("You found the note! the next loop will be different. Dont trust what you see");
            Debug.Log("You found the note!");
        }
    }
}
