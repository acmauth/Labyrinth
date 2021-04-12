using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction {UP, DOWN, LEFT, RIGHT}; //Indicates the direction the object is moving. Directions are up, down, left, right.

public class ButtonBehaviour : MonoBehaviour //Links a button to one (or many) platforms/doors and while the button is pressed, these will move towards a certain direction_
{
    //Button variables
    private Transform button;
    [SerializeField]
    private float buttonPressedTime = 0.2f;
    [SerializeField]
    private float pressRange = 0.05f;
    private bool buttonPressed;
    
    //Variables about the platform movement
    public GameObject target; //The target platform or door. May have multiple targets, may implement that later on
    [SerializeField]
    private float accelTime = 2.0f;
    [SerializeField]
    private float decelTime = 0.5f;
    [SerializeField]
    private Direction direction;
    [SerializeField]
    private float objectMovingSpeed = 10f;
    [SerializeField]
    private float moveDistance = 2f;
    private Vector2 originalPosition;
    private Vector2 targetPosition;
    private float distanceCovered = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        button = transform.Find("Button");
        originalPosition = target.GetComponent<Transform>().transform.position; //The original position of the platform, the position it was placed in the world
        
        switch (direction)
        {
            case Direction.UP:
                targetPosition = new Vector2(target.transform.position.x, target.transform.position.y + moveDistance);
                break;
            case Direction.DOWN:
                targetPosition = new Vector2(target.transform.position.x, target.transform.position.y - moveDistance);
                break;
            case Direction.LEFT:
                targetPosition = new Vector2(target.transform.position.x - moveDistance, target.transform.position.y);
                break;
            case Direction.RIGHT:
                targetPosition = new Vector2(target.transform.position.x + moveDistance, target.transform.position.y);
                break;
            default:
                targetPosition = new Vector2(target.transform.position.x + moveDistance, target.transform.position.y);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            target.transform.position = targetPosition;
        }
        else if (!buttonPressed && new Vector2(target.transform.position.x, target.transform.position.y) != originalPosition)
        {
       /*     switch (direction)
            {
                case Direction.UP:
                    targetPosition = new Vector2(target.transform.position.x, target.transform.position.y - moveDistance);
                    break;
                case Direction.DOWN:
                    targetPosition = new Vector2(target.transform.position.x, target.transform.position.y + moveDistance);
                    break;
                case Direction.LEFT:
                    targetPosition = new Vector2(target.transform.position.x + moveDistance, target.transform.position.y);
                    break;
                case Direction.RIGHT:
                    targetPosition = new Vector2(target.transform.position.x - moveDistance, target.transform.position.y);
                    break;
                default:
                    targetPosition = new Vector2(target.transform.position.x - moveDistance, target.transform.position.y);
                    break;
            }
       */

            target.transform.position = originalPosition;
        }
        
    }

  /*  private void Move()
    {
        // Vector2 startPosition = target.transform.position;
        // Vector2 targetPosition;
        //distanceCovered = 0.0f;

        //     targetPosition = originalPosition;
        //     distanceCovered = 0.0f;

     /*   if (buttonPressed)
            target.transform.position = targetPosition;
        else
            targetPosition = originalPosition;
       
        
       // float time = 0.0f;
       // float distanceCovered = 0.0f;

      /*  while (time < objectMovingTime)
        {
            target.transform.position = Vector2.Lerp(startPosition, targetPosition, time / objectMovingTime);
            time += 0.2f * Time.deltaTime;
           // moveDistance += Time.deltaTime;
        }
      
        
    }
  */

    private void OnCollisionEnter2D(Collision2D collision) //If the player steps on the button
    {
        if(collision.transform.tag == "Player")
        {
          
            Vector2 startPosition = button.transform.position;
            Vector2 targetPosition = new Vector2(button.transform.position.x, button.transform.position.y - pressRange);

            button.transform.position = targetPosition; //The button is pressed
            buttonPressed = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector2 startPosition = button.transform.position;
            Vector2 targetPosition = new Vector2(button.transform.position.x, button.transform.position.y + pressRange);

            button.transform.position = targetPosition; //Button released 
            buttonPressed = false;

        }
    }
}
