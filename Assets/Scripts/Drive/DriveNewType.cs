using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveNewType : MonoBehaviour
{
    public float driveX;

    public float torque;

    public float rotationForce;

    public WheelJoint2D wheelJoint;
    public Rigidbody2D balanceBody;
    public Rigidbody2D wheelBody;

    public WheelCollScript wheelCollDetect;
    

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
        //wheelJoint.useMotor = true;

        //balanceBody.AddTorque(-rotDir * torque, ForceMode2D.Force);

        if (wheelCollDetect.isInTouch)
        {
            dummyBody.AddRelativeForce(Vector2.right * rotationForce * rotDir, ForceMode2D.Force);
        }
        
    }


}
