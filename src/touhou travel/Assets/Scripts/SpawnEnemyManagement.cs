using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManagement : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject GEnemy = Instantiate(Enemy) as GameObject;
            GEnemy.transform.position = this.transform.position;
        }
    }
}
