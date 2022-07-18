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
        
    }
}