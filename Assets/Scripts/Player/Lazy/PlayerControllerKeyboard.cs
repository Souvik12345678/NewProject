using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//KeyboardInput Module
public class PlayerControllerKeyboard : MonoBehaviour
{
    public LazyDriveController controller;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            controller.RotateDir = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            controller.RotateDir = 1;
        }
        else
        {
            controller.RotateDir = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            controller.DriveEnabled = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            controller.DriveEnabled = true;
        }
    }
}
