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
       
        Debug.Log(weaponOwner.GetComponent<PlayerCharacter>().readyWeapon);
        ToggleState();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ToggleState()
    {

        if (weaponOwner.GetComponent<PlayerCharacter>().readyWeapon == true)
        {
            gameObject.transform.position = weaponStillPos;
            Debug.Log("DA");
        }
        else {
            gameObject.transform.position = weaponReadyPos;
            Debug.Log("PIZDA");
        }
         //Pistol.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        
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
