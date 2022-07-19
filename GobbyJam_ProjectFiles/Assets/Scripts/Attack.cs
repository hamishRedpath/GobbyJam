using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerInput input;
    bool pressed;
    [SerializeField] private LineRenderer lineRenderer;
    bool enemyInRange = false;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> lightningNodes = new List<GameObject>();
    int bouncebar = 10;
    public GameObject nearestEnemy = null;
    float nearestEnemyDistance = -1;

    private void Start()
    {
        input = PlayerController.input;
        input.Gameplay.Attack.performed += ctx => CheckAttack();
    }

    void CheckAttack()
    {
        // if conditions met attack

          BounceLighting();
        
    }

    void BounceLighting()
    {
        
        GameObject firstEnemyHit = CheckNearestEnemy();
        if (firstEnemyHit != null)
        {
            lightningNodes.Add(firstEnemyHit);
            firstEnemyHit.GetComponentInChildren<Enemy>().shocked = true;
            firstEnemyHit.GetComponentInChildren<Enemy>().CheckNearestOtherEnemy();
            Debug.Log("Amount Shocked: " + lightningNodes.Count);
            AddToRenderer(lightningNodes);
        }

        //for (int i = 0; i < lightningNodes.Count; i++)
        //{
        //    if (i == bouncebar)
        //    {
        //        return;
        //    }
        //    a = a.GetComponent<Enemy>().CheckNearestOtherEnemy();
        //    lightningNodes.Add(a);   
        //}
    }

    void AddToRenderer(List<GameObject> lightningNodes)
    {
        lightningNodes.Clear(); 
    }

    GameObject CheckNearestEnemy()
    {
        foreach (var enemy in enemies)
        {
            float distance;
            if (!enemy.GetComponentInChildren<Enemy>().shocked)
            {
                if (nearestEnemy == null)
                {
                    nearestEnemy = enemy;
                    nearestEnemyDistance = Vector3.Distance(transform.position, enemy.gameObject.transform.position);
                }
                else
                {
                    distance = Vector3.Distance(transform.position, enemy.gameObject.transform.position);
                    if (distance < nearestEnemyDistance)
                    {
                        nearestEnemy = enemy;
                    }
                }

            }
        }
        return nearestEnemy;
    }


    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<CapsuleCollider>(out CapsuleCollider temp);
        if (other.gameObject.tag == "Enemy" && !other.isTrigger && temp)
        {
            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
}
