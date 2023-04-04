using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript1 : PlayerScript
{
    public LazyDriveScript driveControl;

    protected override void OnMyHealthDepleted()
    {
        driveControl.DriveEnabled = false;

        //Call on ded event
        OnDed?.Invoke();
    }
}
