using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    [Range(0.0001f, 100)]
    public float wheelRad;
    public Rigidbody2D wBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float angVel = wBody.velocity.magnitude / wheelRad;
        angVel = Mathf.Rad2Deg * angVel;
        transform.Rotate(0, 0, -angVel * Time.fixedDeltaTime);
    }


}
