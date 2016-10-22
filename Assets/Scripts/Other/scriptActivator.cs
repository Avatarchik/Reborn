using UnityEngine;
using System.Collections;
using LifeResources;

public class scriptActivator : MonoBehaviour {

    public bool UI;
    public bool Vehicles;

    public string instanceName;

    private bool spawned;

    public void RunScript() {

        if(UI == true && Vehicles == false)
        {
            bl_CoopUtils.LockCursor(false);
            bl_RoomController.NoResume = true;
            
            if(spawned == false)
            {
                spawned = true;
                Debug.Log("Trying to spawn UI");
                GameObject spawnInstance = GameObject.Instantiate(ResourcesLoad.ui[instanceName]);
                delayTimer();
            }
            
        }else if(Vehicles == true && UI == false)
        {
            Debug.Log("Vehicles Selected");
        }  
    }
    IEnumerator delayTimer()
    {
        yield return new WaitForSeconds(2);
        spawned = false;
    }
}
