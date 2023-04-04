using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushDetector : MonoBehaviour
{
    public HealthScript health;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Crusher"))
        {
            //Debug.Log("Crushed by the Crusher");
            health.Die();
        }
    }

}
