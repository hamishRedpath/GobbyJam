using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerInput input;
    bool pressed;
    [SerializeField] private LineRenderer lineRenderer;

    List<Vector3> nodes = new List<Vector3>();

    private void Start()
    {
        input = PlayerController.input;
        input.Gameplay.Attack.performed += ctx => CheckAttack();
    }

    void CheckAttack()
    {
        // if conditions met attack
    }

    
}
