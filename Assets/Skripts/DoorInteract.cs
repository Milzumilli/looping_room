using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    private bool playerInRange = false;
    private bool usedThisVisit = false;
    
    private void ResetUsed()
            {
        usedThisVisit = false;
    }

    public void OnLoopChanged()
    {
        usedThisVisit = false;
        playerInRange = false ;
    }


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

    

    public void Interact()
    {
        if (!playerInRange) return;
        if (usedThisVisit) return;

        if (GameManager.Instance.currentLoop == 0
           && !GameManager.Instance.hasKey)
            if (!GameManager.Instance.hasKey)
        {
            UIManager.Instance.ShowInteraction("Door is locked. Find a key");
            return;
        }

        usedThisVisit = true;

        UIManager.Instance.HideInteraction();
        UIManager.Instance.HideNote();

        if (GameManager.Instance.currentLoop < 4)

            GameManager.Instance.currentLoop++;
        var controller = Object.FindFirstObjectByType<RoomStateController>();
        if (controller != null) 
            controller.ApplyLoop(GameManager.Instance.currentLoop);
        playerInRange = false;
        usedThisVisit = false;


    }
}
