using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> enemies = new List<GameObject>();
    
    public GameObject nearest = null;
    float myDistance = -1;

    public bool shocked = false;

    public Animator animator;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Don't be a fuck boy and set me");
        }
    }

    private void Update()
    {
        if (shocked)
        {
            StartCoroutine(isShocked());
        }
    }

    public void CheckNearestOtherEnemy()
    {
        foreach (var enemy in enemies)
        {
            float distance;
            if (!enemy.GetComponentInChildren<Enemy>().shocked)
            {
                if(nearest == null)
                {
                    nearest = enemy;
                    myDistance = Vector3.Distance(transform.position, enemy.gameObject.transform.position);
                }
                else
                {
                    distance = Vector3.Distance(transform.position, enemy.gameObject.transform.position);
                    if (distance < myDistance)
                    {
                        nearest = enemy;
                    }
                }
            }
        }
        if (nearest != null)
        {
            player.GetComponent<Attack>().lightningNodes.Add(nearest);
            shocked = true;
            nearest.GetComponentInChildren<Enemy>().CheckNearestOtherEnemy();
        }
        else if(nearest == null && player.GetComponent<Attack>().lightningNodes.Count > 0)
        {
            shocked = true;
        }
    }

    private void OnTriggerEnter(Collider other)
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
       if(other.gameObject.tag == "Enemy")
       {
            enemies.Remove(other.gameObject);
       }
    }

    IEnumerator isShocked()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(4);
        Destroy(transform.parent.gameObject);

    }
}
