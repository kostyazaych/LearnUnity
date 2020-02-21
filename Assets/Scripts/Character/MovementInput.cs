using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    private CharacterController controller = null;
    private Animator animator = null;

    [SerializeField] private float movementSpeed = 3f;
    private float currentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.01f;
    private float rotationSpeed = 0.1f;
    private float gravity = 3f;
    public Camera PlayerCamera;
    private Vector3 TestVelocity;
    private Transform mainCameraTransform = null;
    // Start is called before the first frame update
    void Start()
    {
           controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        GetComponent<PlayerCharacter>().PlayerCamera = PlayerCamera;
        mainCameraTransform = PlayerCamera.transform;
    } 

    // Update is called once per frame
    void Update()
    {
         Move();
    }


    private void Move() {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

       
        
        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
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
        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);

        //animator.SetFloat("Speed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
        animator.SetFloat("Speed", movementInput.magnitude);
         TestVelocity = desiredMoveDirection * currentSpeed * Time.deltaTime;
        //Debug.Log(movementInput.magnitude);
    }
}
