using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveNewType1 : MonoBehaviour
{
    public float driveX;

    public float torque;

    public float rotationForce;

    public Rigidbody2D balanceBody;
    public Rigidbody2D wheelBody;

    public NewWheelCollScript wheelCollDetect;
    
    public Rigidbody2D dummyBody;

    public float rotDir;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotDir = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotDir = 1;
        }
        else
        {
            rotDir = 0;
        }
    }

    private void FixedUpdate()
    {

        if (wheelCollDetect.CheckIfGrounded())
        {
            dummyBody.AddRelativeForce(rotationForce * rotDir * Vector2.right, ForceMode2D.Force);
        }
        
    }


}
