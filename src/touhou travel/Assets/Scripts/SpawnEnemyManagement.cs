using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManagement : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] bool fixedSpawn;
    [SerializeField] int spawn;
    [SerializeField] GameObject Enemy2;
    [SerializeField] bool fixedSpawn2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] bool fixedSpawn3;
    [SerializeField] GameObject Enemy4;
    [SerializeField] bool fixedSpawn4;
    [SerializeField] GameObject Enemy5;
    [SerializeField] bool fixedSpawn5;
    private bool once = true;
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject anchor;
    private void Awake()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            

                GlobalControl.Instance.spawns.Add(false);
          
            
               
            if (once)
            {
                if (GlobalControl.Instance.spawns[spawn] != true)
                {




                    StartCoroutine(_wait(1));

                    once = false;


                }
                GlobalControl.Instance.spawns[spawn] = true;
            }
        }
    }
    private void SpawnEnemy(GameObject enemy, bool fixedSpawn = false)
    {
       
        GameObject GEnemy = Instantiate(enemy) as GameObject;
        if (fixedSpawn)
        {
            GEnemy.transform.position = anchor.transform.position;
        }
        else
        {
            GEnemy.transform.position = this.transform.position;
        }
    }

    private IEnumerator _wait(float time)
    {
        if (Enemy != null)
        {
            SpawnEnemy(Enemy, fixedSpawn);
        }
        yield return new WaitForSeconds(time);
        if (Enemy2 != null)
        {
            SpawnEnemy(Enemy2, fixedSpawn2);
        }
        yield return new WaitForSeconds(time);
        if (Enemy3 != null)
        {
            SpawnEnemy(Enemy3, fixedSpawn3);
        }
        yield return new WaitForSeconds(time);
        if (Enemy4 != null)
        {
            SpawnEnemy(Enemy4, fixedSpawn4);
        }
        yield return new WaitForSeconds(time);
        if (Enemy5 != null)
        {
            SpawnEnemy(Enemy5, fixedSpawn5);
        }
    }
}
