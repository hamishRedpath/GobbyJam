using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 offset;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float smoothing;
    PlayerInput input;
    [SerializeField] private float camSpeed;
    private float xInput;

    void Start()
    {
        offset = transform.position - playerTransform.position;
        input.Gameplay.Camera.performed += ctx => xInput = ctx.ReadValue<int>();
        input.Gameplay.Camera.canceled += ctx => xInput = 0;
    }

    void LateUpdate()
    {/*
        Vector3 newPos = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, smoothing); 
     */
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
