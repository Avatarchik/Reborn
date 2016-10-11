using UnityEngine;
using System.Collections;
using spawnInvoSlot;

public class pickupAble : MonoBehaviour {

    public int itemID;
    public string itemName;
    public int itemAmount = 1;

    protected spawnNewItem PlayerInvo;

    private bool SpawnedUI;

    void Start()
    {
        PlayerInvo = GameObject.FindWithTag("invoUI").GetComponent<spawnNewItem>();
    }

	public void sendDetails()
    {
        if(SpawnedUI == false)
        {
            SpawnedUI = true;
            if (PlayerInvo == null)
            {
                PlayerInvo = GameObject.FindWithTag("invoUI").GetComponent<spawnNewItem>();
            }
            else
            {
                PlayerInvo.AddItem(itemName, itemAmount, itemID);
                SpawnedUI = false;
            }
        }
        
  	}
}
