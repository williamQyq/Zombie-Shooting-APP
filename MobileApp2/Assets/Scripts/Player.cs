using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float playerSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float grav = 20.0f;
    public float gunDamage = 10;
    private Joystick moveJoyStick;
    private Joystick lookJoyStick;
    private Button jumpButton;
    private Button shootButton;
	private Button leftButton;
	private Button rightButton;
	private Button upButton;
	private Button downButton;
	public float lookSpeed = 1;

    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private float cameraXDir;
    private float cameraYDir;
    private float cameraSpeed = 1;
    private CharacterController playerController;


    void Start()
    {
        playerController = GetComponent<CharacterController>();
        moveJoyStick = FindObjectsOfType<Joystick>()[1];
        lookJoyStick = FindObjectsOfType<Joystick>()[0];

        //jumpButton = FindObjectsOfType<Button>()[0];  
		upButton = FindObjectsOfType<Button>()[1]; 
		downButton = FindObjectsOfType<Button>()[0]; 
		leftButton = FindObjectsOfType<Button>()[3]; 
		rightButton = FindObjectsOfType<Button>()[2]; 
        //shootButton = FindObjectsOfType<Button>()[3];    
    }

    void Update()
    {
        if (playerController.isGrounded)
        {     
            moveDirection = new Vector3(moveJoyStick.Horizontal, 0.0f, moveJoyStick.Vertical); //get input from joysticks
            moveDirection = transform.TransformDirection(moveDirection); //compare it to where character is facing 
            moveDirection = moveDirection * playerSpeed; 

            /*if (jumpButton.pressed)
            {
                moveDirection.y = jumpSpeed;
            }*/
        }
        moveDirection.y = moveDirection.y - (grav * Time.deltaTime);
        playerController.Move(moveDirection * Time.deltaTime);

        /*
         *if (shootButton.pressed)
         {
             RaycastHit shot;
             if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), shot))
             {
                 shot.transform.SendMessage("lose_life", gunDamage);
             }
         }
         */

        cameraXDir += lookJoyStick.Horizontal; // * cameraSpeed;
        cameraYDir += lookJoyStick.Vertical;

		

		if(lookJoyStick.Horizontal > 0.1){
			transform.Rotate(Vector3.up * lookSpeed);
		}
		else if(lookJoyStick.Horizontal < -0.1){
			transform.Rotate(Vector3.down * lookSpeed);
		}

		if(lookJoyStick.Vertical > 0.1){
			transform.Rotate(Vector3.left * lookSpeed);
		}
		else if(lookJoyStick.Vertical < -0.1){
			transform.Rotate(Vector3.right * lookSpeed);
		}



        /*
        if(upButton.pressed){
		
        		transform.Rotate(Vector3.left * lookSpeed);
        }
		if(downButton.pressed){
			
        		transform.Rotate(Vector3.right * lookSpeed);
        }
		if(leftButton.pressed){
        	transform.Rotate(Vector3.up * lookSpeed);
        }
		if(rightButton.pressed){
        	transform.Rotate(Vector3.down * lookSpeed);
        }
        */ 


   		/*
        lookDirection = new Vector3(cameraXDir,  0.0f, cameraYDir); //get input from joysticks
        transform.LookAt(lookDirection);
        transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        */


    }
}