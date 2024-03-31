using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*
 * Author[Judith Lopez]
 * Date[03/31/2024]
 * RigidbodyMovement attached to the player
 */

public class RigidbodyMovement : MonoBehaviour
{
    public float speed = 3f;
    private PlayerInputController playerActions;

    public float jumpHeight = 10f;

    //camera movement variables
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float sensitivity;
    public Transform PlayerCamera;
    public Rigidbody PlayerBody;

    private void Awake()
    {
        playerActions = new PlayerInputController();
        playerActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 moveVec = playerActions.Move.Move.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump:" + context.phase);
        if (context.performed)
        {
            Debug.Log("Real Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }



    public void MovePlayerCamera(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());

        xRot -= context.ReadValue<Vector2>().y * sensitivity;

        //transform.Rotate(0f, context.ReadValue<Vector2>().x * sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(0, xRot, 0f);
        //PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }
}