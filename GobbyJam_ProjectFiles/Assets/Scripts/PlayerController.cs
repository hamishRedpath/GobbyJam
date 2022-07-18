using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    [Header("Object References")]
    [SerializeField] private Rigidbody playerRB;

    [Header("Movement Variables")]
    [SerializeField] private int playerSpeed;
    private Vector2 playerVelocity;

    private void Awake()
    {
        input = new PlayerInput();
        input.Gameplay.Movement.performed += ctx => playerVelocity = ctx.ReadValue<Vector2>();
        input.Gameplay.Movement.canceled += ctx => playerVelocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        playerRB.velocity = new Vector3 (playerVelocity.x, 0f, playerVelocity.y).normalized * playerSpeed * Time.fixedDeltaTime;
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