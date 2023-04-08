using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only the controller module to be operated by KeyboardInput or AI
public class LazyDriveController : MonoBehaviour
{
    public float driveX;

    public float playerRotForce;
    public float wheelMotorSpeed;

    public Rigidbody2D balanceBody;
    public Rigidbody2D wheelBody;
    public WheelJoint2D wheelJoint;

    public NewWheelCollScript wheelCollDetect;
    public Rigidbody2D dummyBody;//Is a colliderless body attached to the head of balanceBody used to apply rotational forces.

    public float rotDir;

    public bool isGrounded;

    public bool DriveEnabled
    {
        get { return isDriveEnabled; }

        set
        {
            isDriveEnabled = value;
            
            //Disable motor
            var m = new JointMotor2D();
            m.maxMotorTorque = wheelJoint.motor.maxMotorTorque;
            m.motorSpeed = (isDriveEnabled) ? -wheelMotorSpeed : 0;
            wheelJoint.motor = m;
        }
    }

    public int RotateDir
    {
        get { return (int)rotDir; }
        set 
        {
            if (value >= -1 || value <= 1)
            {
                rotDir = value;
            }
        }
    }

    private bool isDriveEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        var m = new JointMotor2D();
        m.maxMotorTorque = wheelJoint.motor.maxMotorTorque;
        m.motorSpeed = -wheelMotorSpeed;//minus because motor rotation is reversed
        wheelJoint.motor = m;
    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void FixedUpdate()
    {
        isGrounded = wheelCollDetect.CheckIfGrounded();
        if (isGrounded && isDriveEnabled)
        {
            dummyBody.AddRelativeForce(playerRotForce * rotDir * Vector2.right, ForceMode2D.Force);
        }
    }
}
