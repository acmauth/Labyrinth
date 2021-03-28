/*
 * Author: Konstantinos Benos
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1.0f, 50.0f)]
    public float movementSpeed = 10.0f;

    [Range(10.0f, 1000.0f)]
    public float jumpPower = 5.0f;

    [Range(0.0f, 3.0f)]
    public float accelTime = 0.6f;

    [Range(0.0f, 3.0f)]
    public float decelTime = 0.3f;

    private float timeAccelerating;
    private float timeDecelerating;
    private float lastAcceleration;
    private float acceleration;
    private float direction;

    private float xAxis;
    private bool jumpPressed;

    private bool isGrounded;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        ParseInput();
        DetectGrounded();
        UpdateAcceleration();
        MovePlayer();
        Jump();
    }

    void ParseInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

    void UpdateAcceleration()
    {
        if (xAxis != 0.0f)
        {
            timeDecelerating = 0.0f;
            timeAccelerating += Time.deltaTime;

            direction = xAxis;

            acceleration = direction * (timeAccelerating / accelTime);
            acceleration = Mathf.Clamp(acceleration, -1.0f, 1.0f);
            lastAcceleration = acceleration;
        }
        else
        {
            timeAccelerating = 0.0f;
            timeDecelerating += Time.deltaTime;

            acceleration = Mathf.Abs(lastAcceleration) - timeDecelerating / decelTime;
            acceleration = Mathf.Clamp(acceleration, 0.0f, 1.0f);
            acceleration *= direction;
        }
    }

    void MovePlayer()
    {
        transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * movementSpeed * acceleration;
    }

    void DetectGrounded()
    {
        isGrounded = false;

        Vector2 boxOrigin = new Vector2(transform.position.x, transform.position.y) - Vector2.down * 0.05f;
        Vector2 boxSize = new Vector2(box.size.x * transform.localScale.x, box.size.y * transform.localScale.y);

        RaycastHit2D[] hits = Physics2D.BoxCastAll(boxOrigin, boxSize, 0.0f, Vector2.down);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider == box)
            {
                continue;
            }

            isGrounded = true;
        }
    }

    void Jump()
    {
        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}

