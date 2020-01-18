using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VoicesPlayerController : MonoBehaviour
{
    private Vector2 joystickMovementValue;
    private float lookLeftOrRight;
    private Vector3 moveDirection;
    private Vector2 rotateDirection;

    public float RotationSpeed = 50.0f;

    //private float FlipMovementDirectionMultiplier = -1.0f;

    public bool FlipMovementDirection = false;

    private int GroundCount = 1;
    public CapsuleCollider CapCollider;

    //public SteamVR_Input_Sources MovementHand;//Set Hand To Get Input From

    public SteamVR_Action_Vector2 MovementController;
    public SteamVR_Action_Vector2 RotationController;
    public SteamVR_Action_Boolean JumpAction;

    public float jumpHeight;
    public float MovementSpeed;

    //the Deadzone of the trackpad. used to prevent unwanted walking.
    public float Deadzone;
    
    public GameObject Head;

    //Hand Controller GameObject
    //public GameObject AxisHand;

    //public PhysicMaterial NoFrictionMaterial;
    //public PhysicMaterial FrictionMaterial;

    private void Start()
    {
        //CapCollider = GetComponent<CapsuleCollider>();
    }

    public static float NewAngleFunctionForTurning(Vector2 joystickValuesToAlter)
    {
        if (joystickValuesToAlter.x < 0)
        {
            return 360 - (Mathf.Atan2(joystickValuesToAlter.x, joystickValuesToAlter.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(joystickValuesToAlter.x, joystickValuesToAlter.y) * Mathf.Rad2Deg;
        }
    }

    void Update()
    {
            UpdateInput();
            UpdateCollider();
            //FlipMovementDirectionFunction();

            // Get the angle of the Joystick and change it based on the rotation of the Camera/Head.
            moveDirection = Quaternion.AngleAxis(NewAngleFunctionForTurning(joystickMovementValue) + Head.transform.rotation.eulerAngles.y, Vector3.up) * Vector3.forward;

            Rigidbody RBody = GetComponent<Rigidbody>();
            Vector3 velocity = new Vector3(0, 0, 0);

            //make sure the touch isn't in the deadzone and we aren't going too fast.
            if (joystickMovementValue.magnitude > Deadzone && GroundCount > 0)
            {
                // Change to no friction to move.
                //CapCollider.material = NoFrictionMaterial;

                // Multiply against flip multiplier if needed. 
                velocity = moveDirection * joystickMovementValue.magnitude;

                // Add force to Rigidbody to move.
                RBody.AddForce(velocity.x * MovementSpeed - RBody.velocity.x, 0, velocity.z * MovementSpeed - RBody.velocity.z, ForceMode.VelocityChange);

            }
            else if (GroundCount > 0)
            {
                //CapCollider.material = FrictionMaterial;
            }

            if(rotateDirection.magnitude > Deadzone)
            {
                // If the right joystick is moved left or right, rotate the Player object around the Head's center. 
                float step = Time.deltaTime * RotationSpeed;
                this.transform.RotateAround(new Vector3(Head.transform.position.x, 0, Head.transform.position.z), Vector3.up, rotateDirection.x * step);

            }

            /*
            if (JumpAction.stateDown && GroundCount > 0)
            {
                float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * 9.81f);
                RBody.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
            }
     */
    }

    /*
    public void FlipMovementDirectionFunction()
    {
        if(FlipMovementDirection)
        {
            FlipMovementDirectionMultiplier = 1.0f;
        }
        else
        {
            FlipMovementDirectionMultiplier = -1.0f;
        }
    }

    */

    private void UpdateCollider()
    {
        CapCollider.height = Head.transform.localPosition.y;
        CapCollider.center = new Vector3(Head.transform.localPosition.x, Head.transform.localPosition.y / 2, Head.transform.localPosition.z);
    }

    private void UpdateInput()
    {
        joystickMovementValue = MovementController.axis;
        rotateDirection = RotationController.axis;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GroundCount++;
    }
    private void OnCollisionExit(Collision collision)
    {
        GroundCount--;
    }
}
