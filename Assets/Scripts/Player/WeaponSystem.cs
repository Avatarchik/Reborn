using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {

    public GameObject weapon;
    public bool wep1 = false;


	void Start () {
        weapon.SetActive(false);
	}
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeWeapon();
        }
	    
	}
    void changeWeapon()
    {
        if (wep1 == false)
        {   
            wep1 = true;
            Debug.Log("Weapon Active");
            weapon.SetActive(true);
        }
    }
}
