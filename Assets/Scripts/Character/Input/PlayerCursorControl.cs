using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorControl : MonoBehaviour
{
    public float mouseSense = 1f;
    [SerializeField] private Transform player = null;
   // [SerializeField] private float rotationSpeed;
    // private gameObject player;

    void Start()
    {

    }


    void Update()
    {
        RotateCharacter();
    }

    void RotateCharacter()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSense;
        float rotAmountY = mouseY * mouseSense;

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        // rotPlayer.x -= rotAmountY;
        rotPlayer.z = 0;
        rotPlayer.x = 0;

        rotPlayer.y += rotAmountX;

        //rotPlayer = (rotPlayer.x, rotPlayer.y, rotPlayer.z);

        player.rotation = Quaternion.Euler(rotPlayer);

    }
}
