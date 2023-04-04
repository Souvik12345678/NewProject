using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBreakScript : MonoBehaviour
{
    public AudioClip boneBreakSfx;
    public AudioSource audSrc;

    private void OnJointBreak2D(Joint2D joint)
    {
        audSrc.Play();
        GetComponent<HealthScript>().Die();
    }
}
