using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollScript : MonoBehaviour
{
    public bool isInTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If collider is tagged ground
        if (collision.collider.CompareTag("ground") || collision.collider.IsTouchingLayers(LayerMask.GetMask("Obstacles")))
        {
            isInTouch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If collider is tagged ground
        if (collision.collider.CompareTag("ground") || collision.collider.IsTouchingLayers(LayerMask.GetMask("Obstacles")))
        {
            isInTouch = false;
        }
    }
}
