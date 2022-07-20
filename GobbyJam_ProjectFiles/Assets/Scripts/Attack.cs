using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] private LineRenderer lineRenderer;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> lightningNodes = new List<GameObject>();
    public GameObject nearestEnemy = null;
    float nearestEnemyDistance = -1;

    public Animator animator;

    private void Start()
    {
        input = PlayerController.input;
        input.Gameplay.Attack.performed += ctx => BounceLighting();
    }

    void BounceLighting()
    {
        lightningNodes.Clear();
        GameObject firstEnemyHit = CheckNearestEnemy();
        if (firstEnemyHit != null)
        {
            enemies.Clear();
            lightningNodes.Add(this.gameObject);
            lightningNodes.Add(firstEnemyHit);
            firstEnemyHit.GetComponentInChildren<Enemy>().shocked = true;
            firstEnemyHit.GetComponentInChildren<Enemy>().CheckNearestOtherEnemy();
            Debug.Log("Amount Shocked: " + lightningNodes.Count);
            AddToRenderer();
        }

        StartCoroutine(AttackAnimation());
    }

    void AddToRenderer()
    {
        Vector3[] nodesToAdd = new Vector3[lightningNodes.Count];
       
        for (int i = 0; i < lightningNodes.Count; i++)
        {
            nodesToAdd[i] = lightningNodes[i].transform.position;
        }
        
        lineRenderer.positionCount = nodesToAdd.Length;
        lineRenderer.SetPositions(nodesToAdd);
        lightningNodes.Clear();
        StartCoroutine(ClearPositions());
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

    IEnumerator ClearPositions()
    {
        bool display = true;
        while (display == true)
        {
            yield return new WaitForSeconds(0.7f);
            print("please god help me");
            lineRenderer.positionCount = 0;
            display = false;
        }
        StopCoroutine(ClearPositions());
    }

    IEnumerator AttackAnimation()
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isAttacking", false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.isTrigger)
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
