using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManagement : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;
    [SerializeField] GameObject Enemy5;
    private bool once = true;
    private List<GameObject> enemies = new List<GameObject>();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (once)
        {
            if (other.tag == "Player")
            {


                StartCoroutine(_wait(5));

                once = false;
            }
        }
    }
    private void SpawnEnemy(GameObject enemy)
    {
       
        GameObject GEnemy = Instantiate(enemy) as GameObject;
        GEnemy.transform.position = this.transform.position;
    }

    private IEnumerator _wait(float time)
    {        SpawnEnemy(Enemy);
        yield return new WaitForSeconds(time);
        SpawnEnemy(Enemy2);
        yield return new WaitForSeconds(time);
        SpawnEnemy(Enemy3);
        yield return new WaitForSeconds(time);
        SpawnEnemy(Enemy4);
        yield return new WaitForSeconds(time);
        SpawnEnemy(Enemy5);
    }
}
