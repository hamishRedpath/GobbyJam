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
        lightningNodes.Clear();
        GameObject firstEnemyHit = CheckNearestEnemy();
        if (firstEnemyHit != null)
        {
            lightningNodes.Add(this.gameObject);
            lightningNodes.Add(firstEnemyHit);
            firstEnemyHit.GetComponentInChildren<Enemy>().shocked = true;
            firstEnemyHit.GetComponentInChildren<Enemy>().CheckNearestOtherEnemy();
            Debug.Log("Amount Shocked: " + lightningNodes.Count);
            AddToRenderer(lightningNodes);
        }
    }

    void AddToRenderer(List<GameObject> lightningNodes)
    {
        Vector3[] nodesToAdd = new Vector3[lightningNodes.Count];
        for (int i = 0; i < lightningNodes.Count; i++)
        {
            nodesToAdd[i] = lightningNodes[i].transform.position;
        }
        lineRenderer.positionCount = nodesToAdd.Length;
        lineRenderer.SetPositions(nodesToAdd);
        // delete this after a fraction of a second
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
