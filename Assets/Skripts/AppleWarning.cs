using UnityEngine;

public class AppleWarning : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        UIManager.Instance.ShowInteraction("Don't eat it!");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        UIManager.Instance.HideInteraction();
    }
}

