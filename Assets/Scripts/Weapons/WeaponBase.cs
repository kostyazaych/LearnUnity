using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public Vector3 weaponStillPos;
    public Vector3 weaponReadyPos;

    private Transform weaponOwner = null;
    private GameObject weaponObject = null;

    // Start is called before the first frame update
    void Start()
    {
        weaponObject = this.gameObject;
        weaponOwner = this.gameObject.transform.parent;
        weaponOwner.GetComponent<PlayerCharacter>().playerWeapon = weaponObject;

        //Debug.Log(weaponOwner.GetComponent<PlayerCharacter>().playerWeapon);
       

    }

    // Update is called once per frame
    void Update()
    {

    }

   public void ReadyState()
    {
            gameObject.transform.localPosition = weaponStillPos;
            weaponOwner.GetComponent<PlayerCharacter>().readyWeapon = false;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        Debug.Log("Ready");

    }
    public void StillState() {
        gameObject.transform.localPosition = weaponReadyPos;
        weaponOwner.GetComponent<PlayerCharacter>().readyWeapon = true;
        gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0);
      
        Debug.Log("Still");
    }

}





/*
0.293 0.49  0.817
0.43  0.042  0.1778655
.transform.parent
    gameObject
*/


// GameObject.Find("PlayerObject");
//  this.gameObject   .GetComponentInParent
