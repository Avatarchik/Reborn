using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

    public float dist = 20f;
    public Transform handPos;

    private bool iteminHand;
    private Transform currentItem;

    private string itemName;
    private int itemAmmount;
    private Animator Anim1;

    void Start()
    {
        Anim1 = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 forward = this.transform.forward * dist;
        Debug.DrawRay(Input.mousePosition, forward, Color.red, 100);

        if (Physics.Raycast(ray, out hit, dist) && hit.collider.tag == "activator")
        {
            Debug.Log("Hit Activator #1");
            #region Hitting Objects With Activator Tag
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Hit Activator #2");

                bl_CoopUtils.LockCursor(false);
                bl_RoomController.ChangeResumeBool();

                hit.collider.GetComponent<scriptActivator>().RunScript();
            }
            #endregion
        } else 

        if (Physics.Raycast(ray, out hit, dist) && hit.collider.tag == "NetworkPlayer") //hit.collider.tag == "Player" || 
        {
            Debug.Log("Hitting Player");
            #region If Hit Player
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("Trying to handcuff player");
                PhotonView photonViewPlayer = hit.collider.GetComponent<PhotonView>();
                photonViewPlayer.RPC("takeActionhandCuffed", PhotonTargets.All);
            }
            #endregion
        } else

        if (Physics.Raycast(ray, out hit, dist) && hit.collider.tag == "PickUpAble")
        {
            
            Debug.Log("Hitting PickUp Object");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (iteminHand == false)
                {
                    Debug.Log("Attaching Object");
                    currentItem = hit.collider.GetComponent<Transform>();
                    currentItem.parent = handPos;
                    Anim1.SetBool("pickupitem", true);
                } else if (iteminHand)
                {
                    Debug.Log("De-Attaching Object");
                    currentItem.parent = null;
                    currentItem.position = hit.point;
                    Anim1.SetBool("pickupitem", false);
                }  
            } 
        }
    }
}
