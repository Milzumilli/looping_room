using UnityEngine;

public class LampInteract : MonoBehaviour
{
    SpriteRenderer sr;
    public Color offColor = new Color(0.3f, 0.3f, 0.3f);
    Color original;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        original = sr.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sr.color == original) sr.color = offColor;
            else sr.color = original;
        }
    }
}
