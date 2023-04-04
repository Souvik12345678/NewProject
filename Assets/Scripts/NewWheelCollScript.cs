using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWheelCollScript : MonoBehaviour
{
    public bool isCollGrounded;

    public bool isGrounded;

    public float rayLen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If collider is tagged ground
        if (ColliderGroundCheck(collision))
        {
            isCollGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If collider is tagged ground
        if (collision.collider.CompareTag("ground") || collision.collider.IsTouchingLayers(LayerMask.GetMask("Obstacles")))
        {
            isCollGrounded = false;
        }
    }

    bool ColliderGroundCheck(Collision2D coll)
    {
        return coll.collider.CompareTag("ground") || coll.collider.IsTouchingLayers(LayerMask.GetMask("Obstacles"));
    }

    bool RaycastGroundCheck()
    {
        RaycastHit2D[] hit2Ds;
        int c = 0;
        //Ray1
        hit2Ds = Physics2D.RaycastAll(transform.position, Vector2.left, rayLen, LayerMask.GetMask("Terrain", "Obstacles"));
        Debug.DrawRay(transform.position, Vector3.left * rayLen, Color.green);
        c += hit2Ds.Length;

        //Ray2
        hit2Ds = Physics2D.RaycastAll(transform.position, Vector2.down, rayLen, LayerMask.GetMask("Terrain", "Obstacles"));
        Debug.DrawRay(transform.position, Vector3.down * rayLen, Color.green);
        c += hit2Ds.Length;

        //Ray3
        hit2Ds = Physics2D.RaycastAll(transform.position, Vector2.right, rayLen, LayerMask.GetMask("Terrain", "Obstacles"));
        Debug.DrawRay(transform.position, Vector3.right * rayLen, Color.green);
        c += hit2Ds.Length;

        return c > 0;
    }

    public bool CheckIfGrounded()
    {
        isGrounded = isCollGrounded || RaycastGroundCheck();
        return isGrounded;
    }

}
