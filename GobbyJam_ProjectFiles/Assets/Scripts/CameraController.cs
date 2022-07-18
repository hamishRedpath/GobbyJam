using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] private float camSpeed;
    private Vector2 xInput;
    [SerializeField] private GameObject pivot;

    void Start()
    {
        input = PlayerController.input;
        input.Gameplay.Camera.performed += ctx => xInput = ctx.ReadValue<Vector2>();
        input.Gameplay.Camera.canceled += ctx => xInput = Vector2.zero;
    }

    void Update()
    {
        pivot.transform.Rotate(0, xInput.x * camSpeed, 0);
        Debug.Log(xInput.x);
    }
 
}