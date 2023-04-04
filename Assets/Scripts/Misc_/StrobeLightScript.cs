using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLightScript : MonoBehaviour
{
    public float onDelay;
    public float offDelay;

    public SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(StrobeRoutine));
    }

    public IEnumerator StrobeRoutine()
    {
        while (true)
        {
            sp.enabled = true;
            yield return new WaitForSeconds(onDelay);
            sp.enabled = false;
            yield return new WaitForSeconds(offDelay);
        }
    }

}
