using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : MonoBehaviour
{
    public Transform follow;
    public Rigidbody2D pawn;

    float balance_sin = 0.0f;

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
        float target_v = Mathf.Clamp(bias_coef(0.5f, dt / 1.2f) * (target_x - pawn.position.x) / dt, -max_v, max_v);//Gives the target velocity
        
        float error_v = (target_v - pawn.velocity.x);
        float target_sin = 0.003f * bias_coef(0.1f, dt) * error_v / dt;
        
        float max_sin = Mathf.Sin(0.6f);
        balance_sin = Mathf.Clamp(balance_sin - 0.00006f * bias_coef(0.2f, dt) * error_v / dt, -max_sin, max_sin);
        //Debug.Log(balance_sin);
        float target_a = Mathf.Asin(Mathf.Clamp(-target_sin + balance_sin, -max_sin, max_sin));
        float angular_diff = Mathf.Asin(cpvcross(pawn.transform.right, cpvforangle(target_a)));
        float target_w = bias_coef(0.1f, dt / 0.4f) * (angular_diff) / dt;

        float max_rate = 5000.0f;
        float rate = Mathf.Clamp(pawn.angularVelocity - target_w, -max_rate, max_rate);

        //Debug.Log(rate);

        pawn.velocity = new Vector2(target_v, pawn.velocity.y);
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
