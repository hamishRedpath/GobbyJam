using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeath : MonoBehaviour
{
    
    public void killEnemy()
    {
        Destroy(this.gameObject);
    }
}
