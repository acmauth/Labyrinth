using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotate : Lever<Quaternion>
{
    
    [SerializeField]
    [Range(0,360)]
    private float[] angle;

    // Start is called before the first frame update
    void Start()
    {
      /*  OriginalPositions = new Quaternion[targets.Length];
        TargetPositions = new Quaternion[targets.Length];

        LeverHandle = transform.Find("Handle");
      */

        for (int i = 0; i < targets.Length; i++)
        {
            if(angle[i] == 180)
            {
                angle[i] = (-1) * angle[i];
            }

            OriginalPositions[i] = targets[i].GetComponent<Transform>().transform.rotation; //The original position of the platform, the position it was placed in the world

            switch(Directions[i])
            {
                case Direction.LEFT:
                    TargetPositions[i] = Quaternion.Euler(0, 0, targets[i].transform.rotation.z + angle[i]);
                    break;
                case Direction.RIGHT:
                    TargetPositions[i] = Quaternion.Euler(0, 0, targets[i].transform.rotation.z - angle[i]);
                    break;
                case Direction.UP:
                    TargetPositions[i] = Quaternion.Euler(0, 0, targets[i].transform.rotation.z + angle[i]);
                    break;
                case Direction.DOWN:
                    TargetPositions[i] = Quaternion.Euler(0, 0, targets[i].transform.rotation.z - angle[i]);
                    break;
                default:
                    TargetPositions[i] = Quaternion.Euler(0, 0, targets[i].transform.rotation.z + angle[i]);
                    break;
            }
            
        }
    
      //  CanPullHandle = true;
    }

   /* // Update is called once per frame
    void Update()
    {
        if (InArea)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                LeverPulled = !LeverPulled;
            }
        }

        if (LeverPulled)
        {
            if (CanPullHandle)
            {
                LeverHandle.Rotate(Vector3.forward, RotateRange); //we want this to happen only once
                CanPullHandle = false;
            }

            int i = 0;
            foreach (GameObject target in targets)
            {
                 float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
                 target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, TargetPositions[i], step);
                 i++;

               // target.transform.Rotate(Vector3.forward, angle * targetMovingSpeed);
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
                target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, OriginalPositions[i], step);
                i++;
            }

        }
    }
    */
    /*public override void Action(GameObject targetObject, Quaternion endPos)
    {
        float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
        targetObject.transform.rotation = Quaternion.RotateTowards(targetObject.transform.rotation, endPos, step);
    }
    */

    public override void Action()
    {
        int i = 0;

        float step = TargetMovingSpeed * Time.deltaTime; // calculate distance to move
        foreach (GameObject target in targets)
        {
            if (LeverPulled)
                target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, TargetPositions[i], step);
            else
                target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, OriginalPositions[i], step);
            i++;
        }
    }

}
