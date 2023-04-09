using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAI : MonoBehaviour
{
    public enum Orientation { LEAN_LEFT, LEAN_RIGHT }
    Orientation orient;

    public int targetControl;

    public LazyDriveController controller;

    public float minInDelay;
    public float maxInDelay;
    public float inputDelay;
    public float currentInputDelay;

    private float timer = 0.0f; // Timer
    // Start is called before the first frame update
    void Start()
    {
        currentInputDelay = inputDelay;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateOrientation();
        Control();
    }

    void CalculateOrientation()
    {
        float res = Vector2.SignedAngle(transform.up, Vector2.up);
        orient = (res < 0) ? Orientation.LEAN_LEFT : Orientation.LEAN_RIGHT;
    }

    void Control()
    {
        if (orient == Orientation.LEAN_LEFT)
        {
            targetControl = 1;
        }
        else if (orient == Orientation.LEAN_RIGHT)
        {
            targetControl = -1;
        }

        // Check if enough time has passed
        if (timer < currentInputDelay)
        {
            timer += Time.deltaTime; // Update the timer with deltaTime
        }
        else
        {
            if (controller.RotateDir != targetControl)
            {
                ChangeControl(targetControl);
                timer = 0.0f;
                currentInputDelay = Random.Range(minInDelay, maxInDelay);
            }
        }
    }

    //Change control with a delay
    void ChangeControl(int targetControl)
    {
        controller.RotateDir = targetControl;
    }

}
