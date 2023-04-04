using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float volume;
    public AudioSource audSrc;
    public CommonAssetSO commonAssets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomBgm()
    {
        int a = Random.Range(0, 2);
        AudioClip clip;
        if (a == 0)
        {
            clip = commonAssets.bgm1;
        }
        else
        {
            clip = commonAssets.bgm2;
        }

        audSrc.volume = volume;
        audSrc.clip = clip;
        audSrc.loop = true;
        audSrc.Play();
    }

}
