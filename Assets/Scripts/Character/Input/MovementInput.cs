using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    private CharacterController controller = null;
    private Animator animator = null;

    private float movementSpeed = 3f;
    private float readyMovementSpeed = 1.5f;
    private float currentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.01f;
    private float rotationSpeed = 0.1f;
    private float gravity = 3f;

    public Camera PlayerCamera;
    private Vector3 TestVelocity;
    public float mouseSense = 0.1f;
   


    private Transform player;
    private Transform mainCameraTransform = null;

    private bool ReadyWeaponMovement = false;


    // Start is called before the first frame update
    void Awake()
    {
        player = this.gameObject.transform;
        Cursor.visible = true;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        GetComponent<PlayerCharacter>().PlayerCamera = PlayerCamera;
        mainCameraTransform = PlayerCamera.transform;
    } 

    // Update is called once per frame
    void Update()
    {
        Move();
        ReadyWeapon();
        RotateCharacter();

        //Attacking
        if (Input.GetButton("Fire1"))
        GetComponent<PlayerCharacter>().CharacterAttack();
      
    }


    private void Move() {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;


        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();



         Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }

        /* if (desiredMoveDirection != Vector3.zero)
         {
             mainCameraTransform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
         }
         */
        float targetSpeed = 0;
        if (ReadyWeaponMovement == false)
        {
             targetSpeed = movementSpeed * movementInput.magnitude;
        }
        else {
             targetSpeed = readyMovementSpeed * movementInput.magnitude;
        }
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
        


        /*animator.SetFloat("Speed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
        animator.SetFloat("Speed", movementInput.magnitude);
         TestVelocity = desiredMoveDirection * currentSpeed * Time.deltaTime;
        Debug.Log(movementInput.magnitude);*/
    }

    void RotateCharacter()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseSenseReady = mouseSense * 0.5f;
        float rotAmountX = 0f;
        float rotAmountY = 0f;
        
        
        if (ReadyWeaponMovement == false)
        {
             rotAmountX = mouseX * mouseSense;
             rotAmountY = mouseY * (mouseSense * -1.4f);
        }
        else {
            rotAmountX = mouseX * mouseSenseReady;
            rotAmountY = mouseY * (mouseSenseReady * -1.4f);
        }

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        rotPlayer.y += rotAmountX;
        rotPlayer.z = 0;

        if (ReadyWeaponMovement == true)
        {
            rotPlayer.x += rotAmountY;

            if (rotPlayer.x < 320f && rotPlayer.x > 65f) {
                rotPlayer.x = 320f;
            }
            if (rotPlayer.x > 59f && rotPlayer.x < 320f) {
                rotPlayer.x = 55f;
            }
        }
        else {
            rotPlayer.x = 0;
        }

        if (Input.GetButtonUp("Turn"))
            rotPlayer.y = rotPlayer.y - 180f;

        player.rotation = Quaternion.Euler(rotPlayer);
       
        

    }

     

    void ReadyWeapon()
    {

        if (Input.GetButton("Fire2") && ReadyWeaponMovement == false)
        {
            GetComponent<PlayerCharacter>().ReadyCharacterWeapon();
            ReadyWeaponMovement = true;  

        }
        if ((Input.GetButtonUp("Fire2") && ReadyWeaponMovement == true))
        {
            GetComponent<PlayerCharacter>().ReadyCharacterWeapon();
            ReadyWeaponMovement = false;

        }
    }

    


}
