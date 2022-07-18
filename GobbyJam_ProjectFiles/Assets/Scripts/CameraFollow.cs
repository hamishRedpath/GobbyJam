using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 offset;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float smoothing;

    void Start()
    {
        offset = transform.position - playerTransform.position;    
    }

    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothing);
    }
}
