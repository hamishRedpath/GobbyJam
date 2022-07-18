using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private Rigidbody playerRB;

    [Header("Movement Variables")]
    [SerializeField] private int playerSpeed;

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        playerRB.velocity = (new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized) * playerSpeed * Time.fixedDeltaTime;
    }
}
