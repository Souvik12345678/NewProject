using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherScript : MonoBehaviour
{
    public float kickForceMul;

    public Rigidbody2D crusherBody;

    public float velocity;

    private void FixedUpdate()
    {
        crusherBody.velocity = new Vector2(velocity, crusherBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Torso"))
        {
            collision.rigidbody.AddForce(Vector2.right * kickForceMul, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))//If it is a terrain
        {
            Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.green);
        }
    }

}
