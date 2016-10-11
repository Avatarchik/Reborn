using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

    public float dist = 20f;

    private string itemName;
    private int itemAmmount;
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 forward = this.transform.forward * dist;
        Debug.DrawRay(Input.mousePosition, forward, Color.red, 100);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            #region ATM
            if (Physics.Raycast(ray, out hit, dist) && hit.collider.tag == "ATM")
            {
                Debug.Log("Hit ATM");

                bl_CoopUtils.LockCursor(false);
                bl_RoomController.ChangeResumeBool();
                hit.collider.GetComponent<ATM>().PlayerTemp = this.gameObject;
                hit.collider.GetComponent<ATM>().ShowUI();
                hit.collider.GetComponent<ATM>().RunScript();

            } else
            #endregion

            #region Pickupable
            if (Physics.Raycast(ray, out hit, dist) && hit.collider.tag == "pickupable")
            {
                Debug.Log("Hit pickupAble");

                hit.collider.GetComponent<pickupAble>().sendDetails(); 
            }
            #endregion
        }
    }
}
