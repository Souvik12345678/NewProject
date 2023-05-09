using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerScript : MonoBehaviour
{
    public float maxTorq;
    public float maxAngVel;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D body;
    public Transform target;
    public AudioSource audSrc;

    public GameObject explosionParticle;

    public CommonAssetSO commAsset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(body.angularVelocity);
    }

    private void FixedUpdate()
    {
        if (body.angularVelocity < maxAngVel)
        {
            body.AddTorque(maxTorq);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("crusher"))
        {
            CosmeticDestroy();
            Destroy(gameObject, 5);
        }
    }

    void CosmeticDestroy()
    {
        int a = Random.Range(0, 2);
        if (a == 0)
            audSrc.clip = commAsset.explosionSfx;
        else
            audSrc.clip = commAsset.explosionSfx1;

        audSrc.Play();
        spriteRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        body.velocity = new Vector2();

        var exp = Instantiate<GameObject>(explosionParticle, transform.position, Quaternion.identity);
        Destroy(exp, 5);

    }

}
