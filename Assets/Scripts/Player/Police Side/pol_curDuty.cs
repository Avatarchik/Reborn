using UnityEngine;
using System.Collections;

public class pol_curDuty : MonoBehaviour
{

    //## This is What Happens When you go on duty ##//
    public void onDuty()
    {
            Debug.Log("OnDuty");

            bl_CoopUtils.LockCursor(true);
            bl_RoomController.NoResume = false;

            ZPlayerPrefs.SetString("curJob", "Police");

            Debug.Log(ZPlayerPrefs.GetString("curJob"));

            Destroy(this.gameObject);
    }

    //## This is what happens when you go off duty ##//
    public void offDuty()
    {
        Debug.Log("OffDuty");

        ZPlayerPrefs.SetString("curJob", "None");

        bl_CoopUtils.LockCursor(true);
        bl_RoomController.NoResume = false;

        Debug.Log(ZPlayerPrefs.GetString("curJob"));

        Destroy(this.gameObject);
    }
}
