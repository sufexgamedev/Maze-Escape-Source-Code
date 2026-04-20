using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private MazeGame inputActions;
    public InputAction playerInput;
    private Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 movement;

    private void Awake()
    {
        inputActions = new MazeGame();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput = inputActions.Player.Move;
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        movement = playerInput.ReadValue<Vector2>();

        if(movement != Vector2.zero)
        {
            transform.right = movement; // simple way for rotation
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}
