using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int IsJumpingHash;
    int isRollingHash;

    bool wasJumping;
    bool wasRolling;

    public float moveDistance = 2.2f; // Distance to move left or right
    public float moveSpeed = 5f; // Speed of movement (units per second)

    float moveDirection = 0.05f; // -1 for left, 1 for right

    void Start()
    {
        animator = GetComponent<Animator>();
        IsJumpingHash = Animator.StringToHash("IsJumping");
        isRollingHash = Animator.StringToHash("isRolling");
    }

    void Update()
    {
        // Check for jump input (using arrow keys)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            wasJumping = true;
            animator.SetBool(IsJumpingHash, true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && wasJumping)
        {
            wasJumping = false;
            animator.SetBool(IsJumpingHash, false);
        }

        // Check for roll input (using arrow keys)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            wasRolling = true;
            animator.SetBool(isRollingHash, true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && wasRolling)
        {
            wasRolling = false;
            animator.SetBool(isRollingHash, false);
        }

        // Check for movement input (using arrow keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        moveDirection = horizontalInput;

        // Move the player
        MovePlayer();
    }

    void MovePlayer()
    {
        // Calculate movement amount based on moveDistance and moveSpeed
        float movement = moveDirection * moveDistance * moveSpeed * Time.deltaTime;

        // Calculate target position based on movement
        float targetXPosition = transform.position.x + movement;

        // Ensure the target position stays within the range
        targetXPosition = Mathf.Clamp(targetXPosition, -2.2f, 2.2f);

        // Update player's position
        transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
    }


}
