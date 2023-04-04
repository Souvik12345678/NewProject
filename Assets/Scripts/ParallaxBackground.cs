using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 effectMultiplier;
    [SerializeField] private bool infHorizon;
    [SerializeField] private bool infVertical;

    public Transform camTransform;
    private Vector3 lastCamPos;
    private float texUnitSizeX;
    private float texUnitSizeY;

    // Start is called before the first frame update
    void Start()
    {
        lastCamPos = camTransform.position;
        Sprite sp = GetComponent<SpriteRenderer>().sprite;
        Texture2D tex = sp.texture;

        texUnitSizeX = tex.width / sp.pixelsPerUnit;
        texUnitSizeY = tex.height / sp.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 delta = camTransform.position - lastCamPos;
        transform.position += new Vector3(delta.x * effectMultiplier.x, delta.y * effectMultiplier.y);
        lastCamPos = camTransform.position;

        if (infHorizon) {

            if (Mathf.Abs(camTransform.position.x - transform.position.x) >= texUnitSizeX) {

                float offX = (camTransform.position.x - transform.position.x) % texUnitSizeX;
                transform.position = new Vector3(camTransform.position.x + offX, transform.position.y);
            }
        }

        if (infVertical)
        {
            if (Mathf.Abs(camTransform.position.y - transform.position.x) >= texUnitSizeY)
            { 
                float offY = (camTransform.position.y - transform.position.y) % texUnitSizeY;
                transform.position = new Vector3(camTransform.position.y, transform.position.y + offY);
            }
        }

    }
}
