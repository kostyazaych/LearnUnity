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

    public float mouseSense = 0.1f;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
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
         RotateCharacter();
    }


    private void Move() {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        
        /*Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;*/
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
        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
        


        //animator.SetFloat("Speed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
        animator.SetFloat("Speed", movementInput.magnitude);
         TestVelocity = desiredMoveDirection * currentSpeed * Time.deltaTime;
        //Debug.Log(movementInput.magnitude);
    }

    void RotateCharacter() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSense;
        float rotAmountY = mouseY * mouseSense;

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

       // rotPlayer.x -= rotAmountY;
        rotPlayer.z = 0;
        rotPlayer.x = 0;

        rotPlayer.y += rotAmountX;


        player.rotation = Quaternion.Euler(rotPlayer);
    }

}














public GameObject[] structuresTypes;
Vector3 mousePos;
GameObject _structureTypes;
GameObject pre_structure;
bool isBuilding = false;


void Update()
{
    float x = Input.mousePosition.x;
    float z = Input.mousePosition.z;
    float y = 0.25f;
    mousePos = new Vector3(x, y, z);

    if (isBuilding == true)
    {
        pre_structure.transform.position = mousePos;
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(pre_structure);
            Instantiate(_structureTypes, mousePos, Quaternion.identity);
            isBuilding = false;
        }
    }
}


public void SelectFarm()
{
    _structureTypes = structuresTypes[0];
    isBuilding = true;
    Destroy(pre_structure);
    pre_structure = (GameObject)Instantiate(_structureTypes, mousePos, Quaternion.identity);
}
 
 
 }
