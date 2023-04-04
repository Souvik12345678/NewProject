using UnityEngine;

/// <summary>
/// Class that holds all common assets for easy access
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/CommonAsset", order = 1)]
public class CommonAssetSO : ScriptableObject
{
    public ObstacleRangesSO AllObstacleRanges;

    [Header("Some Prefabs")]
    public GameObject WoodenCrate;
    public GameObject Tire;
    public GameObject[] AllObstacles;

    [Header("Background Sfx")]
    public AudioClip bgm1;
    public AudioClip bgm2;

    [Header("Some Sfx")]
    public AudioClip boneBreakSfx;

}
