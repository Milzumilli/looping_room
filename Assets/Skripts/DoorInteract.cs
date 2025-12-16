using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
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

    

    public void Interact()
    {

        if (!GameManager.Instance.hasKey)
        {
            UIManager.Instance.ShowInteraction("Door is locked. Find a key");
            Debug.Log("Door locked. Find a key");
            return;
        }


        UIManager.Instance.HideInteraction();
        UIManager.Instance.HideNote();

        Debug.Log("Door opened – going to next loop!");

        if (GameManager.Instance.currentLoop < 4)  // 0,1,2,3,4 → max 4 eri huonetta
        {

            GameManager.Instance.currentLoop++;

            var controller =
            Object.FindFirstObjectByType<RoomStateController>();
            if (controller != null)
            {
                controller.ApplyLoop(GameManager.Instance.currentLoop);
            }

        }
        else
        {
            Debug.LogError("RoomStateController not found");
        }
    }
}
