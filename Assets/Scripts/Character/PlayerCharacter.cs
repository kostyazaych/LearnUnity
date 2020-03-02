using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    public Camera PlayerCamera;
    private GameObject playerCharacter;
    public GameObject playerWeapon;


    public bool readyWeapon = false;



    // Start is called before the first frame update
    void Start()
    {
         PlayerCamera.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    void CheckInput()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //Debug.Log("InputFunc");
    }

   public void ReadyCharacterWeapon() {
        Debug.Log(playerWeapon.GetComponent<WeaponBase>().weaponStillPos);
        if (readyWeapon == false)
        {
            playerWeapon.GetComponent<WeaponBase>().ReadyState();
            readyWeapon = true;
        }
        else {
            playerWeapon.GetComponent<WeaponBase>().StillState();
            readyWeapon = false;
        }
    }

    public void CharacterAttack() {
        playerWeapon.GetComponent<WeaponBase>().BaseAttack();
    }
}


