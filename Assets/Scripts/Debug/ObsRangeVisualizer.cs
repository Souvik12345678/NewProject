using UnityEngine;

[ExecuteAlways]
public class ObsRangeVisualizer : MonoBehaviour
{
    public ObstacleRangesSO ranges;

    private void Update()
    {
        if (ranges)
        {
            foreach (var item in ranges.obstacleProfiles)//Foreach range
            {
                //Start pt
                Vector3 start = new Vector3(item.startDist, 10);
                Vector3 end = new Vector3(item.startDist, -10);
                Debug.DrawLine(start, end, Color.green);

                //End pt
                start.Set(item.endDist, 10, 0);
                end.Set(item.endDist, -10, 0);
                Debug.DrawLine(start, end, Color.red);

                //Third arrow
                {
                    start.Set(item.startDist, 8, 0);
                    end.Set(item.endDist, 8, 0);
                    Debug.DrawLine(start, end, Color.green);

                    start.Set(item.endDist, 8, 0);
                    end.Set(item.endDist - 1f, 9f, 0);
                    Debug.DrawLine(start, end, Color.green);

                    start.Set(item.endDist, 8, 0);
                    end.Set(item.endDist - 1f, 7f, 0);
                    Debug.DrawLine(start, end, Color.green);
                }
            }
        }
    }

}
