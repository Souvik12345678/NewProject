using UnityEngine;

public class DriveV3 : MonoBehaviour
{
    const float PTM_RATIO = 100;
    public Transform follow;
    public WheelJoint2D wheelJoint;
    public Rigidbody2D balanceBody;
    public Rigidbody2D wheelBody;

    float balance_sin = 0.0f;

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        float target_x = follow.position.x;

        float max_v = 500f;

        float target_v = Mathf.Clamp(bias_coef(0.5f, dt / 1.2f) * ((target_x - balanceBody.position.x) * PTM_RATIO) / dt, -max_v, max_v);

        float error_v = (target_v - (balanceBody.velocity.x * PTM_RATIO));
        float target_sin = 0.003f * bias_coef(0.1f, dt) * error_v / dt;

        float max_sin = Mathf.Sin(0.6f);
        balance_sin = Mathf.Clamp(balance_sin - 0.00006f * bias_coef(0.2f, dt) * error_v / dt, -max_sin, max_sin);
        float target_a = Mathf.Asin(Mathf.Clamp(-target_sin + balance_sin, -max_sin, max_sin));
        
        float angular_diff = Mathf.Asin(cpvcross(balanceBody.transform.right, cpvforangle(target_a)));
        float target_w = bias_coef(0.1f, dt / 0.4f) * (angular_diff) / dt;

        float max_rate = 50.0f;
        float rate = Mathf.Clamp(((wheelBody.angularVelocity + balanceBody.angularVelocity) * Mathf.Deg2Rad) - target_w, -max_rate, max_rate);

        //Apply motor force
        JointMotor2D mot = new JointMotor2D();
        //mot.motorSpeed = Mathf.Clamp(rate, -max_rate, max_rate);
        float mSpeedRad = Mathf.Clamp(rate, -max_rate, max_rate);
        mot.motorSpeed = mSpeedRad * Mathf.Rad2Deg;
        mot.maxMotorTorque = 800000f;
        wheelJoint.motor = mot;


        //Debug.Log(balanceBody.velocity);

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
