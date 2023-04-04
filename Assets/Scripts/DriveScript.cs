using UnityEngine;

public class DriveScript : MonoBehaviour
{
    public Transform follow;
    public WheelJoint2D j;
    public Rigidbody2D body;
    public Rigidbody2D wheelBody;

    public Rigidbody2D pawn;

    float balance_sin = 0.0f;

    private void Awake()
    {
        // Set up graph properties using our graph keys
        DebugGUI.SetGraphProperties("TargetAngle", "TargetAngle", Mathf.Sin(0.6f) * -Mathf.Rad2Deg, Mathf.Sin(0.6f) * Mathf.Rad2Deg, 2, new Color(0, 1, 1), false);
        DebugGUI.SetGraphProperties("TargetVel", "TargetVel", -500, 500, 1, new Color(1, 0, 0), false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        float target_x = follow.position.x;

        float max_v = 500.0f;
        float target_v = Mathf.Clamp(bias_coef(0.5f, dt / 1.2f) * (target_x - body.position.x) / dt, -max_v, max_v);

        float error_v = (target_v - body.velocity.x);
        float target_sin = 0.003f * bias_coef(0.1f, dt) * error_v / dt;

        float max_sin = Mathf.Sin(0.6f);
        balance_sin = Mathf.Clamp(balance_sin - 0.00006f * bias_coef(0.2f, dt) * error_v / dt, -max_sin, max_sin);
        float target_a = Mathf.Asin(Mathf.Clamp(-target_sin + balance_sin, -max_sin, max_sin));
        //float angular_diff = Mathf.Asin(cpvcross(cpBodyGetRotation(balance_body), cpvforangle(target_a)));
        float angular_diff = Mathf.Asin(cpvcross(body.transform.right, cpvforangle(target_a)));
        float target_w = bias_coef(0.1f, dt / 0.4f) * (angular_diff) / dt;

        float max_rate = 5000.0f;
        float rate = Mathf.Clamp(wheelBody.angularVelocity + body.angularVelocity - target_w, -max_rate, max_rate);
        
        //cpSimpleMotorSetRate(motor, cpfclamp(rate, -max_rate, max_rate));

        JointMotor2D mot = new JointMotor2D();
        mot.motorSpeed = Mathf.Clamp(rate, -max_rate, max_rate);
        //cpConstraintSetMaxForce(motor, 8.0e4);
        mot.maxMotorTorque = 800000f;

        j.motor = mot;


        //Debug.Log(Mathf.Rad2Deg * target_a);
        DebugGUI.Graph("TargetAngle", Mathf.Rad2Deg * target_a);
        DebugGUI.Graph("TargetVel", target_v);

        //DebugGUI.Graph("fixedFrameRateSin", Mathf.Sin(Time.time * 6));


    }

    float bias_coef(float errorBias, float dt)
    {
        return 1.0f - Mathf.Pow(errorBias, dt);
    }
    Vector2 cpvforangle(float a)
    {
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }

    float cpvcross(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.y - v1.y * v2.x;
    }

}
