using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xAxis;

    [Range(1.0f, 50.0f)]
    public float movementSpeed = 10.0f;

    [Range(10.0f, 100.0f)]
    public float jumpPower = 10.0f;


    // acceleration related stuff 
    [Range(10.0f, 3.0f)]
    public float accelTime = 0.6f;
    [Range(10.0f, 3.0f)]
    public float decelTimePublic = 0.2f;

    private float decelTimePrivate;
    private float timeAccelerating;
    private float timeDecelarating;
    private float lastAcceleration;
    private float acceleration;
    private float direction;
    // end of accel related stuff

    private bool isGrounded;
    private bool jumpPressed;

    [SerializeField]
    private bool isCrouching;
    private bool crouchPressed = false;

    [SerializeField]
    private bool isSliding;

    private BoxCollider2D box;
    private Rigidbody2D rb;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    public SpriteRenderer sprite;



    // Start is called before the first frame update
    void Start()
    {
        decelTimePrivate = decelTimePublic;
        box = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
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
    }

    // computing the acceleration
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

            acceleration = Mathf.Abs(lastAcceleration) - timeDecelarating / decelTimePrivate;
            acceleration = Mathf.Clamp(acceleration, 0.0f, 1.0f);
            acceleration *= direction;
        }

    }

    void ParseInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        crouchPressed = Input.GetKey(KeyCode.LeftShift);
    }

    // how the player moves
    void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * movementSpeed * acceleration;

        if (xAxis > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if (xAxis < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void DetectGrounded()
    {
        isGrounded = false;
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.05f, groundLayer);
    }

    void Jump()
    {
        if (jumpPressed && isGrounded && !isCrouching)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

    }

    void Crouch()
    {
        if (crouchPressed)
        {
            box.size = new Vector2(box.size.x, 4.5f);
            box.offset = new Vector2(box.offset.x, 1.1f);

            if (timeAccelerating > 1.0f)
            {
                isCrouching = false;
                isSliding = true;
                decelTimePrivate = decelTimePublic * 2;

            }
            else
            {
                isCrouching = true;
                movementSpeed = 5.0f;
            }
            
        }
        else
        {
            isCrouching = false;
            isSliding = false;
            movementSpeed = 10.0f;
            decelTimePrivate = decelTimePublic;
            box.size = new Vector2(box.size.x, 6.8f);
            box.offset = new Vector2(box.offset.x, 0.22f);
        }
    }
}
