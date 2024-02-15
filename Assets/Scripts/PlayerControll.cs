using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 25.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float lastMoveTime = 0.0f; // Time when the last movement occurred
    public float moveCooldown = 1.0f; // Cooldown period in seconds
    private bool canMoveLeft = true; // Flag to track if the player can move left
    private bool canMoveRight = true; // Flag to track if the player can move right

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            // Check if enough time has passed since last move
            if (Time.time - lastMoveTime >= moveCooldown)
            {
                // Feed moveDirection with input.
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                // Check if the player tries to move left
                if (horizontalInput < 0 && canMoveLeft && transform.position.x > -3f)
                {
                    // Move left
                    lastMoveTime = Time.time; // Update last move time
                    moveDirection = new Vector3(-3f, 0, verticalInput);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;
                    canMoveRight = true; // Reset the canMoveRight flag
                }
                // Check if the player tries to move right
                else if (horizontalInput > 0 && canMoveRight && transform.position.x < 3f)
                {
                    // Move right
                    lastMoveTime = Time.time; // Update last move time
                    moveDirection = new Vector3(3f, 0, verticalInput);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;
                    canMoveLeft = true; // Reset the canMoveLeft flag
                }

                // Jumping
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }
        }

        // Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        // Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
