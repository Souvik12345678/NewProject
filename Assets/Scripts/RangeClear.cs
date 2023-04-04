using UnityEngine;

//Cheap hacks, will change later
public class RangeClear : MonoBehaviour
{
    public ObstacleRangesSO obstacleRanges;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in obstacleRanges.obstacleProfiles)
        {
            item.isUsed = false;
        }
        
    }
}
