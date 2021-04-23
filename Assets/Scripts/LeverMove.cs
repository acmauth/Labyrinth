using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMove : Lever<Vector2> //A lever works like a toggle button. If pulled, it does something, if pulled back, it reverts.
{

      void Start()
      {
          //Setting the direction the object will move at
          for (int i = 0; i < targets.Length; i++)
          {
              OriginalPositions[i] = targets[i].GetComponent<Transform>().transform.position; //The original position of the platform, the position it was placed in the world

                  switch (Directions[i])
                  {
                      case Direction.UP:
                          TargetPositions[i] = new Vector2(targets[i].transform.position.x, targets[i].transform.position.y + MoveDistance);
                          break;
                      case Direction.DOWN:
                          TargetPositions[i] = new Vector2(targets[i].transform.position.x, targets[i].transform.position.y - MoveDistance);
                          break;
                      case Direction.LEFT:
                          TargetPositions[i] = new Vector2(targets[i].transform.position.x - MoveDistance, targets[i].transform.position.y);
                          break;
                      case Direction.RIGHT:
                          TargetPositions[i] = new Vector2(targets[i].transform.position.x + MoveDistance, targets[i].transform.position.y);
                          break;
                      default:
                          TargetPositions[i] = new Vector2(targets[i].transform.position.x + MoveDistance, targets[i].transform.position.y);
                          break;
                  }

          }
          //CanPullHandle = true;
      }

     /* // Update is called once per frame
      void Update()
      {
          /*if(InArea)
          {
              if(Input.GetKeyUp(KeyCode.E))
              {
                  LeverPulled = !LeverPulled;
              }
          }

          if (LeverPulled)
          {
              if(CanPullHandle)
              {
                  LeverHandle.Rotate(Vector3.forward, RotateRange); //we want this to happen only once
                  CanPullHandle = false;
              }

              int i = 0;
              foreach(GameObject target in targets)
              {
                  float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
                  target.transform.position = Vector3.MoveTowards(target.transform.position, TargetPositions[i], step);
                  i++;
              }


          }
          else if (!LeverPulled) //We don't want this portion to run every frame the lever is not pulled. We don't care about it if the Player is not in the lever area
          {
                  if (!CanPullHandle)
                  {
                      LeverHandle.Rotate(Vector3.forward, -RotateRange);
                      CanPullHandle = true;
                  }

                  int i = 0;
                  foreach (GameObject target in targets)
                  {
                      float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
                      target.transform.position = Vector3.MoveTowards(target.transform.position, OriginalPositions[i], step);
                      i++;
                  }

          }
          */

    /*  int i = 0;
      foreach (GameObject target in targets)
      {
          float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
          if(LeverPulled)
              target.transform.position = Vector3.MoveTowards(target.transform.position, TargetPositions[i], step);
          else
              target.transform.position = Vector3.MoveTowards(target.transform.position, OriginalPositions[i], step);
          i++;
      }
    */

    /* if (LeverPulled)
     {
         int i = 0;
         foreach (GameObject target in targets)
         {
             float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
             target.transform.position = Vector3.MoveTowards(target.transform.position, TargetPositions[i], step);
             i++;
         }
     }
     else
     {
         int i = 0;
         foreach (GameObject target in targets)
         {
             float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
             target.transform.position = Vector3.MoveTowards(target.transform.position, OriginalPositions[i], step);
             i++;
         }
     }

 }
*/
    public override void Action()
    {
         int i = 0;

         float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
         foreach (GameObject target in targets)
         {
             if(LeverPulled)
                target.transform.position = Vector3.MoveTowards(target.transform.position, TargetPositions[i], step);  
             else
                target.transform.position = Vector3.MoveTowards(target.transform.position, OriginalPositions[i], step);
            i++;
         }
    }
}
