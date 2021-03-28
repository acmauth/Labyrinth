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
        DetectGrounded();
        Move();
      
        Jump();
    }

    void ParseInput()
    {

        xAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

    void Move()
    {
        this.transform.position += xAxis * Vector3.right * Time.deltaTime * movementSpeed;

        if (xAxis > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        else if (xAxis < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
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
