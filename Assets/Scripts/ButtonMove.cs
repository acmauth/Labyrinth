using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonMove : ButtonMechanism<Vector2> //Links a lever to one (or many) platforms/doors and while the lever is pressed, these will move towards a certain direction_
{
    public override void Action()
    {
        float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
        if(ButtonPressed)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, TargetPosition, step);
        }
        else
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, OriginalPosition, step);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = target.GetComponent<Transform>().transform.position; //The original position of the platform, the position it was placed in the world
        
        switch (Direction)
        {
            case Direction.UP:
                TargetPosition = new Vector2(target.transform.position.x, target.transform.position.y + MoveDistance);
                break;
            case Direction.DOWN:
                TargetPosition = new Vector2(target.transform.position.x, target.transform.position.y - MoveDistance);
                break;
            case Direction.LEFT:
                TargetPosition = new Vector2(target.transform.position.x - MoveDistance, target.transform.position.y);
                break;
            case Direction.RIGHT:
                TargetPosition = new Vector2(target.transform.position.x + MoveDistance, target.transform.position.y);
                break;
            default:
                TargetPosition = new Vector2(target.transform.position.x + MoveDistance, target.transform.position.y);
                break;
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
      /*  if (buttonPressed)
        {
            float step =  targetMovingSpeed * Time.deltaTime; // calculate distance to move
            target.transform.position = Vector3.MoveTowards(target.transform.position, targetPosition, step);
        }
        else if (!buttonPressed && new Vector2(target.transform.position.x, target.transform.position.y) != originalPosition)
        {
            float step = targetMovingSpeed * Time.deltaTime; // calculate distance to move
            target.transform.position = Vector3.MoveTowards(target.transform.position, originalPosition, step);
        }
      
        
    }
    */



}
