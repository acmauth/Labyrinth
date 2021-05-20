using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonMechanism<T> : MonoBehaviour
{
    private Transform button;
    [SerializeField]
    private float buttonPressedTime = 0.2f;
    [SerializeField]
    private float pressRange = 0.05f;
    private bool buttonPressed;

    //Variables about the platform movement
    public GameObject target; //The target platform or door. May have multiple targets, may implement that later on
    [SerializeField]
    private Direction direction;
    [SerializeField]
    private float targetMovingSpeed = 10f;
    [SerializeField]
    private float moveDistance = 2f;
    private T originalPosition;
    private T targetPosition;

    public abstract void Action();

    public T OriginalPosition { get => originalPosition; set => originalPosition = value; }
    public T TargetPosition { get => targetPosition; set => targetPosition = value; }
    internal Direction Direction { get => direction; set => direction = value; }
    public float MoveDistance { get => moveDistance; set => moveDistance = value; }
    public float TargetMovingSpeed { get => targetMovingSpeed; set => targetMovingSpeed = value; }
    public bool ButtonPressed { get => buttonPressed; set => buttonPressed = value; }

    // Start is called before the first frame update
    void Awake()
    {
        button = transform.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {
        Action();

       /* if (buttonPressed)
        {
            Action(targetPosition);

           /* float step = targetMovingSpeed * Time.deltaTime; // calculate distance to move
            target.transform.position = Vector3.MoveTowards(target.transform.position, targetPosition, step);
           
        }
        else if (!buttonPressed)
        {
           /* float step = targetMovingSpeed * Time.deltaTime; // calculate distance to move
            target.transform.position = Vector3.MoveTowards(target.transform.position, originalPosition, step);
           

            Action(originalPosition);
        }
       */
    }

    private void OnCollisionEnter2D(Collision2D collision) //If the player steps on the lever
    {
        if (collision.transform.tag == "Player")
        {

            Vector2 buttonStartPosition = button.transform.position;
            Vector2 targetPosition = new Vector2(button.transform.position.x, button.transform.position.y - pressRange);

            button.transform.position = targetPosition; //The lever is pressed
            buttonPressed = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector2 buttonStartPosition = button.transform.position;
            Vector2 targetPosition = new Vector2(button.transform.position.x, button.transform.position.y + pressRange);

            button.transform.position = targetPosition; //Button released 
            buttonPressed = false;

        }
    }
}
