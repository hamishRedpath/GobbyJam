using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
     public static PlayerInput input;
    [Header("Object References")]
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private GameObject pivot;
    [SerializeField] private Transform camTransform;

    [Header("Movement Variables")]
    [SerializeField] private int playerSpeed;
    private Vector2 playerVelocity;
    private Vector2 xInput;
    [SerializeField] static public float camSpeed = 2f;

    private void Awake()
    {
        input = new PlayerInput();
        input.Gameplay.Movement.performed += ctx => playerVelocity = ctx.ReadValue<Vector2>();
        input.Gameplay.Movement.canceled += ctx => playerVelocity = Vector2.zero;

        input.Gameplay.Camera.performed += ctx => xInput = ctx.ReadValue<Vector2>();
        input.Gameplay.Camera.canceled += ctx => xInput = Vector2.zero;
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Quaternion deltaRotation = Quaternion.Euler(0, xInput.x * camSpeed, 0);
        playerRB.MoveRotation(playerRB.rotation * deltaRotation);

        //transform.Rotate(0, xInput.x * camSpeed, 0);
        pivot.transform.Rotate(0, xInput.x * camSpeed, 0);

        pivot.transform.position = playerRB.gameObject.transform.position;

        Vector3 direction = new Vector3(playerVelocity.x, 0, playerVelocity.y);
        playerRB.MovePosition(playerRB.position + transform.TransformDirection(direction) * Time.fixedDeltaTime * playerSpeed);
        // playerRB.velocity = transform.TransformDirection(direction) * Time.fixedDeltaTime * playerSpeed;

    }

    private void OnEnable()
    {
        input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        input.Gameplay.Disable();
    }
}