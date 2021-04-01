using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xAxis;

    [Range(1.0f, 50.0f)]
    private float movementSpeed = 10.0f;

    [Range(10.0f, 100.0f)]
    public float jumpPower = 10.0f;


    // acceleration related stuff 
    [Range(10.0f, 3.0f)]
    public float accelTime = 0.6f;
    [Range(10.0f, 3.0f)]
    public float decelTime = 0.2f;

    private float timeAccelerating;
    private float timeDecelarating;
    private float lastAcceleration;
    private float acceleration;
    private float direction;
    // end of accel related stuff

    private bool isGrounded;
    private bool jumpPressed;
    private BoxCollider2D box;
    private Rigidbody2D rb;
    public Transform GroundCheck;
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
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
    }
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
    void ParseInput()
    {

        xAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

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
        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
