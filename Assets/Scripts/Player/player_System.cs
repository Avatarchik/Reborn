using UnityEngine;
using System.Collections;

public class player_System : MonoBehaviour {

    //## Job Status Area ##//
    protected string currentJob = "None";
    //## Player Components ##//
    private CharacterController CharController;
    private bl_MouseLook MouseLookPar;
    private bl_MouseLook MouseLookChild;
    //## Bool Area ##//
    protected bool handCuffed;
    protected bool hitByTazer;
    //## Animation ##//
    private Animator Anim;


    #region Start Function
    void Start () {
        CharController = this.GetComponent<CharacterController>();
        MouseLookChild = this.GetComponentInChildren<bl_MouseLook>();
        Anim = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Update Function
    void Update () {
	}
    #endregion

    [PunRPC]
    public void takeActionhandCuffed()
    {
        #region handCuff Area
        if(handCuffed == false)
        {
            
            this.gameObject.isStatic = true;
            Anim.SetBool("handcuffed", true);
            handCuffed = true;
            
        } else
        {
            handCuffed = false;
        }
        #endregion
    }

    public void takeActiontazer()
    {
        #region hitByTazer Area
        if (hitByTazer == false)
        {
            Debug.Log("Do Somet");
        }
        else if (hitByTazer == true)
        {
            Debug.Log("Do Something");
        }
        #endregion
    }

    public void updateCurrentJob(string curJob)
    {
        currentJob = curJob;
        Debug.Log("Current Job is: " + curJob);
    }

}
