using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlAudio : MonoBehaviour
{
    private float movementX;
    private float movementY;
    private Rigidbody rb;

    // Set a default speed here, but make sure to check its value in the Unity Inspector!
    public float speed = 15f;

    [SerializeField] AudioSource SFXSource;
    public AudioClip crash;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (SFXSource == null)
        {
            SFXSource = GetComponent<AudioSource>();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movementVector3 = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movementVector3 * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SFXSource.PlayOneShot(crash, 1.0f);
        }
    }
}
