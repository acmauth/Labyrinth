using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xAxis;

    //the speed the player has when he is standing.
    [SerializeField]
    [Range(1.0f, 100.0f)]
    private float movementSpeed;

    //the speed that the player has when he is crouched.
    [SerializeField]
    [Range(1.0f, 100.0f)]
    private float crouchingSpeed;

    //the speed of the player at any time.
    private float speed;

    [Range(10.0f, 100.0f)]
    public float jumpPower = 10.0f;


    //The time it takes for the player to accelerate and reach top speed.
    [SerializeField]
    [Range(10.0f, 3.0f)]
    private float accelTime = 0.6f;

    //The time it takes for the player to decelerate and stop.
    [SerializeField]
    [Range(10.0f, 3.0f)]
    private float decelTime = 0.2f;

    private float timeAccelerating;
    private float timeDecelarating;

    private float lastAcceleration;
    private float acceleration;

    //The direction that the player is looking at.
    private float direction;

    //A check to see if the player is on the ground.
    private bool isGrounded;
    //A check to see if the player is crouching.
    private bool isCrouching;

    //A check to see if the player is sliding.
    private bool isSliding;

    //A check to see if the player can stand.
    private bool canStand;

    private bool jumpPressed;
    private bool crouchPressed;
    private bool slidePressed;

    //The Starting position of the player.
    [SerializeField]
    private Vector3 startingPosition;

    private bool _debugResetPosition = false;

    private BoxCollider2D boxColliderOfPlayer;
    private Rigidbody2D rigidBodyOfPlayer;

    //An empty object that helps with the ground check.
    public Transform groundCheck;
    //A LayerMask of the layers that count as ground.
    public LayerMask groundLayer;

    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        speed = movementSpeed;
        this.transform.position = startingPosition;
        boxColliderOfPlayer = gameObject.GetComponent<BoxCollider2D>();
        rigidBodyOfPlayer = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ParseInput();
        UpdateAcceleration();
        DetectGrounded();
        Move();
        Jump();
        Crouch();

        ResetPosition();
    }

    //Parsing the input from the player.
    void ParseInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        crouchPressed = Input.GetKey(KeyCode.LeftShift);
        slidePressed = Input.GetKeyDown(KeyCode.S);

        _debugResetPosition = Input.GetKeyDown(KeyCode.Tab);
    }

    //Accelerating and decelerating the speed of the player.
    void UpdateAcceleration()
    {
        if (xAxis != 0.0f)
        {
            timeDecelarating = 0.0f;
            timeAccelerating += Time.deltaTime;

            direction = xAxis;

            acceleration = xAxis * (timeAccelerating / accelTime);
            acceleration = Mathf.Clamp(acceleration, -1.0f, 1.0f);
            lastAcceleration = acceleration;
        }
        else
        {
            timeAccelerating = 0.0f;
            timeDecelarating += Time.deltaTime;

            acceleration = Mathf.Abs(lastAcceleration) - timeDecelarating / decelTime;
            acceleration = Mathf.Clamp(acceleration, 0.0f, 1.0f);
            acceleration *= direction;
        }

    }

    // Moving the player.
    //Also, fliping the sprite according to the direction the player is moving.
    void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * speed * acceleration;

        if (xAxis > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if (xAxis < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    //Detecting if the player is on the ground.
    //Using the GroundCheck empty object, and checking if anything that overlaps a small circle around it belongs to the groundLayer LayerMask.
    void DetectGrounded()
    {
        isGrounded = false;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
    }

    //Making the player jump.
    void Jump()
    {
        if (jumpPressed && isGrounded && !isCrouching)
        {
            rigidBodyOfPlayer.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

    }

    //Making the player crouch.
    void Crouch()
    {
        if (crouchPressed && isGrounded)
        {
            if (xAxis!= 0 && Mathf.Abs(acceleration) > 0.5f&& !isSliding && !isCrouching)
            {
                isSliding = true;
                rigidBodyOfPlayer.AddForce(new Vector2(xAxis, 0) * 10.0f, ForceMode2D.Impulse);
            }
            if(Mathf.Abs(acceleration) == 1.0f)
            {
                isSliding = false;
            }
            boxColliderOfPlayer.size = new Vector2(boxColliderOfPlayer.size.x, 4.5f);
            boxColliderOfPlayer.offset = new Vector2(boxColliderOfPlayer.offset.x, 1.1f);
            isCrouching = true;
            speed = crouchingSpeed;
        }
        else
        {
            isSliding = false;
            isCrouching = false;
            speed = movementSpeed;
            boxColliderOfPlayer.size = new Vector2(boxColliderOfPlayer.size.x, 6.8f);
            boxColliderOfPlayer.offset = new Vector2(boxColliderOfPlayer.offset.x, 0.22f);
        }
    }

    //A Function that is temporarily used for debugging purposes, returning the player to the start position.
    void ResetPosition()
    {
        if (_debugResetPosition)
        {
            this.transform.position = startingPosition;
        }
    }

    //void Slide()
    //{
    //    if (slidePressed)
    //    {
    //        isSliding = true;
    //        box.size = new Vector2(box.size.x, 4.5f);
    //        box.offset = new Vector2(box.offset.x, 1.1f);
    //        rb.AddForce(new Vector2(xAxis, 0) * 10.0f, ForceMode2D.Impulse);

    //    }
    //    else if(!crouchPressed)
    //    {
    //        isSliding = false;
    //        box.size = new Vector2(box.size.x, 6.8f);
    //        box.offset = new Vector2(box.offset.x, 0.22f);
    //    }
    //}

}
