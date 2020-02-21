using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera RoomCamera;
    private Camera LastCamera;
    private GameObject PlayerObject;
    private bool EnterRoom = false;
    void Start()
    {
     
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (RoomCamera != null)
        {
           
            PlayerObject = GameObject.Find("PlayerObject");
            PlayerObject.GetComponent<PlayerCharacter>().PlayerCamera.enabled = false;
            
            if (EnterRoom == false)
            {
                LastCamera = PlayerObject.GetComponent<PlayerCharacter>().PlayerCamera;
                PlayerObject.GetComponent<PlayerCharacter>().PlayerCamera = RoomCamera;
                PlayerObject.GetComponent<MovementInput>().PlayerCamera = RoomCamera;
                LastCamera.enabled = false;
                EnterRoom = true;
            }
            else {
                PlayerObject.GetComponent<PlayerCharacter>().PlayerCamera = LastCamera;
                PlayerObject.GetComponent<MovementInput>().PlayerCamera = LastCamera;
             
                EnterRoom = false;
            }
            PlayerObject.GetComponent<PlayerCharacter>().PlayerCamera.enabled = true;
            
        }
        Debug.Log("trigger!!#213");
    }
}
