using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private AudioSource footstepAudio;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        footstepAudio = GetComponent<AudioSource>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     

        // WASD / nuolinäppäimet
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        input = new Vector2(x, y).normalized;

        bool isMoving = input.magnitude > 0.1f;

        if (isMoving)
        {
            if (!footstepAudio.isPlaying)
                footstepAudio.Play();
        }
        else
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
}

