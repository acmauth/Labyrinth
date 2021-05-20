using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lever<T> : MonoBehaviour
{
    private Transform lever;
    [SerializeField]
    private float leverPullTime = 0.2f;
    [SerializeField]
    private float rotateRange = 90f;
    [SerializeField]
    private bool leverPulled;

    [SerializeField]
    private bool inArea;
    [SerializeField]
    private bool canPullHandle;

    public GameObject[] targets; //The target platform or door. May have multiple targets, may implement that later on
                                 // [SerializeField]
                                 // private float accelTime = 2.0f;
                                 // [SerializeField]
                                 // private float decelTime = 0.5f;
    [SerializeField]
    private Direction[] directions;
    [SerializeField]
    private float targetMovingSpeed = 10f;
    [SerializeField]
    private float moveDistance = 2f;
    private T[] originalPositions; //The original position of every target
    private T[] targetPositions; //target position of every target

    public abstract void Action();

    public bool InArea { get => inArea; set => inArea = value; }
    public bool CanPullHandle { get => canPullHandle; set => canPullHandle = value; }
    public T[] OriginalPositions { get => originalPositions; set => originalPositions = value; }
    public T[] TargetPositions { get => targetPositions; set => targetPositions = value; }
    public float TargetMovingSpeed { get => targetMovingSpeed; set => targetMovingSpeed = value; }
    internal Direction[] Directions { get => directions; set => directions = value; }
    public float MoveDistance { get => moveDistance; set => moveDistance = value; }
    public Transform LeverHandle { get => lever; set => lever = value; }
    public bool LeverPulled { get => leverPulled; set => leverPulled = value; }
    public float RotateRange { get => rotateRange; set => rotateRange = value; }


    // Start is called before the first frame update

    void Awake()
    {
        OriginalPositions = new T[targets.Length];
        TargetPositions = new T[targets.Length];
        LeverHandle = transform.Find("Handle");
        CanPullHandle = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InArea)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                LeverPulled = !LeverPulled;
                
                if (CanPullHandle)
                {
                    LeverHandle.Rotate(Vector3.forward, RotateRange); //we want this to happen only once
                    CanPullHandle = false;
                }
                else
                {
                    LeverHandle.Rotate(Vector3.forward, -RotateRange);
                    CanPullHandle = true;
                }

            }

        }

        Action();

       /* int i = 0;
        foreach (GameObject target in targets)
        {
            if(LeverPulled)
                Action(target, TargetPositions[i]);
            else
                Action(target, OriginalPositions[i]);
            i++;
        }
       */

    }

    private void OnTriggerEnter2D(Collider2D collision) //If the player pulls the lever
    {
        if (collision.transform.tag == "Player")
        {
            InArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            InArea = false;

        }
    }

}
