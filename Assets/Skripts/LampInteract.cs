using UnityEngine;

public class LampInteract : MonoBehaviour, IInteractable
{
    private SpriteRenderer sr;

    [Header("Lamp colors")]
    public Color offColor = new Color(0.3f, 0.3f, 0.3f);
    private Color original;
    private bool isOff;

    private bool playerInRange;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        original = sr.color;
    }

    public void Interact()
    {
        if (!playerInRange) return;

        isOff = !isOff;
        sr.color = isOff ? offColor : original;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;
        UIManager.Instance.ShowInteraction("Press E to turn of the lamp / turn on the lamp");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;
        UIManager.Instance.HideInteraction();
    }
}

