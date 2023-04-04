using UnityEngine;

public class NewJointBreakScript : MonoBehaviour
{
    public CommonAssetSO commonAssets;
    public AudioSource audSrc;
    public HealthScript health;

    private void OnJointBreak2D(Joint2D joint)
    {
        audSrc.PlayOneShot(commonAssets.boneBreakSfx);
        
        if (health)
            health.Die();
    }
}
