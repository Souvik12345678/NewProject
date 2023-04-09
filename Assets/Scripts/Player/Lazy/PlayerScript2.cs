using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : PlayerScript
{
    public LazyDriveController driveControl;

    protected override void OnMyHealthDepleted()
    {
        driveControl.DriveEnabled = false;

        //Call on ded event
        OnDed?.Invoke();
    }
}
