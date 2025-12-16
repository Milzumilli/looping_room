using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable currentInteractable;
    private Collider2D currentTrigger;

    void Update()
    {
        if (currentTrigger != null)

            currentInteractable = currentTrigger.GetComponent<IInteractable>();

        else currentInteractable = null;
        
        if    (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();

            {
                // Piilota "Press E" UI-teksti interaktion jälkeen
                currentInteractable = null;
               
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            // Tänne voit lisätä UI-tekstin: "Press E"
            currentTrigger = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            // Piilota "Press E" UI-teksti
            currentTrigger = null;
        }
    }
}

// Yksinkertainen interface interaktoitaville esineille
public interface IInteractable
{
    void Interact();
}


