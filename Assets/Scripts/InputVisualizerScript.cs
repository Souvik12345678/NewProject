using UnityEngine;
using UnityEngine.UI;

//Visualize the inputs going in to the controller
public class InputVisualizerScript : MonoBehaviour
{
    public Sprite rightArrow;
    public Sprite leftArrow;
    public Sprite cross;

    public Image dispImg;
    
    public LazyDriveController control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (control.RotateDir == -1)
        {
            dispImg.sprite = leftArrow;
        }
        else if (control.RotateDir == 1)
        {
            dispImg.sprite = rightArrow;
        }
        if (control.RotateDir == 0)
        {
            dispImg.sprite = cross;
        }
    }
}
